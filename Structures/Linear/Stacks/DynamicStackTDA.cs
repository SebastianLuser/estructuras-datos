namespace Estructuras_de_Datos.Structures.Linear.Stack
{
    public class DynamicStackTDA<T> : IDynamicStackTDA<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
        
        private Node top;

        public bool Push(T item)
        {
            Node newNode = new Node(item);
            newNode.Next = top;
            top = newNode;
            
            return true;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("DynamicStack is empty");
            var item = top.Data;
            top = top.Next;
                
            return item;

        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public T Top()
        {
            if (!IsEmpty())
            {
                return top.Data;
            }
            
            throw new InvalidOperationException("DynamicStack is empty");
        }

        public void PrintStack()
        {
            Node current = top;
            while (current != null)
            {
                Console.WriteLine("Element: " + (current.Data != null ? current.Data.ToString() : "null"));
                current = current.Next;
            }
        }
    }
}
