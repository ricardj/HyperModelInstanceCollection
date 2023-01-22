using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static UnityEditor.Progress;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

[JsonConverter(typeof(SerializableScriptableObjectJsonConverter))]
public class SerializableScriptableObject : ScriptableObject
{
    [SerializeField, ReadOnly] private string _guid;
    public string Guid
    {
        get { return _guid; }
        set { _guid = value; }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        var path = AssetDatabase.GetAssetPath(this);
        _guid = AssetDatabase.AssetPathToGUID(path);
    }
#endif
}
