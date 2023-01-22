using System;
using UnityEngine;

namespace ModelInstanceCollection
{
    public abstract class ModelSO<T> : SerializableScriptableObject, IModel
    {
        public abstract T GetInstance();

        public T SetupModel(T instance)
        {
            IInstance targetInstance = (IInstance)instance;
            targetInstance.SetModel(this);
            return instance;
        }

        public T1 SetupModel<T1>(T1 instance)
        {
            return SetupModel(instance);
        }

        object IModel.GetInstance()
        {
            return (object)GetInstance();
        }
    }
}