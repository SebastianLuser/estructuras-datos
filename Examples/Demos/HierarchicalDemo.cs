using Estructuras_de_Datos.Structures.Hierarchical;

namespace Estructuras_de_Datos.Examples.Demos
{
    public static class HierarchicalDemo
    {
        public static void ShowBSTMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("🌳 BINARY SEARCH TREE (BST) - DEMOS");
                Console.WriteLine("════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("📝 DEMOS DISPONIBLES:");
                Console.WriteLine("   1. Demo Básico (Números)");
                Console.WriteLine("   2. Demo con Strings");
                Console.WriteLine("   3. Demo Interactivo");
                Console.WriteLine("   4. Análisis de Complejidad");
                Console.WriteLine("   5. Comparación BST vs Lista");
                Console.WriteLine();
                Console.WriteLine("🎯 EJERCICIOS TÍPICOS:");
                Console.WriteLine("   6. Sistema de Calificaciones");
                Console.WriteLine("   7. Diccionario de Palabras");
                Console.WriteLine("   8. Árbol de Decisiones");
                Console.WriteLine();
                Console.WriteLine("   0. ← Volver al menú principal");
                Console.WriteLine("════════════════════════════════════");
                Console.Write("🎯 Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunBasicBSTDemo();
                        break;
                    case "2":
                        RunStringBSTDemo();
                        break;
                    case "3":
                        RunInteractiveBSTDemo();
                        break;
                    case "4":
                        RunComplexityAnalysis();
                        break;
                    case "5":
                        RunBSTvsListComparison();
                        break;
                    case "6":
                        RunGradesSystemDemo();
                        break;
                    case "7":
                        RunDictionaryDemo();
                        break;
                    case "8":
                        RunDecisionTreeDemo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void ShowAVLMenu()
        {
            Console.Clear();
            Console.WriteLine("🌳 AVL TREE - DEMOS");
            Console.WriteLine("═══════════════════");
            Console.WriteLine("(Implementación similar al BST pero con auto-balanceado)");
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        private static void RunBasicBSTDemo()
        {
            Console.Clear();
            Console.WriteLine("🌳 DEMO BÁSICO - BST CON NÚMEROS");
            Console.WriteLine("═══════════════════════════════════");

            var bst = new BinarySearchTree<int>();

            Console.WriteLine("\n📥 Insertando números: 50, 30, 70, 20, 40, 60, 80");
            int[] numbers = { 50, 30, 70, 20, 40, 60, 80 };

            foreach (int num in numbers)
            {
                bst.Insert(num);
                Console.WriteLine($"   ✅ Insertado: {num}");
                System.Threading.Thread.Sleep(200);
            }

            Console.WriteLine("\n🏗️ ESTRUCTURA DEL ÁRBOL:");
            bst.DisplayTree();

            Console.WriteLine("\n📊 RECORRIDOS:");
            Console.Write("   InOrder (ordenado): ");
            bst.InOrder();
            Console.Write("   PreOrder: ");
            bst.PreOrder();
            Console.Write("   PostOrder: ");
            bst.PostOrder();

            Console.WriteLine("\n📈 ESTADÍSTICAS:");
            Console.WriteLine($"   • Nodos: {bst.CountNodes()}");
            Console.WriteLine($"   • Altura: {bst.Height()}");
            Console.WriteLine($"   • Mínimo: {bst.FindMinimum()}");
            Console.WriteLine($"   • Máximo: {bst.FindMaximum()}");
            Console.WriteLine($"   • ¿Está balanceado? {(bst.IsBalanced() ? "✅ Sí" : "❌ No")}");

            Console.WriteLine("\n🔍 BÚSQUEDAS:");
            int[] searchNumbers = { 40, 25, 80, 100 };
            foreach (int num in searchNumbers)
            {
                bool found = bst.Search(num);
                Console.WriteLine($"   Buscar {num}: {(found ? "✅ Encontrado" : "❌ No encontrado")}");
            }

            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine("✨ Demo completado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void RunStringBSTDemo()
        {
            Console.Clear();
            Console.WriteLine("📝 BST CON STRINGS - DEMO");
            Console.WriteLine("═══════════════════════════");

            var stringBST = new BinarySearchTree<string>();

            Console.WriteLine("\n📚 Insertando nombres en el árbol...");
            string[] names = { "María", "Carlos", "Ana", "Pedro", "Lucía", "Diego", "Beatriz" };

            foreach (string name in names)
            {
                stringBST.Insert(name);
                Console.WriteLine($"   ✅ Agregado: {name}");
            }

            Console.WriteLine("\n🏗️ ESTRUCTURA DEL ÁRBOL:");
            stringBST.DisplayTree();

            Console.WriteLine("\n📊 Nombres en orden alfabético:");
            Console.Write("   ");
            stringBST.InOrder();

            Console.WriteLine("\n🔍 BÚSQUEDAS:");
            string[] searchNames = { "Ana", "Roberto", "María", "Zoe" };
            foreach (string name in searchNames)
            {
                bool found = stringBST.Search(name);
                Console.WriteLine($"   Buscar '{name}': {(found ? "✅ Encontrado" : "❌ No encontrado")}");
            }

            PauseForUser();
        }

        private static void RunInteractiveBSTDemo()
        {
            Console.Clear();
            Console.WriteLine("🎮 DEMO INTERACTIVO - BST");
            Console.WriteLine("═══════════════════════════════");

            var bst = new BinarySearchTree<int>();

            while (true)
            {
                Console.WriteLine("\n🎯 OPCIONES DISPONIBLES:");
                Console.WriteLine("   1. Insertar número");
                Console.WriteLine("   2. Buscar número");
                Console.WriteLine("   3. Eliminar número");
                Console.WriteLine("   4. Mostrar árbol");
                Console.WriteLine("   5. Mostrar estadísticas");
                Console.WriteLine("   6. Limpiar árbol");
                Console.WriteLine("   0. Salir");
                Console.Write("\n🎯 Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        InsertNumberToBST(bst);
                        break;
                    case "2":
                        SearchNumberInBST(bst);
                        break;
                    case "3":
                        RemoveNumberFromBST(bst);
                        break;
                    case "4":
                        DisplayBSTStructure(bst);
                        break;
                    case "5":
                        ShowBSTStatistics(bst);
                        break;
                    case "6":
                        bst = new BinarySearchTree<int>();
                        Console.WriteLine("🧹 Árbol limpiado correctamente");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Opción no válida");
                        break;
                }
            }
        }

        private static void RunComplexityAnalysis()
        {
            Console.Clear();
            Console.WriteLine("⚡ ANÁLISIS DE COMPLEJIDAD - BST");
            Console.WriteLine("═══════════════════════════════════");

            ShowTheoreticalComplexity();
            DemonstrateBalancedCase();
            DemonstrateDegenerateCase();
            ShowConclusions();

            PauseForUser();
        }

        private static void RunBSTvsListComparison()
        {
            Console.Clear();
            Console.WriteLine("⚔️ BST vs LISTA - COMPARACIÓN");
            Console.WriteLine("═══════════════════════════════");

            ShowPerformanceComparison();
            ShowUseCaseRecommendations();

            PauseForUser();
        }

        private static void RunGradesSystemDemo()
        {
            Console.Clear();
            Console.WriteLine("🎓 SISTEMA DE CALIFICACIONES CON BST");
            Console.WriteLine("═══════════════════════════════════════");

            var gradesBST = new BinarySearchTree<int>();
            int[] grades = { 85, 92, 78, 95, 88, 76, 91, 83, 87, 94 };

            InsertGrades(gradesBST, grades);
            AnalyzeGrades(gradesBST);
            SearchSpecificGrades(gradesBST);

            PauseForUser();
        }

        private static void RunDictionaryDemo()
        {
            Console.Clear();
            Console.WriteLine("📖 DICCIONARIO DE PALABRAS - BST");
            Console.WriteLine("═══════════════════════════════════");

            var dictionary = new BinarySearchTree<string>();
            string[] words = { 
                "algoritmo", "estructura", "datos", "árbol", "nodo",
                "búsqueda", "inserción", "eliminación", "recorrido",
                "balanceado", "complejidad", "eficiencia"
            };

            BuildDictionary(dictionary, words);
            TestWordLookup(dictionary);

            PauseForUser();
        }

        private static void RunDecisionTreeDemo()
        {
            Console.Clear();
            Console.WriteLine("🤔 ÁRBOL DE DECISIONES - DEMO");
            Console.WriteLine("═══════════════════════════════");

            var movieRatings = new BinarySearchTree<int>();
            int[] ratings = { 85, 92, 78, 95, 73, 88, 91, 67, 96, 82 };

            BuildMovieRatingSystem(movieRatings, ratings);
            AnalyzeMovieRatings(movieRatings);
            GenerateRecommendations(movieRatings);

            PauseForUser();
        }
        private static void PauseForUser()
        {
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine("✨ Demo completado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void InsertNumberToBST(BinarySearchTree<int> bst)
        {
            Console.Write("📥 Número a insertar: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                bst.Insert(num);
                Console.WriteLine($"✅ {num} insertado correctamente");
            }
            else
            {
                Console.WriteLine("❌ Número inválido");
            }
        }

        private static void SearchNumberInBST(BinarySearchTree<int> bst)
        {
            Console.Write("🔍 Número a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                bool found = bst.Search(num);
                Console.WriteLine(found ? 
                    $"✅ {num} encontrado en el árbol" : 
                    $"❌ {num} no se encuentra en el árbol");
            }
        }

        private static void RemoveNumberFromBST(BinarySearchTree<int> bst)
        {
            Console.Write("🗑️ Número a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                bool removed = bst.Remove(num);
                Console.WriteLine(removed ? 
                    $"✅ {num} eliminado correctamente" : 
                    $"❌ {num} no se encuentra en el árbol");
            }
        }

        private static void DisplayBSTStructure(BinarySearchTree<int> bst)
        {
            if (bst.IsEmpty())
            {
                Console.WriteLine("🔄 El árbol está vacío");
            }
            else
            {
                Console.WriteLine("\n🌳 ESTRUCTURA ACTUAL:");
                bst.DisplayTree();
            }
        }

        private static void ShowBSTStatistics(BinarySearchTree<int> bst)
        {
            if (bst.IsEmpty())
            {
                Console.WriteLine("🔄 El árbol está vacío - No hay estadísticas");
            }
            else
            {
                Console.WriteLine("\n📊 ESTADÍSTICAS ACTUALES:");
                Console.WriteLine($"   • Nodos: {bst.CountNodes()}");
                Console.WriteLine($"   • Altura: {bst.Height()}");
                Console.WriteLine($"   • Mínimo: {bst.FindMinimum()}");
                Console.WriteLine($"   • Máximo: {bst.FindMaximum()}");
                Console.WriteLine($"   • ¿Balanceado? {(bst.IsBalanced() ? "✅" : "❌")}");
            }
        }

        private static void ShowTheoreticalComplexity()
        {
            Console.WriteLine("\n📊 COMPLEJIDADES TEÓRICAS:");
            Console.WriteLine("   ┌─────────────┬──────────┬───────────┐");
            Console.WriteLine("   │ Operación   │ Promedio │ Peor Caso │");
            Console.WriteLine("   ├─────────────┼──────────┼───────────┤");
            Console.WriteLine("   │ Búsqueda    │ O(log n) │ O(n)      │");
            Console.WriteLine("   │ Inserción   │ O(log n) │ O(n)      │");
            Console.WriteLine("   │ Eliminación │ O(log n) │ O(n)      │");
            Console.WriteLine("   └─────────────┴──────────┴───────────┘");
        }

        private static void DemonstrateBalancedCase()
        {
            Console.WriteLine("\n1️⃣ Árbol Balanceado (mejor caso):");
            var bst = new BinarySearchTree<int>();
            int[] balancedData = { 50, 25, 75, 12, 37, 62, 87 };
            
            foreach (int num in balancedData)
                bst.Insert(num);

            Console.WriteLine($"   • Altura: {bst.Height()}");
            Console.WriteLine($"   • ¿Balanceado? {(bst.IsBalanced() ? "✅" : "❌")}");
            Console.WriteLine("   • Estructura:");
            bst.DisplayTree();
        }

        private static void DemonstrateDegenerateCase()
        {
            Console.WriteLine("\n2️⃣ Árbol Degenerado (peor caso):");
            var degenerateBST = new BinarySearchTree<int>();
            int[] degenerateData = { 1, 2, 3, 4, 5, 6, 7 };
            
            foreach (int num in degenerateData)
                degenerateBST.Insert(num);

            Console.WriteLine($"   • Altura: {degenerateBST.Height()}");
            Console.WriteLine($"   • ¿Balanceado? {(degenerateBST.IsBalanced() ? "✅" : "❌")}");
            Console.WriteLine("   • Estructura (como lista enlazada):");
            degenerateBST.DisplayTree();
        }

        private static void ShowConclusions()
        {
            Console.WriteLine("\n💡 CONCLUSIÓN:");
            Console.WriteLine("   • BST balanceado: Excelente performance O(log n)");
            Console.WriteLine("   • BST degenerado: Performance degradada O(n)");
            Console.WriteLine("   • Solución: Usar AVL Tree para auto-balanceado");
        }

        private static void ShowPerformanceComparison()
        {
            Console.WriteLine("\n🎯 Comparando búsqueda en 1000 elementos...");
            Console.WriteLine("\n📊 RESULTADOS SIMULADOS:");
            Console.WriteLine("   ┌─────────────────┬─────────────┬──────────────┐");
            Console.WriteLine("   │ Estructura      │ Búsquedas   │ Tiempo Aprox │");
            Console.WriteLine("   ├─────────────────┼─────────────┼──────────────┤");
            Console.WriteLine("   │ Lista           │ 500 pasos   │ ~50ms        │");
            Console.WriteLine("   │ BST Balanceado  │ 10 pasos    │ ~1ms         │");
            Console.WriteLine("   │ BST Degenerado  │ 500 pasos   │ ~50ms        │");
            Console.WriteLine("   └─────────────────┴─────────────┴──────────────┘");
        }

        private static void ShowUseCaseRecommendations()
        {
            Console.WriteLine("\n💡 CUÁNDO USAR CADA UNA:");
            Console.WriteLine("   🌳 BST:");
            Console.WriteLine("      ✅ Búsquedas frecuentes");
            Console.WriteLine("      ✅ Datos ordenados automáticamente");
            Console.WriteLine("      ✅ Inserciones/eliminaciones dinámicas");
            Console.WriteLine("      ❌ Datos ya ordenados (degeneración)");

            Console.WriteLine("\n   📋 Lista:");
            Console.WriteLine("      ✅ Acceso por índice");
            Console.WriteLine("      ✅ Datos secuenciales");
            Console.WriteLine("      ✅ Simplicidad de implementación");
            Console.WriteLine("      ❌ Búsquedas lentas");
        }

        private static void InsertGrades(BinarySearchTree<int> bst, int[] grades)
        {
            Console.WriteLine("\n📊 Insertando calificaciones de estudiantes...");
            foreach (int grade in grades)
            {
                bst.Insert(grade);
                Console.WriteLine($"   📝 Calificación registrada: {grade}");
            }
        }

        private static void AnalyzeGrades(BinarySearchTree<int> bst)
        {
            Console.WriteLine("\n📈 ANÁLISIS DE CALIFICACIONES:");
            Console.WriteLine($"   • Total de calificaciones: {bst.CountNodes()}");
            Console.WriteLine($"   • Calificación más baja: {bst.FindMinimum()}");
            Console.WriteLine($"   • Calificación más alta: {bst.FindMaximum()}");

            Console.WriteLine("\n📊 Calificaciones ordenadas (de menor a mayor):");
            Console.Write("   ");
            bst.InOrder();
        }

        private static void SearchSpecificGrades(BinarySearchTree<int> bst)
        {
            Console.WriteLine("\n🎯 Búsqueda de calificaciones específicas:");
            int[] searchGrades = { 90, 85, 100, 75 };
            foreach (int grade in searchGrades)
            {
                bool exists = bst.Search(grade);
                Console.WriteLine($"   ¿Hay estudiantes con {grade}? {(exists ? "✅ Sí" : "❌ No")}");
            }
        }

        private static void BuildDictionary(BinarySearchTree<string> dictionary, string[] words)
        {
            Console.WriteLine("\n📚 Construyendo diccionario...");
            foreach (string word in words)
            {
                dictionary.Insert(word);
                Console.WriteLine($"   📝 Palabra agregada: {word}");
            }

            Console.WriteLine("\n📖 Diccionario completo (orden alfabético):");
            Console.Write("   ");
            dictionary.InOrder();
        }

        private static void TestWordLookup(BinarySearchTree<string> dictionary)
        {
            Console.WriteLine("\n🔍 Verificador de palabras:");
            string[] testWords = { "algoritmo", "programación", "datos", "python", "nodo" };

            foreach (string word in testWords)
            {
                bool exists = dictionary.Search(word);
                Console.WriteLine($"   '{word}': {(exists ? "✅ En el diccionario" : "❌ No encontrada")}");
            }

            Console.WriteLine($"\n📊 Total de palabras en el diccionario: {dictionary.CountNodes()}");
        }

        private static void BuildMovieRatingSystem(BinarySearchTree<int> movieRatings, int[] ratings)
        {
            Console.WriteLine("\n🎯 Simulando sistema de recomendación de películas");
            Console.WriteLine("    basado en puntuaciones de usuarios...");

            Console.WriteLine("\n⭐ Insertando puntuaciones de películas (1-100):");
            foreach (int rating in ratings)
            {
                movieRatings.Insert(rating);
                Console.WriteLine($"   🎬 Película con puntuación: {rating}");
            }
        }

        private static void AnalyzeMovieRatings(BinarySearchTree<int> movieRatings)
        {
            Console.WriteLine("\n🏆 ANÁLISIS DE PELÍCULAS:");
            Console.WriteLine($"   • Mejor puntuación: {movieRatings.FindMaximum()}");
            Console.WriteLine($"   • Peor puntuación: {movieRatings.FindMinimum()}");

            Console.WriteLine("\n📊 Todas las puntuaciones ordenadas:");
            Console.Write("   ");
            movieRatings.InOrder();
        }

        private static void GenerateRecommendations(BinarySearchTree<int> movieRatings)
        {
            Console.WriteLine("\n🎯 SISTEMA DE RECOMENDACIÓN:");
            Console.WriteLine("   • Puntuación ≥ 90: ⭐⭐⭐ Altamente recomendada");
            Console.WriteLine("   • Puntuación 80-89: ⭐⭐ Recomendada");
            Console.WriteLine("   • Puntuación 70-79: ⭐ Aceptable");
            Console.WriteLine("   • Puntuación < 70: ❌ No recomendada");

            var sortedRatings = movieRatings.GetSortedElements();
            Console.WriteLine("\n🎬 RECOMENDACIONES FINALES:");

            foreach (int rating in sortedRatings)
            {
                string recommendation = rating >= 90 ? "⭐⭐⭐ Altamente recomendada" :
                                      rating >= 80 ? "⭐⭐ Recomendada" :
                                      rating >= 70 ? "⭐ Aceptable" :
                                      "❌ No recomendada";

                Console.WriteLine($"   Película ({rating} pts): {recommendation}");
            }
        }
    }
}