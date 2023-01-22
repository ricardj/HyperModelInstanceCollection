using System;

namespace ModelInstanceCollection
{
    public interface IInstance
    {
        public T GetModel<T>();
        void SetModel<T>(T model);
    }
}