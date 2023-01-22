using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ModelInstanceCollection
{
    [CreateAssetMenu(menuName = "HyperScriptables/New Globa References")]
    public class GlobalReferencesSO : SingletonScriptableObject<GlobalReferencesSO>
    {
        [SerializeField] List<SerializableScriptableObjectKeyValuePair> _serializableScriptables;
        [SerializeField] Dictionary<string, SerializableScriptableObject> _serializableScriptablesDictionary = new Dictionary<string, SerializableScriptableObject>();


        [Serializable]
        public class SerializableScriptableObjectKeyValuePair
        {
            public string guid;
            public SerializableScriptableObject reference;
        }



        public void OnValidate()
        {
            //_serializableScriptables = f
            RefreshList();
        }

        public void RefreshList()
        {
            foreach (var kvp in _serializableScriptables)
            {
                _serializableScriptablesDictionary[kvp.guid] = kvp.reference;
            }
        }

        public void AddScriptable(SerializableScriptableObject newSerializable)
        {
#if UNITY_EDITOR
            if (_serializableScriptables.Find(a => a.guid == newSerializable.Guid) == null)
            {
                _serializableScriptables.Add(new SerializableScriptableObjectKeyValuePair()
                {
                    guid = newSerializable.Guid,
                    reference = newSerializable
                });
            }

            if (!_serializableScriptablesDictionary.ContainsKey(newSerializable.Guid))
            {
                _serializableScriptablesDictionary[newSerializable.Guid] = newSerializable;
            }
#endif

        }

        public SerializableScriptableObject GetScriptable(string guid)
        {
            if (_serializableScriptablesDictionary.ContainsKey(guid))
                return _serializableScriptablesDictionary[guid];
            return null;
        }
    }
}