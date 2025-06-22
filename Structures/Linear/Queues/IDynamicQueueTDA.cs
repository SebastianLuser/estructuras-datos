namespace Estructuras_de_Datos.Structures.Linear.Queues
{
    public interface IDynamicQueueTDA<T>
    {
        bool Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
        T Front();
        void PrintQueue();
    }
    
}
