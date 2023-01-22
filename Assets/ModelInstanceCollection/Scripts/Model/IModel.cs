namespace ModelInstanceCollection
{
    public interface IModel
    {
        object GetInstance();
        public T SetupModel<T>(T instance);
    }
}