using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyEF.Tools
{
    public class UnicodeToChinese
    {
        /// 
        /// 将Unicode编码转换为汉字字符串 
        /// 
        /// Unicode编码字符串 
        /// 汉字字符串 
        public static string ToGB2312(string str)
        {
            MatchCollection mc = Regex.Matches(str, "([\\w]+)|(\\\\u([\\w]{4}))");
            if (mc != null && mc.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Match m2 in mc)
                {
                    string v = m2.Value;
                    if (v.StartsWith("\\"))
                    {
                        string word = v.Substring(2);
                        byte[] codes = new byte[2];
                        int code = Convert.ToInt32(word.Substring(0, 2), 16);
                        int code2 = Convert.ToInt32(word.Substring(2), 16);
                        codes[0] = (byte)code2;
                        codes[1] = (byte)code;
                        sb.Append(Encoding.Unicode.GetString(codes));
                    }
                    else
                    {
                        sb.Append(v);
                    }
                }
                return sb.ToString();
            }
            else
            {
                return str;
            }
        }

    }
}
