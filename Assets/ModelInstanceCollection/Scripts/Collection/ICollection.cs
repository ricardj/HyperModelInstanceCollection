namespace ModelInstanceCollection
{
    public interface ICollection
    {
        int GetCount();
        void AddItem<T>(T item);
        object GetUnique();
        void Clear();
    }
}