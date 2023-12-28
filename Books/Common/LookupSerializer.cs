using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;

namespace Books.Common
{
    public class LookupSerializer : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var result = objectType.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ILookup<,>));
            return result;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var obj = new JObject();
            var enumerable = (IEnumerable)value!;

            foreach (object kvp in enumerable)
            {
                var keyProp = kvp.GetType().GetProperty("Key");
                var keyValue = keyProp!.GetValue(kvp, null);
                obj.Add(Convert.ToString(keyValue)!, JArray.FromObject((IEnumerable)kvp));
            }
            obj.WriteTo(writer);
        }
    }
}
