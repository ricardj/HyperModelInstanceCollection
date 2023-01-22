
using System;

public interface IInstance
{
    public T GetModel<T>();
    void SetModel<T>(T model);
}
