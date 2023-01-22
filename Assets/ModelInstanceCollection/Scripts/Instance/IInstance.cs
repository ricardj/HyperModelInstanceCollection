using System;

namespace ModelInstanceCollection
{
    public interface IInstance
    {        
        public IModel GetModel();
        void SetModel<T>(T model);
    }


}