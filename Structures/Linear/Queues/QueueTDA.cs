namespace Estructuras_de_Datos.Structures.Linear.Queues
{
    public class QueueTDA<T> : IQueueTDA<T>
    {
        private T[] elements;
        private int maxCapacity;
        private int head;
        private int tail;
        
        public void InitializeQueue(int capacity)
        {
            maxCapacity = capacity;
            elements = new T[capacity];
            head = 0;
            tail = 0;
        }

        public bool Enqueue(T item)
        {
            if (tail >= maxCapacity)
            {
                if (head == 0) return false;
                
                for (int i = 0; i < tail - head; i++)
                {
                    elements[i] = elements[head + i];
                }
                
                tail = tail - head;
                head = 0;
            }
        
            elements[tail] = item;
            tail++;
            return true;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            
            T item = elements[head];
            head++;
            return item;
        }

        public bool IsEmpty()
        {
            return head == tail;
        }

        public bool IsFull()
        {
            return tail >= maxCapacity && head == 0;
        }
        
        public T Front()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
                
            return elements[head];
        }
        
        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            
            for (var i = head; i < tail; i++)
            {
                Console.WriteLine("Element: " + (elements[i] != null ? elements[i].ToString() : "null"));
            }
        }
    }
}