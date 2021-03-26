namespace TestePleno.Interfaces
{
    interface IController<T>
    {
        T Find(T Object);
        void List();
        void Remove(T toRemove);
        T Create();
    }
}
