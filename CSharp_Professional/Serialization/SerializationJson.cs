using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;

namespace Serialization
{

    public static class SerializationJson
    {


        /// <summary> Serialize from object to Json </summary>
        /// <param name="obj">any object</param>
        /// <returns>Json</returns>
        public static string SerializeFromObjectToJSON(object obj)
        {
            return JsonSerializer.Serialize(obj, JsonFileOption());
        }

        /// <summary> Deserialize from Json to object</summary>
        /// <param name="json">string in Json format</param>
        /// <returns>object</returns>
        public static object DeserializeFromJSONToObject(string json)
        {
            return JsonSerializer.Deserialize<TestClass>(json, JsonFileOption());
        }


        static JsonSerializerOptions JsonFileOption()
        {
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
            };
            return opt;
        }

    }
}
