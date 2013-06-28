using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;

namespace readMail
{
    public partial class Form1 : Form
    {
        public Dictionary<string,string> htmlList=new Dictionary<string,string>();
        private ArrayList postList = new ArrayList();
        private string title;
        private string content;
        private Boolean login = false;
        private int imgnum=0;
        private int type = 0;//0：登录 1：进入发帖子页面 2：帖子发布 3：帖子发成功
        public Form1()
        {
            InitializeComponent();
            htmlList.Add("<strong>", "[b]");
            htmlList.Add("</strong>", "[/b]");
            htmlList.Add("&ldquo;", "\"");
            htmlList.Add("&rdquo;", "\"");
            //htmlList.Add("<br />", "phhui_换行");
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            Byte[] pageData = wc.DownloadData(txt_usn.Text); //从指定网站下载数据

            string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

            //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            title = pageHtml.Substring(pageHtml.IndexOf("<h1>") + 4, pageHtml.IndexOf("</h1>") - pageHtml.IndexOf("<h1>") - 4) + "\r\n\r\n";
            content = UnSafeHTMLFilter(pageHtml.Substring(pageHtml.IndexOf("u950309\";") + 9, pageHtml.IndexOf("<!--赞一下-->") - pageHtml.IndexOf("u950309\";") - 9));
            while (content.Substring(0, 1) == "　")
            {
                content = content.Substring(1);
            }
            while (content.Substring(0, 4) == "\r\n")
            {
                content = content.Substring(4);
            }
            content = "[size=3]"+content.Substring(40)+"[/size]";
            txt_output.Text = "标题：" + title;
            txt_output.Text += "内容：" + content;
            //return;
            if (login)
            {
                type = 2;
                webView.Navigate("http://56lea.com/forum.php?mod=post&action=newthread&fid=49");
            }
            else webView.Navigate("56lea.com");
        }
        public String UnSafeHTMLFilter(string html)
        {
            html=saveHtml(html);
            string[] list = GetHtmlImageUrlList(html);
            html = replaceStr(html);
            Regex regex0 = new Regex(@"<img[^>]+>", RegexOptions.IgnoreCase);// 定义IMG标签的正则表达式
            Regex regex1 = new Regex(@"<[^>]+>", RegexOptions.IgnoreCase);// 定义HTML标签的正则表达式
            Regex regex2 = new Regex(@"<[/s]*?script[^>]*?>[/s/S]*?<[/s]*?//[/s]*?script[/s]*?>", RegexOptions.IgnoreCase);// 定义script的正则表达式{或<script[^>]*?>[/s/S]*?<//script>
            Regex regex3 = new Regex(@"<alt=[^>]+src=", RegexOptions.IgnoreCase);
            html = regex0.Replace(html, ""); //过滤IMG标记 
            html = regex1.Replace(html, ""); //过滤HTML标记 
            html = regex2.Replace(html, ""); //过滤script属性 
            html = html.Replace("<strong>", "[b]");
            html = html.Replace("</strong>", "[/b]");
            html = html.Replace("&mdash;", "--");
            int n=list.Length;
            for (int i = 0; i < n;i++ )
            {
                html = html.Replace("[img"+i.ToString()+"]","[img]"+list[i]+"[/img]");
            }
            return html;// resetHtml(html);
        }
        public String saveHtml(string html)
        {
            foreach (KeyValuePair<string, string> l in htmlList)
            {
                html = html.Replace(l.Key,l.Value);
            }
            return html;
        }
        public String resetHtml(string html)
        {
            foreach (KeyValuePair<string, string> l in htmlList)
            {
                html = html.Replace(l.Value, l.Key);
            }
            return html;
        }
        public string replaceStr(string str){
            string s1 = str.Substring(0,str.IndexOf("<img")+4);
            s1 = s1.Replace("<img", "[img"+imgnum.ToString()+"]<img");
            imgnum++;
            if (str.Substring(str.IndexOf("<img") + 4).IndexOf("<img") != -1)
            {
                return s1 + replaceStr(str.Substring(str.IndexOf("<img") + 4));
            }
            return s1 + str.Substring(str.IndexOf("<img") + 4);
        }
        public string[] GetHtmlImageUrlList(string sHtmlText)
        {

            // 定义正则表达式用来匹配 img 标签 

            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串 

            MatchCollection matches = regImg.Matches(sHtmlText);

            int i = 0;

            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表 

            foreach (Match match in matches)

                sUrlList[i++] = match.Groups["imgUrl"].Value;

            return sUrlList;

        } 

        private void webView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (type == 0)
            {
                if (webView.Document.GetElementById("username") == null)
                {
                    webView.Navigate("56lea.com");
                    return;
                }
                webView.Document.GetElementById("username").SetAttribute("value", "oO小菜Oo");
                webView.Document.GetElementById("password").SetAttribute("value", "qnsrwdmmok");
                for (int j = 0; j < webView.Document.All.Count; j++)
                {
                    if (webView.Document.All[j].GetAttribute("value").IndexOf("登录") > -1)
                    {
                        webView.Document.All[j].InvokeMember("click");
                    }
                }
                type = 1;
            }
            else if (type == 1)
            {
                login = true;
                webView.Navigate("http://56lea.com/forum.php?mod=post&action=newthread&fid=49");
                type = 2;
            }
            else if (type == 2)
            {
                webView.Document.GetElementById("subject").SetAttribute("value", title);
                webView.Document.GetElementById("e_textarea").SetAttribute("value", content);
                webView.Document.GetElementById("postsubmit").InvokeMember("click");
            }
            else
            {
                type = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendPostData("http://56lea.com/member.php?mod=logging&action=login&referer=http%3A%2F%2F56lea.com%2Fforum.php%3Fmod%3Dviewthread%26tid%3D3316%26extra%3Dpage%253D1","username=oO小菜Oo&password=qnsrwdmmok");
        }
        private void SendPostData(string path, string strhtml)
        {
            HttpWebRequest httprequest = (HttpWebRequest)WebRequest.Create(path);

            httprequest.Method = "POST";
            //httprequest.ContentLength = strhtml.Length;
            httprequest.ContentType = "application/x-www-form-urlencoded";
            Stream httprequeststream = httprequest.GetRequestStream();
            StreamWriter sw = new StreamWriter(httprequeststream);
            sw.Write(strhtml);
            sw.Close();
            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)httprequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    //HTTP status 200
                    Stream receiveStream = myHttpWebResponse.GetResponseStream();
                    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader readStream = new StreamReader(receiveStream, encode);
                    txt_output.Text = readStream.ReadToEnd();
                    //...读取返回的内容
                    readStream.Close();
                    type = 5;
                    webView.Navigate("56lea.com");
                }
                myHttpWebResponse.Close();

            }
            catch (WebException e)
            {
                MessageBox.Show(e.Status.ToString());
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
        }
        public void GetPage(String url)
        {
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    //HTTP status 200
                    Stream receiveStream = myHttpWebResponse.GetResponseStream();
                    Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
                    StreamReader readStream = new StreamReader(receiveStream, encode); 
                    txt_output.Text = readStream.ReadToEnd();
                    //...读取返回的内容
                    readStream.Close(); 
                }
                myHttpWebResponse.Close();

            }
            catch (WebException e)
            {
                MessageBox.Show(e.Status.ToString());
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
        }

        private void btn_getList_Click(object sender, EventArgs e)
        {

        }

        private void webView_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webView.ScriptErrorsSuppressed = true;
        }
    }
}
