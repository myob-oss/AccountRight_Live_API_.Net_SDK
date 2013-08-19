using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MYOB.AccountRight.SDK.Extensions
{
    internal static class JsonExtensions
    {
        public static string ToJson(this object entity)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, entity);
                return writer.ToString();
            }
        }

        public static T FromJson<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
