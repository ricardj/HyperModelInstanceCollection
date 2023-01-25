using System;
using UnityEngine;

namespace ModelInstanceCollection
{
    public abstract class IPersistencyManager : MonoBehaviour
    {
        public abstract string GetKey();
        public abstract object GetPersistentData();
        public abstract void SetPersistentData(object persistentData);

        public void LoadData()
        {
            PersistencyManager.get.LoadData(this);
        }
    }
}