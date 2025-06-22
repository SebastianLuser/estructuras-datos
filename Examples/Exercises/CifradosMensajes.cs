using System;
using System.Collections.Generic;
using TDA;
/*
namespace CifradorMensajes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Diccionarios para cifrar y descifrar
            Dictionary<char, char> cifradoDictionary = new Dictionary<char, char>
            {
                {'a', 'q'}, {'b', 'w'}, {'c', 'e'}, {'d', 'r'}, {'e', 't'},
                {'f', 'y'}, {'g', 'u'}, {'h', 'i'}, {'i', 'o'}, {'j', 'p'},
                {'k', 'a'}, {'l', 's'}, {'m', 'd'}, {'n', 'f'}, {'ñ', 'g'},
                {'o', 'h'}, {'p', 'j'}, {'q', 'k'}, {'r', 'l'}, {'s', 'z'},
                {'t', 'x'}, {'u', 'c'}, {'v', 'v'}, {'w', 'b'}, {'x', 'n'},
                {'y', 'm'}, {'z', '/'}, {' ', '.'}, {'.', ' '}
            };

            // Creamos el diccionario para descifrar invirtiendo las claves y valores del diccionario de cifrado
            Dictionary<char, char> descifradoDictionary = new Dictionary<char, char>();
            foreach (var par in cifradoDictionary)
            {
                descifradoDictionary[par.Value] = par.Key;
            }

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== CIFRADOR Y DESCIFRADOR DE MENSAJES =====");
                Console.WriteLine("1. Cifrar mensaje");
                Console.WriteLine("2. Descifrar mensaje");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        CifrarMensaje(cifradoDictionary);
                        break;
                    case "2":
                        DescifrarMensaje(descifradoDictionary);
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CifrarMensaje(Dictionary<char, char> cifradoDictionary)
        {
            Console.Clear();
            Console.WriteLine("===== CIFRAR MENSAJE =====");
            Console.Write("Ingrese el mensaje a cifrar: ");
            string mensaje = Console.ReadLine().ToLower();
            
            // Crear la cola y cargar cada caracter usando tu DynamicQueueTDA<T>
            DynamicQueueTDA<char> colaCaracteres = new DynamicQueueTDA<char>();
            foreach (char c in mensaje)
            {
                colaCaracteres.Enqueue(c);
            }
            
            // Procesar la cola y cifrar el mensaje
            string mensajeCifrado = "";
            while (!colaCaracteres.IsEmpty())
            {
                char caracterOriginal = colaCaracteres.Dequeue();
                if (cifradoDictionary.ContainsKey(caracterOriginal))
                {
                    mensajeCifrado += cifradoDictionary[caracterOriginal];
                }
                else
                {
                    // Si el caracter no está en el diccionario, lo dejamos igual
                    mensajeCifrado += caracterOriginal;
                }
            }
            
            Console.WriteLine($"Mensaje cifrado: {mensajeCifrado}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void DescifrarMensaje(Dictionary<char, char> descifradoDictionary)
        {
            Console.Clear();
            Console.WriteLine("===== DESCIFRAR MENSAJE =====");
            Console.Write("Ingrese el mensaje a descifrar: ");
            string mensajeCifrado = Console.ReadLine().ToLower();
            
            // Crear la cola y cargar cada caracter usando tu DynamicQueueTDA<T>
            DynamicQueueTDA<char> colaCaracteres = new DynamicQueueTDA<char>();
            foreach (char c in mensajeCifrado)
            {
                colaCaracteres.Enqueue(c);
            }
            
            // Procesar la cola y descifrar el mensaje
            string mensajeDescifrado = "";
            while (!colaCaracteres.IsEmpty())
            {
                char caracterCifrado = colaCaracteres.Dequeue();
                if (descifradoDictionary.ContainsKey(caracterCifrado))
                {
                    mensajeDescifrado += descifradoDictionary[caracterCifrado];
                }
                else
                {
                    // Si el caracter no está en el diccionario, lo dejamos igual
                    mensajeDescifrado += caracterCifrado;
                }
            }
            
            Console.WriteLine($"Mensaje descifrado: {mensajeDescifrado}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
*/