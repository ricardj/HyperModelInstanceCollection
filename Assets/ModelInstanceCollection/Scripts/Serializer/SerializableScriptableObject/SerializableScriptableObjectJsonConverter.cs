using Newtonsoft.Json;
using System;



namespace ModelInstanceCollection
{
    public class SerializableScriptableObjectJsonConverter : JsonConverter<SerializableScriptableObject>
    {
        private const string GUID_PROPERTY_NAME = "GUID";

        public override SerializableScriptableObject ReadJson(JsonReader reader, Type objectType, SerializableScriptableObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string guid = "";

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    if ((string)reader.Value == GUID_PROPERTY_NAME)
                    {
                        reader.Read();
                        guid = (string)reader.Value;
                    }
                }
            }
            SerializableScriptableObject serializedScriptable = GlobalReferencesSO.get.GetScriptable(guid);

            return serializedScriptable;


        }

        public override void WriteJson(JsonWriter writer, SerializableScriptableObject value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(GUID_PROPERTY_NAME);
            writer.WriteValue(value.Guid);
            GlobalReferencesSO.get.AddScriptable(value);
            writer.WriteEndObject();
        }
    }
}