using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class InstanceSerializer : MonoBehaviour
{

    public string SerializeInstance<TInstance, TModel>(TInstance instance) where TInstance : IInstance<TModel> where TModel : SerializableScriptableObject
    {
        string jsonString = JsonConvert.SerializeObject(instance);
        return jsonString;
    }

    public TInstance DeserializeInstance<TInstance, TModel>(string serializedInstance) where TInstance : IInstance<TModel> where TModel : SerializableScriptableObject
    {
        TInstance instance = JsonConvert.DeserializeObject<TInstance>(serializedInstance);
        AsyncOperationHandle<TModel> operationHandle = Addressables.LoadAssetAsync<TModel>(instance.GetModel().Guid);
        operationHandle.WaitForCompletion();
        operationHandle.Completed += obj =>
        {
            instance.SetModel(obj.Result);
        };
        return instance;
    }


}
