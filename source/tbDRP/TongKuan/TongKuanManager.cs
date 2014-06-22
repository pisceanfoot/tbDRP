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
        public static string GetNewTitle2(string title, string vender)
        {
            string newTitle = string.Empty;

            string url = string.Format("http://s.taobao.com/search?q={0}", HttpUtility.UrlEncode(title, Context.HttpEncoding));
            string content = NetDataManager.GetString(url);

            string body = NetDataManager.GetContent(content, "class=\"tb-content\"", "class=\"row grid-view newsrp-gridcontent-el\"", "<div class=\"tb-bottom\">");
            string matchString = "\\<div class=\"similar-btns\"\\>\\n*\\s*\\<span class=\"devide-line\"\\>\\<\\/span\\>\\n*\\s*\\<a target=\"_blank\" href=\"(?<url>.*?)\"";
            Match match = Regex.Match(body, matchString);
            if (match.Success)
            {
                string tongkuanUrl = match.Groups["url"].Value;

                newTitle = GetTongKuan(url, tongkuanUrl);
            }

            if (newTitle != null)
            {
                newTitle = newTitle.Replace("包邮", string.Empty);
            }

            return newTitle;
        }

        public static string GetNewTitle(string title, string vender)
        {
            string newTitle = string.Empty;

            string url = string.Format("http://s.taobao.com/search?q={0}", HttpUtility.UrlEncode(title, Context.HttpEncoding));
            string content = NetDataManager.GetString(url);

            string body = NetDataManager.GetContent(content, "class=\"tb-content\"", "class=\"row grid-view newsrp-gridcontent-el\"", "<div class=\"tb-bottom\">");

            string tmallTongKuanUrl = null;
            string tongkuanUrl = null;

            const string find = "<div class=\"col item st-item";
            int index = body.IndexOf(find);
            while (index != -1)
            {
                int endIndex = body.IndexOf(find, index + find.Length);

                string tmp;
                if (endIndex == -1)
                {
                    tmp = body.Substring(index);
                }
                else
                {
                    tmp = body.Substring(index, endIndex - index);
                }

                string matchString = "\\<div class=\"similar-btns\"\\>\\n*\\s*\\<span class=\"devide-line\"\\>\\<\\/span\\>\\n*\\s*\\<a target=\"_blank\" href=\"(?<url>.*?)\"";
                Match match = Regex.Match(tmp, matchString);
                if (match.Success)
                {
                    string tmpTongkuanUrl = match.Groups["url"].Value;

                    if (tmp.Contains("icon-service-tianmao"))
                    {
                        if (tmallTongKuanUrl == null)
                        {
                            tmallTongKuanUrl = tmpTongkuanUrl;
                        }
                    }
                    else
                    {
                        // success
                        Match venderMatch = Regex.Match(tmp, "<div class=\"col seller[^>]*>[\\s\\n]*<a[^>]*>(?<name>.*?)</a>");
                        if (venderMatch.Success)
                        {
                            if (venderMatch.Groups["name"].Value.Trim() == vender)
                            {
                                tongkuanUrl = tmpTongkuanUrl;
                                break;
                            }
                        }
                    }
                }

                index = endIndex;
            }

            //if (string.IsNullOrEmpty(tongkuanUrl))
            //{
            //    tongkuanUrl = tmallTongKuanUrl;
            //}
            if (!string.IsNullOrEmpty(tongkuanUrl))
            {
                newTitle = GetTongKuan(url, tongkuanUrl);
            }

            if (!string.IsNullOrEmpty(newTitle))
            {
                newTitle = newTitle.Replace("包邮", string.Empty);
            }

            return newTitle;
        }

        public static string GetNewTitleByCode(string code)
        {
            string newTitle = string.Empty;

            string url = string.Format("http://s.taobao.com/search?q={0}", HttpUtility.UrlEncode(code, Context.HttpEncoding));
            string content = NetDataManager.GetString(url);

            string body = NetDataManager.GetContent(content, "class=\"tb-content\"", "class=\"row grid-view newsrp-gridcontent-el\"", "<div class=\"tb-bottom\">");

            string tmallTongKuanUrl = null;
            string tongkuanUrl = null;

            const string find = "<div class=\"col item st-item";
            int index = body.IndexOf(find);
            while (index != -1)
            {
                int endIndex = body.IndexOf(find, index + find.Length);

                string tmp;
                if (endIndex == -1)
                {
                    tmp = body.Substring(index);
                }
                else
                {
                    tmp = body.Substring(index, endIndex - index);
                }

                string matchString = "\\<div class=\"similar-btns\"\\>\\n*\\s*\\<span class=\"devide-line\"\\>\\<\\/span\\>\\n*\\s*\\<a target=\"_blank\" href=\"(?<url>.*?)\"";
                Match match = Regex.Match(tmp, matchString);
                if (match.Success)
                {
                    string tmpTongkuanUrl = match.Groups["url"].Value;

                    if (tmp.Contains("icon-service-tianmao"))
                    {
                        if (tmallTongKuanUrl == null)
                        {
                            tmallTongKuanUrl = tmpTongkuanUrl;
                        }
                    }
                    else
                    {
                        // success
                        Match venderMatch = Regex.Match(tmp, "<div class=\"col seller[^>]*>[\\s\\n]*<a[^>]*>(?<name>.*?)</a>");
                        if (venderMatch.Success)
                        {
                            // TODO:

                            //if (venderMatch.Groups["name"].Value.Trim() == vender)
                            //{
                            //    tongkuanUrl = tmpTongkuanUrl;
                            //    break;
                            //}
                        }
                    }
                }

                index = endIndex;
            }

            //if (string.IsNullOrEmpty(tongkuanUrl))
            //{
            //    tongkuanUrl = tmallTongKuanUrl;
            //}
            if (!string.IsNullOrEmpty(tongkuanUrl))
            {
                newTitle = GetTongKuan(url, tongkuanUrl);
            }

            if (!string.IsNullOrEmpty(newTitle))
            {
                newTitle = newTitle.Replace("包邮", string.Empty);
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

                string lastTmallTitle = null;
                const string find = "<div class=\"row item";
                int index = body.IndexOf(find);
                while (index != -1)
                {
                    string tmp;
                    int endIndex = body.IndexOf(find, index + find.Length);
                    if (endIndex == -1)
                    {
                        tmp = body.Substring(index);
                    }
                    else
                    {
                        tmp = body.Substring(index, endIndex - index);
                    }

                    string matchString = "<h3 class=\"summary\">\\n*\\s*\\<a[^>]+>\\n*\\s*(?<title>.*?)\\n*\\s*</a>";
                    Match match = Regex.Match(tmp, matchString);
                    if (match.Success)
                    {
                        Match tmallMatch = Regex.Match(tmp, "<div class=\"elem-level\">[\\s\\n]*<a href=\"http://www.tmall.com\"");
                        bool isTmall = tmallMatch.Success;

                        if (isTmall)
                        {
                            if (lastTmallTitle == null)
                            {
                                lastTmallTitle = match.Groups["title"].Value;
                            }
                        }
                        else
                        {
                            newTitle = match.Groups["title"].Value;
                        }
                    }

                    if (!string.IsNullOrEmpty(newTitle))
                    {
                        break;
                    }

                    index = body.IndexOf(find, index + find.Length);
                }

                if (string.IsNullOrEmpty(newTitle) && !string.IsNullOrEmpty(lastTmallTitle))
                {
                    newTitle = lastTmallTitle;
                }

            }

            return newTitle;
        }
    }
}
