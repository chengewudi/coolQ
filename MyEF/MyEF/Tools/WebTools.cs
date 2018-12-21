using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Tools
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
    }
}
