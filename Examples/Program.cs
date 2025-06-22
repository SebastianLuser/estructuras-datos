using System;
using Estructuras_de_Datos.Examples.Demos;

namespace Estructuras_de_Datos.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎯 Iniciando Sistema de Demos TDA...\n");
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("📚 DEMOS DE ESTRUCTURAS DE DATOS TDA");
                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("📁 ESTRUCTURAS LINEALES:");
                Console.WriteLine("   1. Stack (Pila) - Static & Dynamic");
                Console.WriteLine("   2. Queue (Cola) - Static & Dynamic");
                Console.WriteLine();
                Console.WriteLine("🌳 ESTRUCTURAS JERÁRQUICAS:");
                Console.WriteLine("   3. Binary Search Tree (BST)");
                Console.WriteLine("   4. AVL Tree");
                Console.WriteLine();
                Console.WriteLine("🕸️  GRAFOS Y CONJUNTOS:");
                Console.WriteLine("   5. Graph (Grafo)");
                Console.WriteLine("   6. Set (Conjunto)");
                Console.WriteLine();
                Console.WriteLine("🔬 ALGORITMOS:");
                Console.WriteLine("   7. Dijkstra (Caminos Mínimos)");
                Console.WriteLine();
                Console.WriteLine("⚡ ACCESO RÁPIDO:");
                Console.WriteLine("   8. Demo Completo (Todas las estructuras)");
                Console.WriteLine("   9. Ejercicios de Parciales");
                Console.WriteLine();
                Console.WriteLine("   0. Salir");
                Console.WriteLine("══════════════════════════════════════");
                Console.Write("🎯 Seleccione una opción: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        LinearDemo.ShowStackMenu();
                        break;
                    case "2":
                        LinearDemo.ShowQueueMenu();
                        break;
                    case "3":
                        HierarchicalDemo.ShowBSTMenu();
                        break;
                    case "4":
                        HierarchicalDemo.ShowAVLMenu();
                        break;
                    case "5":
                        GraphDemo.ShowGraphMenu();
                        break;
                    case "6":
                        SetDemo.ShowSetMenu();
                        break;
                    case "7":
                        AlgorithmDemo.ShowDijkstraMenu();
                        break;
                    case "8":
                        CompleteDemo.RunFullDemo();
                        break;
                    case "9":
                        ExamDemo.ShowExamMenu();
                        break;
                    case "0":
                        Console.WriteLine("👋 ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presione cualquier tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
