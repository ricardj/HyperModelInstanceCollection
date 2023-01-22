using System;
using UnityEngine;


public abstract class ModelSO<T> : SerializableScriptableObject
{
    public abstract T GetInstance();

    public T SetupModel(T instance) 
    {
        IInstance targetInstance = (IInstance)instance;
        targetInstance.SetModel(this);
        return instance;
    }
}
