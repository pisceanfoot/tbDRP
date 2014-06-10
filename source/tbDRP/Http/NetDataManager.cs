using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace tbDRP.Http
{
    /// <summary>
    /// NetDateManager 的摘要说明
    /// </summary>
    public static class NetDataManager
    {
        private const string REGEXPATTERN = @"<a[^>]+(.*)\s*href\s*=\s*""(?<href>[^""]+)""\s*[^>]*(.*)>(?<text>.*?)</a>";

        public static Uri mainUrl = null;
        private static Regex regex;
        private static string encoding = string.Empty;
        public delegate void ContentCallBack(ContentInfo info, string html);

        static NetDataManager()
        {
            regex = new Regex(REGEXPATTERN, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 使用特定的编码
        /// </summary>
        public static void UseSpicalEncoding(string userEncoding)
        {
            encoding = userEncoding;
        }

        /// <summary>
        /// 获取页面源码
        /// </summary>
        public static string GetString(string url)
        {
            string content = "";

            if (!string.IsNullOrEmpty(url))
            {
                content = NetResponse.GetStreamString(GetUrl(url.Trim()), encoding);
            }

            return content;
        }

        /// <summary>
        /// 第一步，获取首页
        /// </summary>
        public static bool GetMainPage(string mainPageUrl, out string content)
        {
            content = string.Empty;
            if (string.IsNullOrEmpty(mainPageUrl)) return false;

            if (mainUrl != null)
            {
                mainPageUrl = GetUrl(mainPageUrl);
            }

            mainUrl = new Uri(mainPageUrl);

            try
            {
                content = NetResponse.GetStreamString(mainPageUrl.Trim(), encoding);
                return true;
            }
            catch (Exception ex)
            {
                content = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 第二步，获取内容部分
        /// </summary>
        public static bool GetContentBlock(string start, string end, string content, out string block)
        {
            block = string.Empty;
            if (string.IsNullOrEmpty(content)) return false;
            if (string.IsNullOrEmpty(start)) return false;
            if (string.IsNullOrEmpty(end)) return false;

            string code = content.ToLower();

            int index = code.IndexOf(start, StringComparison.OrdinalIgnoreCase);
            if (index == -1) return false;

            string tmp = code.Substring(index, code.Length - index);
            int indexEnd = tmp.IndexOf(end, StringComparison.OrdinalIgnoreCase);
            if (indexEnd == -1) return false;

            block = content.Substring(index, indexEnd);
            return true;
        }

        /// <summary>
        /// 第三步，获取所有的 Title 和 Url
        /// </summary>
        public static List<ContentInfo> GetAllTitleAndUrl(string condition, string content)
        {
            if (string.IsNullOrEmpty(condition) || string.IsNullOrEmpty(content)) return new List<ContentInfo>();

            string match = "({[A-Za-z0-9]+})+";

            Regex regex = new Regex(match);
            MatchCollection matchCollection = regex.Matches(condition);

            List<string> list = new List<string>();
            foreach (Match matchc in matchCollection)
            {
                string tmp = matchc.Value.ToLower();
                if (tmp == "{title}" || tmp == "{url}")
                {
                    int index = condition.IndexOf(tmp);
                    if (index == -1) continue;

                    list.Add(condition.Substring(0, index));
                    condition = condition.Substring(index + tmp.Length, condition.Length - index - tmp.Length);
                }
            }

            if (condition != string.Empty)
            {
                list.Add(condition);
            }

            List<ContentInfo> infoList = new List<ContentInfo>();
            if (list.Count > 0)
            {
                string lastCode = content;

                string tmatch = list[0];
                int index = lastCode.IndexOf(tmatch);

                while (index != -1)
                {
                    ContentInfo info = new ContentInfo();
                    int i = 0;
                    while (i < list.Count)
                    {
                        tmatch = list[i];
                        index = lastCode.IndexOf(tmatch);
                        if (index == -1) break;

                        if (i == 1)
                        {
                            string tmpUrl = lastCode.Substring(0, index);
                            tmpUrl = GetUrl(tmpUrl);
                            info.Url = tmpUrl;
                            info.ParentUrl = tmpUrl;
                        }
                        else if (i == 2)
                        {
                            info.Title = lastCode.Substring(0, index);
                        }
                        lastCode = lastCode.Substring(index + tmatch.Length, lastCode.Length - index - tmatch.Length);
                        i++;
                    }

                    if (!string.IsNullOrEmpty(info.Url))
                        infoList.Add(info);
                }
            }

            return infoList;
        }

        /// <summary>
        /// 第三步，使用正则表达式获取所有的 Title 和 Url
        /// </summary>
        public static List<ContentInfo> GetAllTitleAndUrlWithRegex(string codition, string content)
        {
            List<ContentInfo> infoList = new List<ContentInfo>();

            List<RegexGroupResult> list = RegexUtils.MatchCollection(content, codition);
            foreach (RegexGroupResult result in list)
            {
                ContentInfo info = new ContentInfo();
                info.Title = result["title"].Value;

                string tmpUrl = result["url"].Value;
                tmpUrl = GetUrl(tmpUrl);
                info.Url = tmpUrl;
                info.ParentUrl = tmpUrl;

                if (result["time"] != null)
                    info.Time = result["time"].Value;

                infoList.Add(info);
            }

            return infoList;
        }

        /// <summary>
        /// 获取文章链接（除去最后的文件名称）
        /// </summary>
        /// <returns></returns>
        public static string GetUrl(string url)
        {
            Uri newValue;
            string newUrl = string.Empty;
            string tmp = url.ToLower();

            if (tmp.StartsWith("http://") || tmp.StartsWith("https://")) return url;

            if (url.StartsWith("?"))
            {
                if (!string.IsNullOrEmpty(mainUrl.Query))
                {
                    newUrl = mainUrl.AbsoluteUri.Replace(mainUrl.Query, "");
                }

                newUrl += url;
            }
            else
            {
                Uri.TryCreate(mainUrl, url, out newValue);
                newUrl = newValue.AbsoluteUri;
            }

            newUrl = newUrl.Replace("&amp;", "&");
            return newUrl;
        }

        /// <summary>
        /// 获取文章链接
        /// </summary>
        /// <param name="main">页面地址名称，当前页面的全url</param>
        /// <param name="url">从列表中获取的地址，href=""引号之间的</param>
        /// <returns></returns>
        public static string GetUrl(string main, string url)
        {
            Uri newValue;
            string newUrl = string.Empty;
            string tmp = url.ToLower();
            Uri mainUrl = new Uri(main);
            if (tmp.StartsWith("http://") || tmp.StartsWith("https://")) return url;

            if (url.StartsWith("?"))
            {
                if (!string.IsNullOrEmpty(mainUrl.Query))
                {
                    newUrl = mainUrl.AbsoluteUri.Replace(mainUrl.Query, "");
                }

                newUrl += url;
            }
            else
            {
                Uri.TryCreate(mainUrl, url, out newValue);
                newUrl = newValue.AbsoluteUri;
            }

            newUrl = newUrl.Replace("&amp;", "&");
            return newUrl;
        }

        private static string MakeMD5(string parentUrl)
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(parentUrl);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(buffer);

            return ByteArrayToHexString(result);
        }

        public static String ByteArrayToHexString(Byte[] bytes)
        {
            System.Text.StringBuilder temp = new System.Text.StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                temp.Append(bytes[i].ToString("X2"));
            }
            return temp.ToString();
        }

        /// <summary>
        /// 分析获取网页数据
        /// </summary>
        /// <param name="content"></param>
        /// <param name="first"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GetContent(string content, string first, string start, string end)
        {
            int index = -1;

            if (first != string.Empty)
            {
                index = content.IndexOf(first);
                if (index != -1)
                {
                    content = content.Substring(index + first.Length, content.Length - index - first.Length);
                }
                else
                {
                    return string.Empty;
                }
            }

            index = content.IndexOf(start);
            if (index == -1) return string.Empty;
            content = content.Substring(index + start.Length, content.Length - index - start.Length);

            index = content.IndexOf(end);
            if (index == -1) return string.Empty;

            content = content.Substring(0, index);

            return content;
        }
        #region HTML

        /// <summary>
        /// 删除HTML标记
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ConvertHTML2TextRegex(string html)
        {
            string[] aryRegex ={@"<%=[\w\W]*?%>",    @"<script[\w\W]*?</script>",     @"<style[\w\W]*?</style>",   @"<[/]?[\w\W]*?>",   @"([\r\n])[\s]+",
                              @"&(nbsp|#160);",    @"&(iexcl|#161);",  @"&(cent|#162);",            @"&(pound|#163);",   @"&(copy|#169);",
                              @"&#(\d+);",         @"-->",                          @"<!--.*\n"};
            string[] aryReplacment = { "", "", "", "", "", " ", "", "", "", "", "", "", "" };

            for (int i = 0; i < aryRegex.Length; i++)
            {
                Regex regex = new Regex(aryRegex[i], RegexOptions.IgnoreCase);
                html = regex.Replace(html, aryReplacment[i]);
            }

            //Replace "\r\n \t" to an empty character.
            html.Replace("\r\n", "");
            html.Replace("\t", "");

            return html;
        }

        /// <summary>
        /// 过滤HTML中的不安全标签包括js,style,meta 等
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        #endregion HTML

        public static string SafeFileName(string fileName)
        {
            //\/:*?"<>|
            fileName = fileName.Replace("\\", "");
            fileName = fileName.Replace("/", "");
            fileName = fileName.Replace(":", "");
            fileName = fileName.Replace("*", "");
            fileName = fileName.Replace("?", "");
            fileName = fileName.Replace("<", "");
            fileName = fileName.Replace(">", "");
            fileName = fileName.Replace("\"", "");
            fileName = fileName.Replace("|", "");

            return fileName;
        }
    }
}