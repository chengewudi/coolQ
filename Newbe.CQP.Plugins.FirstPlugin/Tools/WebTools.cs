using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.Tools
{
    public class WebTools
    {
        public static async Task<string> DoRequest(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Timeout = 30 * 1000;
            request.KeepAlive = true;
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

            HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
            var responseStream = response.GetResponseStream();

            string result;

            try
            {
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd().Trim();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static async Task<string> DoPostRequest(string URL, string body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            //request.Connection = "keep-alive";
            request.Accept = "application/json";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            request.Timeout = 30 * 1000;

            byte[] postData = Encoding.UTF8.GetBytes(body);
            request.ContentLength = postData.Length;
            Stream streamReq = request.GetRequestStream();

            streamReq.Write(postData, 0, postData.Length);
            streamReq.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();

            return result;
        }

        public static async Task<string> DoPostRequestForSNH(string url,string body)
        {
            var responseString = await url
                .PostUrlEncodedAsync(new { date = body })
                .ReceiveString();
            responseString = responseString.Trim();
            responseString = ConvertUnicodeStringToChinese(responseString.Trim());
            return responseString;
        }

        public static string ConvertUnicodeStringToChinese(string unicodeString)
        {
            if (string.IsNullOrEmpty(unicodeString))
                return string.Empty;

            string outStr = unicodeString;

            Regex re = new Regex("\\\\u[0123456789abcdef]{4}", RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(unicodeString);
            foreach (Match ma in mc)
            {
                outStr = outStr.Replace(ma.Value, ConverUnicodeStringToChar(ma.Value).ToString());
            }
            return outStr;
        }

        private static char ConverUnicodeStringToChar(string str)
        {
            char outStr = Char.MinValue;
            outStr = (char)int.Parse(str.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            return outStr;
        }

    }

}
