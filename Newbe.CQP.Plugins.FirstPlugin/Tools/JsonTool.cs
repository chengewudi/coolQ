using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.Tools
{
    public class JsonTool
    {
        public static T JsonToObject<T>(string json) where T : class
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            StringReader reader = new StringReader(json);
            object o = jsonSerializer.Deserialize(new JsonTextReader(reader), typeof(T));
            T t = o as T;
            return t;
        }

        public static string ObjectToJson(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }
    }
}
