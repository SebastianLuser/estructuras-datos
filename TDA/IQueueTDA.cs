namespace TDA
{
    public interface IQueueTDA<T>
    {
        void InitializeQueue(int capacity);
        bool Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
        bool IsFull();
        T Front();
        void PrintQueue();
    }
}