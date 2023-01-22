using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


[Serializable]
public class Instance<T> : IUniqueIdentified, IInstance
{

    public T _model;

    public Instance()
    {

    }

    public Instance(T model)
    {
        _model = model;
    }


    public T1 GetModel<T1>()
    {
        return (T1)(object)_model;
    }

    public void SetModel<T1>(T1 model)
    {
        this._model = (T)(object)model;
    }
}

public class IUniqueIdentified
{

    public string uid = "0";
    public string UID
    {
        get
        {
            if (uid == "0")
            {
                uid = Guid.NewGuid().ToString();
            }
            return uid;
        }
    }
}
