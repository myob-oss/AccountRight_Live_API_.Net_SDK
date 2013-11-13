using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MYOB.AccountRight.SDK.Extensions
{
    /// <summary>
    /// Basic extensions for JSON related operations
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Convert an entiry to its JSON representation
        /// </summary>
        /// <param name="entity">The entity to convert</param>
        /// <returns>The JSON data</returns>
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

        /// <summary>
        /// Convert an entity from its JSON representation
        /// </summary>
        /// <typeparam name="T">The expected entity type</typeparam>
        /// <param name="data">The JSON data</param>
        /// <returns></returns>
        public static T FromJson<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
