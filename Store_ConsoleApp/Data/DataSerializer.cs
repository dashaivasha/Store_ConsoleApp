using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace InternshipProject.ConsoleMenu
{
    public class DataSerializer
    {
        public static void JsonSerialize(object dataType, string filePath)
        {
            var jsonSerializer = new JsonSerializer();
            var sw = new StreamWriter(filePath);
            var jsonWr = new JsonTextWriter(sw);
            jsonSerializer.Serialize(jsonWr, dataType);
            jsonWr.Close();
            sw.Close();
        }

        public static object JsonDeserialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new();

            if (File.Exists(filePath))
            {
                var sr = new StreamReader(filePath);
                var jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();
            }

            return obj.ToObject(dataType);
        }
    }
}