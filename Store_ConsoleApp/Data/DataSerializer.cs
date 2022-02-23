using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InternshipProject.ConsoleMenu
{
    public class DataSerializer
    {
        public static void JsonSerialize(object dataType, string filePath)
        {
            Newtonsoft.Json.JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonwr = new JsonTextWriter(sw);
            jsonSerializer.Serialize(jsonwr, dataType);
            jsonwr.Close();
            sw.Close();
        }

        public static object JsonDeserialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new();

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();
            }

            return obj.ToObject(dataType);
        }
    }
}
