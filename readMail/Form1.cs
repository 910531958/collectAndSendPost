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

namespace readMail
{
    public partial class Form1 : Form
    {
        public Dictionary<string,string> htmlList=new Dictionary<string,string>();
        private string title;
        private string content;
        private int type = 0;//0：登录 1：进入发帖子页面 2：帖子发布 3：帖子发成功
        public Form1()
        {
            InitializeComponent();
            htmlList.Add("<strong>", "phhui_加粗头");
            htmlList.Add("</strong>", "phhui_加粗尾");
            htmlList.Add("<br />", "phhui_换行");
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
            txt_output.Text = "标题：" + title;
            txt_output.Text += "内容：" + content;
        }
        public String UnSafeHTMLFilter(string html)
        {
            //html=saveHtml(html);
            Regex regex1 = new Regex(@"<[^>]+>", RegexOptions.IgnoreCase);// 定义HTML标签的正则表达式
            Regex regex2 = new Regex(@"<[/s]*?script[^>]*?>[/s/S]*?<[/s]*?//[/s]*?script[/s]*?>", RegexOptions.IgnoreCase);// 定义script的正则表达式{或<script[^>]*?>[/s/S]*?<//script>
            html = regex1.Replace(html, ""); //过滤HTML标记 
            html = regex2.Replace(html, ""); //过滤script属性 
            return resetHtml(html);
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

        private void btn_send_Click(object sender, EventArgs e)
        {
            webView.Navigate("56lea.com");
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
                webView.Document.GetElementById("password").SetAttribute("value", "password");
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
    }
}
