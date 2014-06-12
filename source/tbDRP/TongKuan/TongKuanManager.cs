using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using tbDRP.Http;

namespace tbDRP.TongKuan
{
    public class TongKuanManager
    {
        public static string GetNewTitle(string title)
        {
            string newTitle = string.Empty;

            string url = string.Format("http://s.taobao.com/search?q={0}", HttpUtility.UrlEncode(title, Context.HttpEncoding));
            string content = NetDataManager.GetString(url);

            string body = NetDataManager.GetContent(content, "class=\"tb-content\"", "class=\"row grid-view newsrp-gridcontent-el\"", "<div class=\"tb-bottom\">");
            string matchString = "\\<div class=\"similar-btns\"\\>\\n*\\s*\\<span class=\"devide-line\"\\>\\<\\/span\\>\\n*\\s*\\<a target=\"_blank\" href=\"(?<url>.*?)\"";
            Match match = Regex.Match(body, matchString);
            if(match.Success)
            {
                string tongkuanUrl = match.Groups["url"].Value;

                newTitle = GetTongKuan(url, tongkuanUrl);
            }

            return newTitle;
        }

        private static string GetTongKuan(string mainUrl, string url)
        {
            string newTitle = string.Empty;

            url += "&promote=0&sort=sale-desc&tab=all";
            string content;

            NetDataManager.mainUrl = new Uri(mainUrl);
            if(NetDataManager.GetMainPage(url, out content))
            {
                string body = NetDataManager.GetContent(content, "class=\"tb-content\"", "class=\"list-view newsrp-i2i-listcontent-el\"", "<div class=\"tb-bottom\">");
                string matchString = "<h3 class=\"summary\">\\n*\\s*\\<a[^>]+>\\n*\\s*(?<title>.*?)\\n*\\s*</a>";
                Match match = Regex.Match(body, matchString);
                if (match.Success)
                {
                    newTitle = match.Groups["title"].Value;
                }
            }

            return newTitle;
        }
    }
}
