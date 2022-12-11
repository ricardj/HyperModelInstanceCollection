﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

#endif

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
