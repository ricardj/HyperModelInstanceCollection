using ModelInstanceCollection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ResourcesPersistencyManager : IPersistencyManager
{
    [SerializeField] string _persistencyKey;
    public ResourcesPersistency _resourcesPersistency;
    [SerializeField] ResourceConfigurationInstancesCollection _instances;

    public override string GetKey()
    {
        return _persistencyKey;
    }

    public override object GetPersistentData()
    {
        _resourcesPersistency._resourceConfigurations = _instances.GetItems();
        return _resourcesPersistency;
    }

    public override void SetPersistentData(object persistentData)
    {

        _resourcesPersistency = (ResourcesPersistency)persistentData;
        _instances.CollectionList = _resourcesPersistency._resourceConfigurations;
    }


}

