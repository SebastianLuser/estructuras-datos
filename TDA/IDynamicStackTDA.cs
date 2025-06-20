namespace TDA
{
    public interface IDynamicStackTDA<T>
    {
        bool Push(T item);
        T Pop();
        bool IsEmpty();
        T Top();
        void PrintStack();
    }
}