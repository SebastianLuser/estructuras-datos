using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial
{
    public interface IDynamicQueue<T>
    {
        bool Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
    }
    
    public class DynamicQueue<T> : IDynamicQueue<T>
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
        
        private Node head;
        private Node tail;

        public bool Enqueue(T item)
        {
            Node newNode = new Node(item);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            return true;
        }
        
        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("DynamicQueue is empty");
            var item = head.Data;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            return item;
        }
        
        public bool IsEmpty()
        {
            return head == null;
        }
    }
    
    class Program
    {
        public static Dictionary<char, char> encryptDict = new Dictionary<char, char>();
        public static Dictionary<char, char> decryptDict = new Dictionary<char, char>();
        
        private static void LoadDictionaries()
        {
            encryptDict.Add('a', 'n');
            encryptDict.Add('b', 'o');
            encryptDict.Add('c', 'p');
            encryptDict.Add('d', 'q');
            encryptDict.Add('e', 'r');
            encryptDict.Add('f', 's');
            encryptDict.Add('g', 't');
            encryptDict.Add('h', 'u');
            encryptDict.Add('i', 'v');
            encryptDict.Add('j', 'w');
            encryptDict.Add('k', 'x');
            encryptDict.Add('l', 'y');
            encryptDict.Add('m', 'z');
            encryptDict.Add('n', 'a');
            encryptDict.Add('o', 'b');
            encryptDict.Add('p', 'c');
            encryptDict.Add('q', 'd');
            encryptDict.Add('r', 'e');
            encryptDict.Add('s', 'f');
            encryptDict.Add('t', 'g');
            encryptDict.Add('u', 'h');
            encryptDict.Add('v', 'i');
            encryptDict.Add('w', 'j');
            encryptDict.Add('x', 'k');
            encryptDict.Add('y', 'l');
            encryptDict.Add('z', 'm');
            encryptDict.Add(' ', '*');
            
            decryptDict.Add('n', 'a');
            decryptDict.Add('o', 'b');
            decryptDict.Add('p', 'c');
            decryptDict.Add('q', 'd');
            decryptDict.Add('r', 'e');
            decryptDict.Add('s', 'f');
            decryptDict.Add('t', 'g');
            decryptDict.Add('u', 'h');
            decryptDict.Add('v', 'i');
            decryptDict.Add('w', 'j');
            decryptDict.Add('x', 'k');
            decryptDict.Add('y', 'l');
            decryptDict.Add('z', 'm');
            decryptDict.Add('a', 'n');
            decryptDict.Add('b', 'o');
            decryptDict.Add('c', 'p');
            decryptDict.Add('d', 'q');
            decryptDict.Add('e', 'r');
            decryptDict.Add('f', 's');
            decryptDict.Add('g', 't');
            decryptDict.Add('h', 'u');
            decryptDict.Add('i', 'v');
            decryptDict.Add('j', 'w');
            decryptDict.Add('k', 'x');
            decryptDict.Add('l', 'y');
            decryptDict.Add('m', 'z');
            decryptDict.Add('*', ' ');
        }

        static DynamicQueue<char> Encrypt(DynamicQueue<char> input)
        {
            var output = new DynamicQueue<char>();
            var temp = new DynamicQueue<char>();
            
            while (!input.IsEmpty())
            {
                char c = input.Dequeue();
                temp.Enqueue(c);
                
                if (encryptDict.TryGetValue(c, out char encryptedChar))
                    output.Enqueue(encryptedChar);
                else
                    output.Enqueue(c);
            }
            
            while (!temp.IsEmpty())
                input.Enqueue(temp.Dequeue());
                
            return output;
        }

        static DynamicQueue<char> Decrypt(DynamicQueue<char> input)
        {
            var output = new DynamicQueue<char>();
            var temp = new DynamicQueue<char>();
            
            while (!input.IsEmpty())
            {
                char c = input.Dequeue();
                temp.Enqueue(c);
                
                if (decryptDict.TryGetValue(c, out char decryptedChar))
                    output.Enqueue(decryptedChar);
                else
                    output.Enqueue(c);
            }
            
            while (!temp.IsEmpty())
                input.Enqueue(temp.Dequeue());
                
            return output;
        }
        
        static string QueueToString(DynamicQueue<char> queue)
        {
            var temp = new DynamicQueue<char>();
            var sb = new StringBuilder();
            
            while (!queue.IsEmpty())
            {
                char c = queue.Dequeue();
                sb.Append(c);
                temp.Enqueue(c);
            }
            
            while (!temp.IsEmpty())
                queue.Enqueue(temp.Dequeue());
                
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            LoadDictionaries();

            Menu();
        }
        private static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== MESSAGE ENCRYPTOR AND DECRYPTOR =====");
                Console.WriteLine("1. Encrypt message");
                Console.WriteLine("2. Decrypt message");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                
                string option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        EncryptMessage();
                        break;
                    case "2":
                        DecryptMessage();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EncryptMessage()
        {
            Console.Clear();
            Console.WriteLine("===== ENCRYPT MESSAGE =====");
            Console.Write("Enter message to encrypt: ");
            string message = Console.ReadLine().ToLower();
            
            if (EmptyMessage(message)) return;
            
            DynamicQueue<char> charQueue = new DynamicQueue<char>();
            foreach (char c in message)
            {
                charQueue.Enqueue(c);
            }
            
            DynamicQueue<char> encryptedQueue = Encrypt(charQueue);
            
            string encryptedMessage = QueueToString(encryptedQueue);
            
            Console.WriteLine($"Encrypted message: {encryptedMessage}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void DecryptMessage()
        {
            Console.Clear();
            Console.WriteLine("===== DECRYPT MESSAGE =====");
            Console.Write("Enter message to decrypt: ");
            string encryptedMessage = Console.ReadLine().ToLower();
            
            if (EmptyMessage(encryptedMessage)) return;
            
            DynamicQueue<char> charQueue = new DynamicQueue<char>();
            foreach (char c in encryptedMessage)
            {
                charQueue.Enqueue(c);
            }
            
            DynamicQueue<char> decryptedQueue = Decrypt(charQueue);
            
            string decryptedMessage = QueueToString(decryptedQueue);
            
            Console.WriteLine($"Decrypted message: {decryptedMessage}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static bool EmptyMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Message cannot be empty. Press any key to continue...");
                Console.ReadKey();
                return true;
            }

            return false;
        }
    }
}