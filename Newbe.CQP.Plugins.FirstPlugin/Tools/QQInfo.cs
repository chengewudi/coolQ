using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.Tools
{
    public class QQInfo
    {
        public static async Task<string> GetQQName(long qq)
        {
            var result = await WebTools.DoRequest("http://r.qzone.qq.com/fcg-bin/cgi_get_score.fcg?mask=6&uins=" + qq.ToString());
            result = result.Trim();
            result = result.Substring(result.IndexOf("(") + 1, result.IndexOf(")") - result.IndexOf("(") - 1);
            var dir = JsonTool.DeserializeStringToDictionary<string, List<string>>(result);
            return dir.Values.ElementAt(0).ElementAt(6);
        }


    }


}
