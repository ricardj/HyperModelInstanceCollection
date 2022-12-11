using UnityEngine;


public abstract class ModelSO<T> : SerializableScriptableObject
{
    public abstract T GetInstance();

    public T SetupModel(T instance)
    {
        if (instance is IInstance<ModelSO<T>>)
        {
            ((IInstance<ModelSO<T>>)instance).SetModel(this);
        }
        return instance;
    }
}
