using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib.Converters
{
    class UserJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            objectType == typeof(User);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            return new User(reader.ReadAsInt32() ?? 0);
        }
        
        public override void WriteJson(
              JsonWriter writer,
              object value,
              JsonSerializer serializer)
        {
            writer.WriteValue(((User)value).Id);
        }
    }
}
