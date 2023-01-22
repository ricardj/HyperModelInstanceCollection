using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HyperScriptables/New Globa References")]
public class GlobalReferencesSO : SingletonScriptableObject<GlobalReferencesSO>
{
    [SerializeField] List<SerializableScriptableObject> _serializableScriptables;

    public void AddScriptable(SerializableScriptableObject newSerializable)
    {
        if (!_serializableScriptables.Contains(newSerializable))
        {
            _serializableScriptables.Add(newSerializable);
        }
    }

    public SerializableScriptableObject GetScriptable(string guid)
    {
        return _serializableScriptables.Find(scriptable => scriptable.Guid == guid);
    }
}
