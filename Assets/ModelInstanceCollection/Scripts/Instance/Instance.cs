using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace ModelInstanceCollection
{
    [Serializable]
    public class Instance<T> : IUniqueIdentified, IInstance
    {

        public T _model;

        public Instance()
        {
            InitializeUID();
        }

        public Instance(T model)
        {
            _model = model;
            InitializeUID();
        }


        public T GetModel()
        {
            return _model;
        }


        public T1 GetModel<T1>()
        {
            return (T1)(object)_model;
        }

        void IInstance.SetModel<T1>(T1 model)
        {
            this._model = (T)(object)model;
        }

        IModel IInstance.GetModel()
        {
            return (IModel)_model;
        }
    }
}