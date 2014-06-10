using System;
using System.IO;
using System.Net;
using System.Text;

namespace tbDRP.Http
{
    public class NetResponse
    {
        public static string GetStreamString(string url)
        {
            return GetStreamString(url, "");
        }

        public static string GetStreamString(string url, string encoding)
        {
            Uri u = new Uri(url);
            StreamReader sr = null;
            HttpWebResponse response = null;
            string error = string.Empty;
            string tmp = string.Empty;

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                httpWebRequest.Referer = "HTTP://" + u.Host + "/";

                response = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                Stream s = response.GetResponseStream();

                Encoding e = Encoding.UTF8;

                string tmpCharSet = "";

                if (!string.IsNullOrEmpty(response.CharacterSet))
                {
                    tmpCharSet = response.CharacterSet;
                }

                if (!string.IsNullOrEmpty(encoding))
                {
                    tmpCharSet = encoding;
                }

                if (!string.IsNullOrEmpty(tmpCharSet))
                {
                    try
                    {
                        e = Encoding.GetEncoding(tmpCharSet);
                    }
                    catch { e = Encoding.UTF8; }
                }
                sr = new StreamReader(s, e);

                if (sr == null) return error;
                tmp = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }

                if (response != null)
                    response.Close();
            }

            return tmp;
        }

        public static string GetStreamString(string url, CookieContainer container, string encoding)
        {
            Uri u = new Uri(url);
            StreamReader sr = null;
            HttpWebResponse response = null;
            string error = string.Empty;
            string tmp = string.Empty;

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                httpWebRequest.Referer = "HTTP://" + u.Host + "/";
                if (container != null)
                    httpWebRequest.CookieContainer = container;

                response = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                Stream s = response.GetResponseStream();

                Encoding e = Encoding.UTF8;
                string tmpCharSet = "";
                if (!string.IsNullOrEmpty(response.CharacterSet))
                    tmpCharSet = response.CharacterSet;
                if (!string.IsNullOrEmpty(encoding))
                    tmpCharSet = encoding;
                if (!string.IsNullOrEmpty(tmpCharSet))
                {
                    try
                    {
                        e = Encoding.GetEncoding(tmpCharSet);
                    }
                    catch { e = Encoding.UTF8; }
                }

                sr = new StreamReader(s, e);
                if (sr == null) return error;
                tmp = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }

                if (response != null)
                    response.Close();
            }

            return tmp;
        }

        public static string GetStreanUsePost(string url, string parameter, string encoding, CookieContainer container, bool retureString)
        {
            Uri u = new Uri(url);
            string result = string.Empty;
            HttpWebResponse httpResponse = null;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.Referer = "http://" + u.Host + "/";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";

                string sendData = parameter;

                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(sendData);
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";

                if (container != null)
                    httpWebRequest.CookieContainer = container;

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (container != null)
                    container.Add(httpResponse.Cookies);

                if (retureString)
                {
                    StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(encoding));
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }
            catch { }
            finally
            {
                if (httpResponse != null)
                    httpResponse.Close();
            }

            return result;
        }

        public static string GetStreanUsePostFile(string url, byte[] buffer, string encoding, CookieContainer container, string boundary, bool retureString)
        {
            Uri u = new Uri(url);
            string result = string.Empty;
            HttpWebResponse httpResponse = null;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.Referer = "http://" + u.Host + "/";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET CLR 3.0.30618; CIBA)";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.ContentType = "multipart/form-data; boundary=---------------------------" + boundary;

                if (container != null)
                    httpWebRequest.CookieContainer = container;

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (container != null)
                    container.Add(httpResponse.Cookies);

                if (retureString)
                {
                    StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(encoding));
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }
            catch
            {
            }
            finally
            {
                if (httpResponse != null)
                    httpResponse.Close();
            }

            return result;
        }
    }
}