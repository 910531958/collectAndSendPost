using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace readMail
{
    class winManager
    {
        public baseSet bsWin = new baseSet();
        public static winManager wm;
        public static winManager getThis()
        {
            if (wm==null) wm = new winManager();
            return wm;
        }

    }
}
