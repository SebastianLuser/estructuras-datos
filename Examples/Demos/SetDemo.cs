using Estructuras_de_Datos.Structures.Sets;

namespace Estructuras_de_Datos.Examples.Demos
{
    public static class SetDemo
    {
        public static void ShowSetMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("🔢 SET (CONJUNTO) - DEMOS");
                Console.WriteLine("═════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("📝 DEMOS DISPONIBLES:");
                Console.WriteLine("   1. Demo Básico (Números)");
                Console.WriteLine("   2. Demo con Strings");
                Console.WriteLine("   3. Operaciones de Conjuntos");
                Console.WriteLine("   4. Demo Interactivo");
                Console.WriteLine();
                Console.WriteLine("🎯 CASOS DE USO:");
                Console.WriteLine("   5. Lista de Estudiantes");
                Console.WriteLine("   6. Inventario de Productos");
                Console.WriteLine("   7. Tags y Categorías");
                Console.WriteLine("   8. Análisis de Datos");
                Console.WriteLine();
                Console.WriteLine("🔬 COMPARACIONES:");
                Console.WriteLine("   9. Set vs Lista");
                Console.WriteLine("   10. Static vs Dynamic Set");
                Console.WriteLine();
                Console.WriteLine("   0. ← Volver al menú principal");
                Console.WriteLine("═════════════════════════════════");
                Console.Write("🎯 Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunBasicSetDemo();
                        break;
                    case "2":
                        RunStringSetDemo();
                        break;
                    case "3":
                        RunSetOperationsDemo();
                        break;
                    case "4":
                        RunInteractiveSetDemo();
                        break;
                    case "5":
                        RunStudentListDemo();
                        break;
                    case "6":
                        RunInventoryDemo();
                        break;
                    case "7":
                        RunTagsDemo();
                        break;
                    case "8":
                        RunDataAnalysisDemo();
                        break;
                    case "9":
                        RunSetVsListDemo();
                        break;
                    case "10":
                        RunStaticVsDynamicDemo();
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
        private static void RunBasicSetDemo()
        {
            Console.Clear();
            Console.WriteLine("🔢 DEMO BÁSICO - SET CON NÚMEROS");
            Console.WriteLine("════════════════════════════════════");

            var numberSet = new DynamicSet<int>();

            Console.WriteLine("\n📥 Agregando números al conjunto...");
            int[] numbers = { 5, 3, 8, 3, 1, 8, 7, 5, 2 };
            
            foreach (int num in numbers)
            {
                bool added = !numberSet.Contains(num);
                numberSet.Add(num);
                Console.WriteLine($"   {(added ? "✅" : "⚠️")} Intentando agregar: {num} {(added ? "" : "(ya existe)")}");
                System.Threading.Thread.Sleep(300);
            }

            Console.WriteLine("\n📊 INFORMACIÓN DEL CONJUNTO:");
            Console.WriteLine($"   • Elementos únicos: {numberSet.Count()}");
            Console.WriteLine($"   • ¿Está vacío? {(numberSet.IsEmpty() ? "Sí" : "No")}");
            Console.WriteLine($"   • Contenido: [{string.Join(", ", numberSet.ToList())}]");

            Console.WriteLine("\n🔍 BÚSQUEDAS:");
            int[] searchNumbers = { 3, 9, 7, 15 };
            foreach (int num in searchNumbers)
            {
                bool found = numberSet.Contains(num);
                Console.WriteLine($"   Buscar {num}: {(found ? "✅ Encontrado" : "❌ No encontrado")}");
            }

            Console.WriteLine("\n🗑️ ELIMINACIONES:");
            int[] removeNumbers = { 3, 10, 8 };
            foreach (int num in removeNumbers)
            {
                bool removed = numberSet.Remove(num);
                Console.WriteLine($"   Eliminar {num}: {(removed ? "✅ Eliminado" : "❌ No existía")}");
            }

            Console.WriteLine($"\n📊 Conjunto final: [{string.Join(", ", numberSet.ToList())}]");
            Console.WriteLine($"   Elementos restantes: {numberSet.Count()}");

            PauseForUser();
        }

        private static void RunStringSetDemo()
        {
            Console.Clear();
            Console.WriteLine("📝 DEMO SET CON STRINGS");
            Console.WriteLine("══════════════════════════");

            var fruitSet = new DynamicSet<string>();

            Console.WriteLine("\n🍎 Agregando frutas al conjunto...");
            string[] fruits = { "Manzana", "Banana", "Naranja", "manzana", "Pera", "Banana", "Kiwi" };
            
            foreach (string fruit in fruits)
            {
                bool added = !fruitSet.Contains(fruit);
                fruitSet.Add(fruit);
                string status = added ? "Nueva" : "Duplicada";
                Console.WriteLine($"   {(added ? "✅" : "⚠️")} {fruit} - {status}");
            }

            Console.WriteLine("\n📊 ANÁLISIS DEL CONJUNTO:");
            Console.WriteLine($"   • Frutas únicas: {fruitSet.Count()}");
            Console.WriteLine($"   • Lista completa: {string.Join(", ", fruitSet.ToList())}");

            Console.WriteLine("\n🔍 VERIFICACIONES:");
            string[] checkFruits = { "Manzana", "manzana", "Uva", "Pera" };
            foreach (string fruit in checkFruits)
            {
                bool exists = fruitSet.Contains(fruit);
                Console.WriteLine($"   ¿Contiene '{fruit}'? {(exists ? "✅ Sí" : "❌ No")}");
            }

            Console.WriteLine("\n🎲 ELEMENTO ALEATORIO:");
            if (!fruitSet.IsEmpty())
            {
                string randomFruit = fruitSet.GetAny();
                Console.WriteLine($"   Fruta seleccionada: {randomFruit}");
            }

            PauseForUser();
        }

        private static void RunSetOperationsDemo()
        {
            Console.Clear();
            Console.WriteLine("⚙️ DEMO OPERACIONES DE CONJUNTOS");
            Console.WriteLine("═══════════════════════════════════");

            Console.WriteLine("\n🔧 Creando conjuntos de ejemplo...");
            
            var setA = new DynamicSet<int>();
            var setB = new DynamicSet<int>();

            int[] elementsA = { 1, 2, 3, 4, 5 };
            foreach (int num in elementsA)
                setA.Add(num);

            int[] elementsB = { 4, 5, 6, 7, 8 };
            foreach (int num in elementsB)
                setB.Add(num);

            Console.WriteLine($"   Conjunto A: {{{string.Join(", ", setA.ToList())}}}");
            Console.WriteLine($"   Conjunto B: {{{string.Join(", ", setB.ToList())}}}");

            Console.WriteLine("\n🔗 OPERACIONES DE CONJUNTOS:");

            var union = setA.Union(setB);
            Console.WriteLine($"   A ∪ B (Unión): {{{string.Join(", ", union.ToList())}}}");

            var intersection = setA.Intersection(setB);
            Console.WriteLine($"   A ∩ B (Intersección): {{{string.Join(", ", intersection.ToList())}}}");

            var differenceAB = setA.Difference(setB);
            Console.WriteLine($"   A - B (Diferencia): {{{string.Join(", ", differenceAB.ToList())}}}");

            var differenceBA = setB.Difference(setA);
            Console.WriteLine($"   B - A (Diferencia): {{{string.Join(", ", differenceBA.ToList())}}}");

            Console.WriteLine("\n📊 ANÁLISIS DE RELACIONES:");
            
            var setC = new DynamicSet<int>();
            int[] elementsC = { 2, 3 };
            foreach (int num in elementsC)
                setC.Add(num);

            Console.WriteLine($"   Conjunto C: {{{string.Join(", ", setC.ToList())}}}");
            Console.WriteLine($"   ¿C ⊆ A? (C es subconjunto de A): {(setC.IsSubsetOf(setA) ? "✅ Sí" : "❌ No")}");
            Console.WriteLine($"   ¿A ⊆ C? (A es subconjunto de C): {(setA.IsSubsetOf(setC) ? "✅ Sí" : "❌ No")}");

            DemonstrateSetProperties(setA, setB);

            PauseForUser();
        }

        private static void RunInteractiveSetDemo()
        {
            Console.Clear();
            Console.WriteLine("🎮 DEMO INTERACTIVO - SET");
            Console.WriteLine("═══════════════════════════");

            var set = new DynamicSet<string>();

            while (true)
            {
                Console.WriteLine("\n🎯 OPCIONES DISPONIBLES:");
                Console.WriteLine("   1. Agregar elemento");
                Console.WriteLine("   2. Eliminar elemento");
                Console.WriteLine("   3. Buscar elemento");
                Console.WriteLine("   4. Mostrar conjunto");
                Console.WriteLine("   5. Obtener elemento aleatorio");
                Console.WriteLine("   6. Mostrar estadísticas");
                Console.WriteLine("   7. Limpiar conjunto");
                Console.WriteLine("   8. Operaciones con otro conjunto");
                Console.WriteLine("   0. Salir");
                Console.Write("\n🎯 Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddElementInteractive(set);
                        break;
                    case "2":
                        RemoveElementInteractive(set);
                        break;
                    case "3":
                        SearchElementInteractive(set);
                        break;
                    case "4":
                        DisplaySetContents(set);
                        break;
                    case "5":
                        GetRandomElement(set);
                        break;
                    case "6":
                        ShowSetStatistics(set);
                        break;
                    case "7":
                        set.Clear();
                        Console.WriteLine("🧹 Conjunto limpiado correctamente");
                        break;
                    case "8":
                        PerformSetOperationsInteractive(set);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Opción no válida");
                        break;
                }
            }
        }

        private static void RunStudentListDemo()
        {
            Console.Clear();
            Console.WriteLine("🎓 DEMO LISTA DE ESTUDIANTES");
            Console.WriteLine("═══════════════════════════════");

            var enrolledStudents = new DynamicSet<string>();
            var attendedStudents = new DynamicSet<string>();

            Console.WriteLine("\n📝 Simulando inscripciones...");
            string[] inscriptions = { "Ana García", "Carlos López", "María Rodríguez", "Ana García", "Pedro Martín", "Carlos López", "Lucía Fernández" };
            
            foreach (string student in inscriptions)
            {
                bool wasNew = !enrolledStudents.Contains(student);
                enrolledStudents.Add(student);
                Console.WriteLine($"   {(wasNew ? "✅" : "⚠️")} {student} {(wasNew ? "inscrito" : "ya estaba inscrito")}");
            }

            Console.WriteLine("\n📊 ESTADÍSTICAS DE INSCRIPCIÓN:");
            Console.WriteLine($"   • Total de estudiantes únicos: {enrolledStudents.Count()}");
            Console.WriteLine($"   • Lista de inscritos: {string.Join(", ", enrolledStudents.ToList())}");

            Console.WriteLine("\n🏫 Simulando asistencia a clase...");
            string[] attendance = { "Ana García", "María Rodríguez", "Pedro Martín", "Sofía Morales" };
            
            foreach (string student in attendance)
            {
                attendedStudents.Add(student);
                bool isEnrolled = enrolledStudents.Contains(student);
                Console.WriteLine($"   {(isEnrolled ? "✅" : "❓")} {student} {(isEnrolled ? "asistió" : "asistió (no inscrito)")}");
            }

            Console.WriteLine("\n📈 ANÁLISIS DE ASISTENCIA:");
            AnalyzeStudentAttendance(enrolledStudents, attendedStudents);

            PauseForUser();
        }

        private static void RunInventoryDemo()
        {
            Console.Clear();
            Console.WriteLine("📦 DEMO INVENTARIO DE PRODUCTOS");
            Console.WriteLine("═══════════════════════════════════");

            var warehouseA = new DynamicSet<string>();
            var warehouseB = new DynamicSet<string>();

            Console.WriteLine("\n🏪 Inventario Almacén A:");
            string[] productsA = { "Laptop", "Mouse", "Teclado", "Monitor", "Webcam", "Audífonos" };
            foreach (string product in productsA)
            {
                warehouseA.Add(product);
                Console.WriteLine($"   ✅ {product}");
            }

            Console.WriteLine("\n🏪 Inventario Almacén B:");
            string[] productsB = { "Tablet", "Mouse", "Impresora", "Monitor", "Cable USB", "Webcam" };
            foreach (string product in productsB)
            {
                warehouseB.Add(product);
                Console.WriteLine($"   ✅ {product}");
            }

            Console.WriteLine("\n📊 ANÁLISIS DE INVENTARIO:");
            AnalyzeInventory(warehouseA, warehouseB);

            PauseForUser();
        }

        private static void RunTagsDemo()
        {
            Console.Clear();
            Console.WriteLine("🏷️ DEMO TAGS Y CATEGORÍAS");
            Console.WriteLine("═══════════════════════════");

            var blogPostTags = new DynamicSet<string>();
            var videoTags = new DynamicSet<string>();

            Console.WriteLine("\n📝 Tags del Blog Post:");
            string[] blogTags = { "programación", "c#", "tutorial", "desarrollo", "código" };
            foreach (string tag in blogTags)
            {
                blogPostTags.Add(tag);
                Console.WriteLine($"   🏷️ #{tag}");
            }

            Console.WriteLine("\n🎥 Tags del Video:");
            string[] vTags = { "programación", "tutorial", "principiantes", "desarrollo", "ejemplos" };
            foreach (string tag in vTags)
            {
                videoTags.Add(tag);
                Console.WriteLine($"   🏷️ #{tag}");
            }

            Console.WriteLine("\n🔍 ANÁLISIS DE TAGS:");
            AnalyzeTags(blogPostTags, videoTags);

            PauseForUser();
        }

        private static void RunDataAnalysisDemo()
        {
            Console.Clear();
            Console.WriteLine("📊 DEMO ANÁLISIS DE DATOS");
            Console.WriteLine("════════════════════════════");

            Console.WriteLine("\n🔢 Analizando datos de encuesta...");
            
            var responses1 = new DynamicSet<string>();
            var responses2 = new DynamicSet<string>();

            Console.WriteLine("\n📋 Respuestas Pregunta 1: '¿Qué lenguajes conoces?'");
            string[] langs1 = { "Python", "Java", "C#", "JavaScript", "Python", "C++", "Java" };
            foreach (string lang in langs1)
            {
                responses1.Add(lang);
            }
            Console.WriteLine($"   Respuestas únicas: {string.Join(", ", responses1.ToList())}");

            Console.WriteLine("\n📋 Respuestas Pregunta 2: '¿Qué lenguajes quieres aprender?'");
            string[] langs2 = { "Go", "Rust", "Python", "TypeScript", "C#", "Kotlin" };
            foreach (string lang in langs2)
            {
                responses2.Add(lang);
            }
            Console.WriteLine($"   Respuestas únicas: {string.Join(", ", responses2.ToList())}");

            Console.WriteLine("\n📈 INSIGHTS DEL ANÁLISIS:");
            AnalyzeSurveyData(responses1, responses2);

            PauseForUser();
        }

        private static void RunSetVsListDemo()
        {
            Console.Clear();
            Console.WriteLine("⚔️ DEMO SET vs LISTA");
            Console.WriteLine("═══════════════════════");

            var set = new DynamicSet<int>();
            var list = new List<int>();

            Console.WriteLine("\n🔄 Agregando elementos con duplicados...");
            int[] elements = { 1, 2, 3, 2, 4, 1, 5, 3, 6, 4 };

            Console.WriteLine("\n📊 Comportamiento con duplicados:");
            Console.WriteLine("   Datos: [1, 2, 3, 2, 4, 1, 5, 3, 6, 4]");

            foreach (int num in elements)
            {
                set.Add(num);
                list.Add(num);
            }

            Console.WriteLine($"\n   Set result:  [{string.Join(", ", set.ToList())}]");
            Console.WriteLine($"   List result: [{string.Join(", ", list)}]");

            Console.WriteLine("\n📈 COMPARACIÓN:");
            Console.WriteLine($"   • Set size:  {set.Count()} elementos");
            Console.WriteLine($"   • List size: {list.Count} elementos");

            Console.WriteLine("\n🔍 Búsqueda de elemento (5):");
            bool setContains = set.Contains(5);
            bool listContains = list.Contains(5);
            Console.WriteLine($"   • Set.Contains(5):  {setContains}");
            Console.WriteLine($"   • List.Contains(5): {listContains}");

            Console.WriteLine("\n💡 CUÁNDO USAR CADA UNO:");
            ShowSetVsListGuidelines();

            PauseForUser();
        }

        private static void RunStaticVsDynamicDemo()
        {
            Console.Clear();
            Console.WriteLine("🔄 DEMO STATIC vs DYNAMIC SET");
            Console.WriteLine("═══════════════════════════════");

            var staticSet = new StaticSet<string>(5);
            var dynamicSet = new DynamicSet<string>();

            Console.WriteLine("\n🧪 Probando capacidades...");
            string[] testData = { "A", "B", "C", "D", "E", "F", "G" };

            Console.WriteLine("\n📊 Static Set (capacidad: 5):");
            foreach (string item in testData)
            {
                try
                {
                    staticSet.Add(item);
                    Console.WriteLine($"   ✅ Agregado: {item}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"   ❌ Error al agregar {item}: {ex.Message}");
                    break;
                }
            }

            Console.WriteLine("\n📊 Dynamic Set (sin límite):");
            foreach (string item in testData)
            {
                dynamicSet.Add(item);
                Console.WriteLine($"   ✅ Agregado: {item}");
            }

            Console.WriteLine("\n📈 RESULTADOS:");
            Console.WriteLine($"   • Static Set:  {staticSet.Count()} elementos - [{string.Join(", ", staticSet.ToList())}]");
            Console.WriteLine($"   • Dynamic Set: {dynamicSet.Count()} elementos - [{string.Join(", ", dynamicSet.ToList())}]");

            Console.WriteLine("\n💡 COMPARACIÓN:");
            ShowStaticVsDynamicComparison();

            PauseForUser();
        }
        
        private static void PauseForUser()
        {
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine("✨ Demo completado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void DemonstrateSetProperties(ISetTDA<int> setA, ISetTDA<int> setB)
        {
            Console.WriteLine("\n🔬 PROPIEDADES MATEMÁTICAS:");
            
            var unionAB = setA.Union(setB);
            var unionBA = setB.Union(setA);
            bool commutativeUnion = AreEqual(unionAB, unionBA);
            Console.WriteLine($"   • Unión conmutativa (A∪B = B∪A): {(commutativeUnion ? "✅ Verdadero" : "❌ Falso")}");

            var intersectionAB = setA.Intersection(setB);
            var intersectionBA = setB.Intersection(setA);
            bool commutativeIntersection = AreEqual(intersectionAB, intersectionBA);
            Console.WriteLine($"   • Intersección conmutativa (A∩B = B∩A): {(commutativeIntersection ? "✅ Verdadero" : "❌ Falso")}");
        }

        private static bool AreEqual(ISetTDA<int> set1, ISetTDA<int> set2)
        {
            if (set1.Count() != set2.Count()) return false;
            
            foreach (int item in set1.ToList())
            {
                if (!set2.Contains(item)) return false;
            }
            return true;
        }

        private static void AddElementInteractive(DynamicSet<string> set)
        {
            Console.Write("📥 Elemento a agregar: ");
            string element = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(element))
            {
                bool wasNew = !set.Contains(element);
                set.Add(element);
                Console.WriteLine($"{(wasNew ? "✅" : "⚠️")} '{element}' {(wasNew ? "agregado correctamente" : "ya existía en el conjunto")}");
            }
            else
            {
                Console.WriteLine("❌ Elemento inválido");
            }
        }

        private static void RemoveElementInteractive(DynamicSet<string> set)
        {
            Console.Write("🗑️ Elemento a eliminar: ");
            string element = Console.ReadLine();
            
            bool removed = set.Remove(element);
            Console.WriteLine(removed ? 
                $"✅ '{element}' eliminado correctamente" : 
                $"❌ '{element}' no se encontró en el conjunto");
        }

        private static void SearchElementInteractive(DynamicSet<string> set)
        {
            Console.Write("🔍 Elemento a buscar: ");
            string element = Console.ReadLine();
            
            bool found = set.Contains(element);
            Console.WriteLine(found ? 
                $"✅ '{element}' está en el conjunto" : 
                $"❌ '{element}' no está en el conjunto");
        }

        private static void DisplaySetContents(DynamicSet<string> set)
        {
            if (set.IsEmpty())
            {
                Console.WriteLine("🔄 El conjunto está vacío");
            }
            else
            {
                Console.WriteLine($"\n📋 Contenido del conjunto:");
                Console.WriteLine($"   {{{string.Join(", ", set.ToList())}}}");
            }
        }

        private static void GetRandomElement(DynamicSet<string> set)
        {
            if (set.IsEmpty())
            {
                Console.WriteLine("❌ El conjunto está vacío");
            }
            else
            {
                string element = set.GetAny();
                Console.WriteLine($"🎲 Elemento seleccionado: '{element}'");
            }
        }

        private static void ShowSetStatistics(DynamicSet<string> set)
        {
            Console.WriteLine("\n📊 ESTADÍSTICAS:");
            Console.WriteLine($"   • Elementos: {set.Count()}");
            Console.WriteLine($"   • ¿Está vacío? {(set.IsEmpty() ? "Sí" : "No")}");
            
            if (!set.IsEmpty())
            {
                Console.WriteLine($"   • Contenido: {{{string.Join(", ", set.ToList())}}}");
            }
        }

        private static void PerformSetOperationsInteractive(DynamicSet<string> set)
        {
            Console.WriteLine("\n🔧 Creando conjunto temporal para operaciones...");
            Console.Write("📝 Ingrese elementos separados por comas: ");
            string input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input))
            {
                var tempSet = new DynamicSet<string>();
                string[] elements = input.Split(',');
                
                foreach (string element in elements)
                {
                    tempSet.Add(element.Trim());
                }

                Console.WriteLine($"\n📊 Conjunto A (principal): {{{string.Join(", ", set.ToList())}}}");
                Console.WriteLine($"   Conjunto B (temporal):  {{{string.Join(", ", tempSet.ToList())}}}");

                var union = set.Union(tempSet);
                var intersection = set.Intersection(tempSet);
                var difference = set.Difference(tempSet);

                Console.WriteLine($"\n🔗 Resultados:");
                Console.WriteLine($"   A ∪ B: {{{string.Join(", ", union.ToList())}}}");
                Console.WriteLine($"   A ∩ B: {{{string.Join(", ", intersection.ToList())}}}");
                Console.WriteLine($"   A - B: {{{string.Join(", ", difference.ToList())}}}");
            }
        }

        private static void AnalyzeStudentAttendance(ISetTDA<string> enrolled, ISetTDA<string> attended)
        {
            var presentEnrolled = enrolled.Intersection(attended);
            var absentEnrolled = enrolled.Difference(attended);
            var notEnrolledAttended = attended.Difference(enrolled);

            Console.WriteLine($"   • Inscritos que asistieron: {presentEnrolled.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", presentEnrolled.ToList())}}}");
            
            Console.WriteLine($"   • Inscritos que faltaron: {absentEnrolled.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", absentEnrolled.ToList())}}}");
            
            if (notEnrolledAttended.Count() > 0)
            {
                Console.WriteLine($"   • No inscritos que asistieron: {notEnrolledAttended.Count()}");
                Console.WriteLine($"     {{{string.Join(", ", notEnrolledAttended.ToList())}}}");
            }

            double attendanceRate = enrolled.Count() > 0 ? (double)presentEnrolled.Count() / enrolled.Count() * 100 : 0;
            Console.WriteLine($"   • Tasa de asistencia: {attendanceRate:F1}%");
        }

        private static void AnalyzeInventory(ISetTDA<string> warehouseA, ISetTDA<string> warehouseB)
        {
            var allProducts = warehouseA.Union(warehouseB);
            var commonProducts = warehouseA.Intersection(warehouseB);
            var onlyInA = warehouseA.Difference(warehouseB);
            var onlyInB = warehouseB.Difference(warehouseA);

            Console.WriteLine($"   • Total de productos únicos: {allProducts.Count()}");
            Console.WriteLine($"   • Productos en ambos almacenes: {commonProducts.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", commonProducts.ToList())}}}");
            
            Console.WriteLine($"   • Solo en Almacén A: {onlyInA.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", onlyInA.ToList())}}}");
            
            Console.WriteLine($"   • Solo en Almacén B: {onlyInB.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", onlyInB.ToList())}}}");
        }

        private static void AnalyzeTags(ISetTDA<string> blogTags, ISetTDA<string> videoTags)
        {
            var allTags = blogTags.Union(videoTags);
            var commonTags = blogTags.Intersection(videoTags);
            var blogOnlyTags = blogTags.Difference(videoTags);
            var videoOnlyTags = videoTags.Difference(blogTags);

            Console.WriteLine($"   • Total de tags únicos: {allTags.Count()}");
            Console.WriteLine($"   • Tags en común: {commonTags.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", commonTags.ToList())}}}");
            
            Console.WriteLine($"   • Tags solo del blog: {blogOnlyTags.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", blogOnlyTags.ToList())}}}");
            
            Console.WriteLine($"   • Tags solo del video: {videoOnlyTags.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", videoOnlyTags.ToList())}}}");

            Console.WriteLine($"\n💡 RECOMENDACIÓN:");
            Console.WriteLine($"   Los tags en común sugieren contenido relacionado.");
            Console.WriteLine($"   Considera usar todos los tags únicos para mejor alcance.");
        }

        private static void AnalyzeSurveyData(ISetTDA<string> knownLangs, ISetTDA<string> wantToLearn)
        {
            var alreadyKnowButWantMore = knownLangs.Intersection(wantToLearn);
            var newLanguages = wantToLearn.Difference(knownLangs);
            var onlyKnown = knownLangs.Difference(wantToLearn);
            var allLanguages = knownLangs.Union(wantToLearn);

            Console.WriteLine($"   • Total de lenguajes mencionados: {allLanguages.Count()}");
            
            Console.WriteLine($"   • Lenguajes que conocen Y quieren aprender más: {alreadyKnowButWantMore.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", alreadyKnowButWantMore.ToList())}}}");
            
            Console.WriteLine($"   • Lenguajes nuevos que quieren aprender: {newLanguages.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", newLanguages.ToList())}}}");
            
            Console.WriteLine($"   • Lenguajes que solo conocen: {onlyKnown.Count()}");
            Console.WriteLine($"     {{{string.Join(", ", onlyKnown.ToList())}}}");

            Console.WriteLine($"\n📈 INSIGHTS:");
            if (alreadyKnowButWantMore.Count() > 0)
            {
                Console.WriteLine($"   • Hay interés en profundizar en lenguajes conocidos");
            }
            if (newLanguages.Count() > 0)
            {
                Console.WriteLine($"   • Hay demanda de aprendizaje en nuevas tecnologías");
            }
        }

        private static void ShowSetVsListGuidelines()
        {
            Console.WriteLine("   🔢 SET:");
            Console.WriteLine("      ✅ Elementos únicos automáticamente");
            Console.WriteLine("      ✅ Operaciones matemáticas (unión, intersección)");
            Console.WriteLine("      ✅ Verificación rápida de membresía");
            Console.WriteLine("      ❌ No mantiene orden de inserción");
            Console.WriteLine("      ❌ No permite acceso por índice");

            Console.WriteLine("\n   📋 LISTA:");
            Console.WriteLine("      ✅ Mantiene orden de inserción");
            Console.WriteLine("      ✅ Permite duplicados");
            Console.WriteLine("      ✅ Acceso por índice");
            Console.WriteLine("      ✅ Métodos de ordenamiento");
            Console.WriteLine("      ❌ Duplicados no deseados");
            Console.WriteLine("      ❌ Búsqueda menos eficiente");
        }

        private static void ShowStaticVsDynamicComparison()
        {
            Console.WriteLine("   📊 STATIC SET:");
            Console.WriteLine("      ✅ Uso de memoria predecible");
            Console.WriteLine("      ✅ Mejor rendimiento en arrays pequeños");
            Console.WriteLine("      ✅ Sin asignación dinámica de memoria");
            Console.WriteLine("      ❌ Capacidad limitada");
            Console.WriteLine("      ❌ Desperdicio de memoria si no se llena");

            Console.WriteLine("\n   🔄 DYNAMIC SET:");
            Console.WriteLine("      ✅ Capacidad ilimitada");
            Console.WriteLine("      ✅ Uso eficiente de memoria");
            Console.WriteLine("      ✅ Flexibilidad en tiempo de ejecución");
            Console.WriteLine("      ❌ Overhead de punteros");
            Console.WriteLine("      ❌ Fragmentación de memoria");

            Console.WriteLine("\n💡 RECOMENDACIÓN:");
            Console.WriteLine("   • Static Set: Para colecciones pequeñas y predecibles");
            Console.WriteLine("   • Dynamic Set: Para colecciones que crecen dinámicamente");
        }
    }
}