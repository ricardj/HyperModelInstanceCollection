using System;
using UnityEngine;
using Newtonsoft.Json;


using System.Reflection;
using UnityEditor;


public class InstanceSerializer : MonoBehaviour
{

    public string SerializeInstance<T>(T instance) where T : IInstance
    {
        string jsonString = JsonConvert.SerializeObject(instance);
        return jsonString;
    }

    public TInstance DeserializeInstance<TInstance, TModel>(string serializedInstance) where TInstance : IInstance
    {
        TInstance instance = JsonConvert.DeserializeObject<TInstance>(serializedInstance);
        return instance;
    }


}
