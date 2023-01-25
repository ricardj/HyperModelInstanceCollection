using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModelInstanceCollection
{
    public class PersistencyManager : Singleton<PersistencyManager>
    {
        private const string _globalKey = "GlobalKey";
        public Dictionary<string, object> globalData = new Dictionary<string, object>();

        public List<IPersistencyManager> _persistentManagers;

        public void SaveAll()
        {
            _persistentManagers.ForEach(persistentManager =>
            {
                globalData[persistentManager.GetKey()] = persistentManager.GetPersistentData();
            });
            string result = JsonConvert.SerializeObject(globalData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            PlayerPrefs.SetString(_globalKey, result);

        }

        public void LoadAll()
        {
            string result = PlayerPrefs.GetString(_globalKey);

            globalData = JsonConvert.DeserializeObject<Dictionary<string, object>>(result, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            _persistentManagers.ForEach(persistentManager =>
            {
                LoadData(persistentManager);
            });
        }

        public void LoadData(IPersistencyManager persistentManager)
        {
            persistentManager.SetPersistentData(globalData[persistentManager.GetKey()]);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SaveAll();
            }

            if (Input.GetKey(KeyCode.L))
            {
                LoadAll();
            }
        }


    }
}