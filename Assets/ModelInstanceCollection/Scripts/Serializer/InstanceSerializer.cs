using UnityEngine;
using Newtonsoft.Json;

namespace ModelInstanceCollection
{
    public class InstanceSerializer
    {

        public static string SerializeInstance<T>(T instance) where T : IInstance
        {
            string jsonString = JsonConvert.SerializeObject(instance);
            return jsonString;
        }

        public static TInstance DeserializeInstance<TInstance, TModel>(string serializedInstance) where TInstance : IInstance
        {
            TInstance instance = JsonConvert.DeserializeObject<TInstance>(serializedInstance);
            return instance;
        }


    }
}