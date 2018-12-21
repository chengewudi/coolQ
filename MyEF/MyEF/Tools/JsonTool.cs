using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Tools
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
    }
}
