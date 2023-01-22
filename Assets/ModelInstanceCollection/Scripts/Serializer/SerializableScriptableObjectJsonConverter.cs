using Newtonsoft.Json;
using System;


//using UnityEditor;

public class SerializableScriptableObjectJsonConverter : JsonConverter<SerializableScriptableObject>
{
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
                if ((string)reader.Value == "GUID")
                {
                    reader.Read();
                    guid = (string)reader.Value;
                }
            }
        }
        SerializableScriptableObject serializedScriptable = GlobalReferencesSO.get.GetScriptable(guid);
        //string path = AssetDatabase.GUIDToAssetPath(guid);
        //SerializableScriptableObject serializedScriptable = AssetDatabase.LoadAssetAtPath<SerializableScriptableObject>(path);
        return serializedScriptable;


    }

    public override void WriteJson(JsonWriter writer, SerializableScriptableObject value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("GUID");
        writer.WriteValue(value.Guid);
        GlobalReferencesSO.get.AddScriptable(value);
        writer.WriteEndObject();
    }
}
