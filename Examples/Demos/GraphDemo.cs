using Estructuras_de_Datos.Structures.Graphs;

namespace Estructuras_de_Datos.Examples.Demos
{
    public static class GraphDemo
    {
        public static void ShowGraphMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" GRAPH (GRAFO) - DEMOS");
                Console.WriteLine("═════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine(" DEMOS DISPONIBLES:");
                Console.WriteLine("   1. Demo Básico (Ciudades)");
                Console.WriteLine("   2. Red Social");
                Console.WriteLine("   3. Mapa de Rutas");
                Console.WriteLine("   4. Demo Interactivo");
                Console.WriteLine();
                Console.WriteLine("ALGORITMOS:");
                Console.WriteLine("   5. Recorrido DFS (Profundidad)");
                Console.WriteLine("   6. Recorrido BFS (Anchura)");
                Console.WriteLine("   7. Búsqueda de Caminos");
                Console.WriteLine();
                Console.WriteLine("CASOS DE USO:");
                Console.WriteLine("   8. Red de Computadoras");
                Console.WriteLine("   9. Sistema de Prereq. Materias");
                Console.WriteLine();
                Console.WriteLine("   0. ← Volver al menú principal");
                Console.WriteLine("═════════════════════════════════");
                Console.Write("Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunBasicGraphDemo();
                        break;
                    case "2":
                        RunSocialNetworkDemo();
                        break;
                    case "3":
                        RunRouteMapDemo();
                        break;
                    case "4":
                        RunInteractiveGraphDemo();
                        break;
                    case "5":
                        RunDFSDemo();
                        break;
                    case "6":
                        RunBFSDemo();
                        break;
                    case "7":
                        RunPathFindingDemo();
                        break;
                    case "8":
                        RunNetworkDemo();
                        break;
                    case "9":
                        RunPrerequisitesDemo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        private static void RunBasicGraphDemo()
        {
            Console.Clear();
            Console.WriteLine("DEMO BÁSICO - GRAFO DE CIUDADES");
            Console.WriteLine("══════════════════════════════════════");

            var cityGraph = new Graph<string>();

            Console.WriteLine("\n Agregando ciudades...");
            string[] cities = { "Buenos Aires", "Córdoba", "Rosario", "Mendoza", "La Plata" };
            
            foreach (string city in cities)
            {
                cityGraph.AddVertex(city);
                Console.WriteLine($"Ciudad agregada: {city}");
                System.Threading.Thread.Sleep(300);
            }

            Console.WriteLine("\n Conectando ciudades con rutas...");

            cityGraph.AddEdge("Buenos Aires", "La Plata", 60);
            cityGraph.AddEdge("Buenos Aires", "Rosario", 300);
            cityGraph.AddEdge("Buenos Aires", "Córdoba", 700);
            cityGraph.AddEdge("Rosario", "Córdoba", 400);
            cityGraph.AddEdge("Córdoba", "Mendoza", 420);
            cityGraph.AddEdge("La Plata", "Buenos Aires", 60);

            Console.WriteLine("  Todas las rutas conectadas");

            Console.WriteLine("\nINFORMACIÓN DEL GRAFO:");
            Console.WriteLine($"   • Total de ciudades: {cityGraph.VertexCount()}");
            Console.WriteLine($"   • Total de rutas: {cityGraph.EdgeCount()}");
            Console.WriteLine($"   • ¿Está vacío? {(cityGraph.IsEmpty() ? "Sí" : "No")}");

            Console.WriteLine("\nESTRUCTURA COMPLETA:");
            cityGraph.DisplayGraph();

            Console.WriteLine("\nVerificando conexiones:");
            Console.WriteLine($"   Buenos Aires → Córdoba: {(cityGraph.HasEdge("Buenos Aires", "Córdoba") ? " Conectadas" : "No conectadas")}");
            Console.WriteLine($"   Córdoba → Buenos Aires: {(cityGraph.HasEdge("Córdoba", "Buenos Aires") ? "Conectadas" : "No conectadas")}");
            Console.WriteLine($"   Mendoza → La Plata: {(cityGraph.HasEdge("Mendoza", "La Plata") ? " Conectadas" : " No conectadas")}");

            PauseForUser();
        }

        private static void RunSocialNetworkDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO RED SOCIAL");
            Console.WriteLine("════════════════════");

            var socialGraph = new Graph<string>();

            Console.WriteLine("\nCreando usuarios...");
            string[] users = { "Ana", "Bruno", "Carla", "Diego", "Elena", "Franco" };
            
            foreach (string user in users)
            {
                socialGraph.AddVertex(user);
                Console.WriteLine($"   Usuario registrado: {user}");
            }

            Console.WriteLine("\n Estableciendo amistades...");

            AddFriendship(socialGraph, "Ana", "Bruno");
            AddFriendship(socialGraph, "Ana", "Carla");
            AddFriendship(socialGraph, "Bruno", "Diego");
            AddFriendship(socialGraph, "Carla", "Elena");
            AddFriendship(socialGraph, "Diego", "Franco");
            AddFriendship(socialGraph, "Elena", "Franco");

            Console.WriteLine("\nANÁLISIS DE LA RED:");
            Console.WriteLine($"   • Total de usuarios: {socialGraph.VertexCount()}");
            Console.WriteLine($"   • Total de conexiones: {socialGraph.EdgeCount() / 2}");

            Console.WriteLine("\n CONEXIONES DIRECTAS:");
            ShowDirectConnections(socialGraph, users);

            Console.WriteLine("\nESTRUCTURA DE LA RED:");
            socialGraph.DisplayGraph();

            PauseForUser();
        }

        private static void RunRouteMapDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO MAPA DE RUTAS CON DISTANCIAS");
            Console.WriteLine("═══════════════════════════════════════");

            var routeGraph = new Graph<string>();

            Console.WriteLine("\nCreando mapa de la ciudad...");
            string[] locations = { "Centro", "Universidad", "Hospital", "Aeropuerto", "Estadio", "Mall" };
            
            foreach (string location in locations)
            {
                routeGraph.AddVertex(location);
                Console.WriteLine($"   Ubicación: {location}");
            }

            Console.WriteLine("\n Estableciendo rutas con distancias (km)...");
            routeGraph.AddEdge("Centro", "Universidad", 5);
            routeGraph.AddEdge("Centro", "Hospital", 3);
            routeGraph.AddEdge("Centro", "Mall", 7);
            routeGraph.AddEdge("Universidad", "Estadio", 4);
            routeGraph.AddEdge("Hospital", "Aeropuerto", 15);
            routeGraph.AddEdge("Mall", "Aeropuerto", 12);
            routeGraph.AddEdge("Estadio", "Mall", 6);

            Console.WriteLine("   Todas las rutas configuradas");

            Console.WriteLine("\n DISTANCIAS ESPECÍFICAS:");
            ShowRouteDistances(routeGraph);

            Console.WriteLine("\nMAPA COMPLETO:");
            routeGraph.DisplayGraph();

            PauseForUser();
        }
        
        private static void RunInteractiveGraphDemo()
        {
            Console.Clear();
            Console.WriteLine("🎮 DEMO INTERACTIVO - GRAFO");
            Console.WriteLine("═══════════════════════════════");

            var graph = new Graph<string>();

            while (true)
            {
                Console.WriteLine("\n OPCIONES DISPONIBLES:");
                Console.WriteLine("   1. Agregar vértice");
                Console.WriteLine("   2. Agregar arista");
                Console.WriteLine("   3. Eliminar vértice");
                Console.WriteLine("   4. Eliminar arista");
                Console.WriteLine("   5. Verificar conexión");
                Console.WriteLine("   6. Mostrar grafo");
                Console.WriteLine("   7. Mostrar estadísticas");
                Console.WriteLine("   8. Limpiar grafo");
                Console.WriteLine("   0. Salir");
                Console.Write("\n Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddVertexInteractive(graph);
                        break;
                    case "2":
                        AddEdgeInteractive(graph);
                        break;
                    case "3":
                        RemoveVertexInteractive(graph);
                        break;
                    case "4":
                        RemoveEdgeInteractive(graph);
                        break;
                    case "5":
                        CheckConnectionInteractive(graph);
                        break;
                    case "6":
                        DisplayGraphStructure(graph);
                        break;
                    case "7":
                        ShowGraphStatistics(graph);
                        break;
                    case "8":
                        graph.Clear();
                        Console.WriteLine(" Grafo limpiado correctamente");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine(" Opción no válida");
                        break;
                }
            }
        }
        

        private static void RunDFSDemo()
        {
            Console.Clear();
            Console.WriteLine("DEMO RECORRIDO DFS (Depth-First Search)");
            Console.WriteLine("═════════════════════════════════════════════");

            var graph = CreateSampleGraph();

            Console.WriteLine("Grafo de ejemplo:");
            graph.DisplayGraph();

            Console.WriteLine("\n RECORRIDO DFS desde diferentes puntos:");
            
            var vertices = graph.GetVertices().ToList();
            foreach (var vertex in vertices)
            {
                Console.WriteLine($"\n DFS desde '{vertex}':");
                var dfsResult = graph.DepthFirstSearch(vertex);
                Console.Write("   Orden de visita: ");
                Console.WriteLine(string.Join(" → ", dfsResult));
            }

            Console.WriteLine("\nEXPLICACIÓN:");
            Console.WriteLine("   DFS explora tan profundo como sea posible antes de retroceder.");
            Console.WriteLine("   Útil para: detectar ciclos, topological sort, maze solving.");

            PauseForUser();
        }

        private static void RunBFSDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO RECORRIDO BFS (Breadth-First Search)");
            Console.WriteLine("══════════════════════════════════════════════");

            var graph = CreateSampleGraph();

            Console.WriteLine(" Grafo de ejemplo:");
            graph.DisplayGraph();

            Console.WriteLine("\n RECORRIDO BFS desde diferentes puntos:");
            
            var vertices = graph.GetVertices().ToList();
            foreach (var vertex in vertices)
            {
                Console.WriteLine($"\n BFS desde '{vertex}':");
                var bfsResult = graph.BreadthFirstSearch(vertex);
                Console.Write("   Orden de visita: ");
                Console.WriteLine(string.Join(" → ", bfsResult));
            }

            Console.WriteLine("\n EXPLICACIÓN:");
            Console.WriteLine("   BFS explora todos los vecinos antes de ir al siguiente nivel.");
            Console.WriteLine("   Útil para: camino más corto, redes sociales, web crawling.");

            PauseForUser();
        }

        private static void RunPathFindingDemo()
        {
            Console.Clear();
            Console.WriteLine("DEMO BÚSQUEDA DE CAMINOS");
            Console.WriteLine("══════════════════════════════");

            var graph = CreateSampleGraph();

            Console.WriteLine("Grafo de ejemplo:");
            graph.DisplayGraph();

            Console.WriteLine("\n BÚSQUEDA DE CAMINOS:");
            
            var vertices = graph.GetVertices().ToList();
            
            string[,] pathTests = {
                {"A", "D"},
                {"B", "E"},
                {"C", "A"},
                {"E", "C"}
            };

            for (int i = 0; i < pathTests.GetLength(0); i++)
            {
                string source = pathTests[i, 0];
                string destination = pathTests[i, 1];
                
                Console.WriteLine($"\n🔸 Camino de '{source}' a '{destination}':");
                var path = graph.GetPath(source, destination);
                
                if (path.Count > 0)
                {
                    Console.WriteLine($"    Camino encontrado: {string.Join(" → ", path)}");
                    Console.WriteLine($"    Pasos: {path.Count - 1}");
                }
                else
                {
                    Console.WriteLine("    No existe camino");
                }
            }

            PauseForUser();
        }

        private static void RunNetworkDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO RED DE COMPUTADORAS");
            Console.WriteLine("══════════════════════════════");

            var network = new Graph<string>();

            Console.WriteLine("\n Configurando red empresarial...");
            string[] devices = { "Servidor", "Router", "PC-1", "PC-2", "PC-3", "Printer", "WiFi-AP" };
            
            foreach (string device in devices)
            {
                network.AddVertex(device);
                Console.WriteLine($"    Dispositivo conectado: {device}");
            }

            Console.WriteLine("\n🔗 Estableciendo conexiones de red...");

            network.AddEdge("Router", "Servidor", 1);
            network.AddEdge("Router", "PC-1", 1);
            network.AddEdge("Router", "PC-2", 1);
            network.AddEdge("Router", "PC-3", 1);
            network.AddEdge("Router", "Printer", 1);
            network.AddEdge("Router", "WiFi-AP", 1);

            network.AddEdge("Servidor", "Router", 1);
            network.AddEdge("PC-1", "Router", 1);
            network.AddEdge("PC-2", "Router", 1);
            network.AddEdge("PC-3", "Router", 1);
            network.AddEdge("Printer", "Router", 1);
            network.AddEdge("WiFi-AP", "Router", 1);

            Console.WriteLine("    Red configurada");

            Console.WriteLine("\n ANÁLISIS DE LA RED:");
            Console.WriteLine($"   • Dispositivos: {network.VertexCount()}");
            Console.WriteLine($"   • Conexiones: {network.EdgeCount() / 2}");

            Console.WriteLine("\n PRUEBAS DE CONECTIVIDAD:");
            TestNetworkConnectivity(network);

            Console.WriteLine("\n TOPOLOGÍA DE RED:");
            network.DisplayGraph();

            PauseForUser();
        }

        private static void RunPrerequisitesDemo()
        {
            Console.Clear();
            Console.WriteLine("DEMO SISTEMA DE PRERREQUISITOS");
            Console.WriteLine("════════════════════════════════════");

            var prerequisites = new Graph<string>();

            Console.WriteLine("\n Configurando materias del plan de estudios...");
            string[] subjects = { 
                "Matemática I", "Matemática II", "Física I", "Programación I", 
                "Programación II", "Algoritmos", "Base de Datos", "Sistemas"
            };
            
            foreach (string subject in subjects)
            {
                prerequisites.AddVertex(subject);
                Console.WriteLine($"    Materia: {subject}");
            }

            Console.WriteLine("\n🔗 Estableciendo prerrequisitos...");

            prerequisites.AddEdge("Matemática II", "Matemática I", 1);
            prerequisites.AddEdge("Física I", "Matemática I", 1);
            prerequisites.AddEdge("Programación II", "Programación I", 1);
            prerequisites.AddEdge("Algoritmos", "Programación I", 1);
            prerequisites.AddEdge("Base de Datos", "Programación II", 1);
            prerequisites.AddEdge("Sistemas", "Algoritmos", 1);
            prerequisites.AddEdge("Sistemas", "Base de Datos", 1);

            Console.WriteLine("    Prerrequisitos configurados");

            Console.WriteLine("\n ANÁLISIS DEL PLAN:");
            AnalyzePrerequisites(prerequisites, subjects);

            Console.WriteLine("\nESTRUCTURA COMPLETA:");
            prerequisites.DisplayGraph();

            PauseForUser();
        }

        private static void PauseForUser()
        {
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine(" Demo completado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void AddFriendship(Graph<string> graph, string user1, string user2)
        {
            graph.AddEdge(user1, user2, 1);
            graph.AddEdge(user2, user1, 1);
            Console.WriteLine($"   {user1} ↔ {user2}");
        }

        private static void ShowDirectConnections(Graph<string> graph, string[] users)
        {
            foreach (string user in users)
            {
                Console.Write($"   {user}: ");
                var connections = new List<string>();
                foreach (string otherUser in users)
                {
                    if (user != otherUser && graph.HasEdge(user, otherUser))
                    {
                        connections.Add(otherUser);
                    }
                }
                Console.WriteLine(connections.Count > 0 ? string.Join(", ", connections) : "Sin conexiones");
            }
        }

        private static void ShowRouteDistances(Graph<string> graph)
        {
            string[,] routes = {
                {"Centro", "Universidad"},
                {"Centro", "Hospital"},
                {"Hospital", "Aeropuerto"},
                {"Mall", "Aeropuerto"}
            };

            for (int i = 0; i < routes.GetLength(0); i++)
            {
                string from = routes[i, 0];
                string to = routes[i, 1];
                
                if (graph.HasEdge(from, to))
                {
                    int distance = graph.GetEdgeWeight(from, to);
                    Console.WriteLine($"    {from} → {to}: {distance} km");
                }
            }
        }

        private static Graph<string> CreateSampleGraph()
        {
            var graph = new Graph<string>();
            
            string[] vertices = { "A", "B", "C", "D", "E" };
            foreach (string vertex in vertices)
            {
                graph.AddVertex(vertex);
            }
            
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("B", "D", 1);
            graph.AddEdge("C", "E", 1);
            graph.AddEdge("D", "E", 1);
            
            return graph;
        }

        private static void AddVertexInteractive(Graph<string> graph)
        {
            Console.Write("Nombre del vértice: ");
            string vertex = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(vertex))
            {
                try
                {
                    graph.AddVertex(vertex);
                    Console.WriteLine($" Vértice '{vertex}' agregado correctamente");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine(" Nombre de vértice inválido");
            }
        }

        private static void AddEdgeInteractive(Graph<string> graph)
        {
            Console.Write("Vértice origen: ");
            string source = Console.ReadLine();
            Console.Write("Vértice destino: ");
            string destination = Console.ReadLine();
            Console.Write("Peso (opcional, presiona Enter para 1): ");
            string weightStr = Console.ReadLine();
            
            int weight = 1;
            if (!string.IsNullOrWhiteSpace(weightStr) && !int.TryParse(weightStr, out weight))
            {
                Console.WriteLine(" Peso inválido, usando 1");
                weight = 1;
            }
            
            try
            {
                graph.AddEdge(source, destination, weight);
                Console.WriteLine($"Arista '{source}' → '{destination}' (peso: {weight}) agregada");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private static void RemoveVertexInteractive(Graph<string> graph)
        {
            Console.Write("🗑️ Vértice a eliminar: ");
            string vertex = Console.ReadLine();
            
            bool removed = graph.RemoveVertex(vertex);
            Console.WriteLine(removed ? 
                $"Vértice '{vertex}' eliminado correctamente" : 
                $"Vértice '{vertex}' no encontrado");
        }

        private static void RemoveEdgeInteractive(Graph<string> graph)
        {
            Console.Write("🗑️ Vértice origen: ");
            string source = Console.ReadLine();
            Console.Write("🗑️ Vértice destino: ");
            string destination = Console.ReadLine();
            
            bool removed = graph.RemoveEdge(source, destination);
            Console.WriteLine(removed ? 
                $"Arista '{source}' → '{destination}' eliminada" : 
                $"Arista no encontrada");
        }

        private static void CheckConnectionInteractive(Graph<string> graph)
        {
            Console.Write(" Vértice origen: ");
            string source = Console.ReadLine();
            Console.Write("Vértice destino: ");
            string destination = Console.ReadLine();
            
            bool connected = graph.HasEdge(source, destination);
            if (connected)
            {
                int weight = graph.GetEdgeWeight(source, destination);
                Console.WriteLine($"'{source}' → '{destination}' están conectados (peso: {weight})");
            }
            else
            {
                Console.WriteLine($"'{source}' → '{destination}' no están conectados");
            }
        }

        private static void DisplayGraphStructure(Graph<string> graph)
        {
            if (graph.IsEmpty())
            {
                Console.WriteLine(" El grafo está vacío");
            }
            else
            {
                Console.WriteLine("\nESTRUCTURA ACTUAL:");
                graph.DisplayGraph();
            }
        }

        private static void ShowGraphStatistics(Graph<string> graph)
        {
            Console.WriteLine("\nESTADÍSTICAS ACTUALES:");
            Console.WriteLine($"   • Vértices: {graph.VertexCount()}");
            Console.WriteLine($"   • Aristas: {graph.EdgeCount()}");
            Console.WriteLine($"   • ¿Está vacío? {(graph.IsEmpty() ? "Sí" : "No")}");
            
            if (!graph.IsEmpty())
            {
                var vertices = graph.GetVertices();
                Console.WriteLine($"   • Lista de vértices: {string.Join(", ", vertices.ToList())}");
            }
        }

        private static void TestNetworkConnectivity(Graph<string> network)
        {
            string[,] tests = {
                {"PC-1", "Servidor"},
                {"PC-2", "Printer"},
                {"WiFi-AP", "PC-3"}
            };

            for (int i = 0; i < tests.GetLength(0); i++)
            {
                string from = tests[i, 0];
                string to = tests[i, 1];
                
                var path = network.GetPath(from, to);
                if (path.Count > 0)
                {
                    Console.WriteLine($"   {from} → {to}: {string.Join(" → ", path)}");
                }
                else
                {
                    Console.WriteLine($"   {from} → {to}: Sin conexión");
                }
            }
        }

        private static void AnalyzePrerequisites(Graph<string> graph, string[] subjects)
        {
            Console.WriteLine($"   • Total de materias: {graph.VertexCount()}");
            Console.WriteLine($"   • Total de prerrequisitos: {graph.EdgeCount()}");

            Console.WriteLine("\n Materias sin prerrequisitos:");
            foreach (string subject in subjects)
            {
                bool hasPrerequisites = false;
                foreach (string other in subjects)
                {
                    if (graph.HasEdge(subject, other))
                    {
                        hasPrerequisites = true;
                        break;
                    }
                }
                if (!hasPrerequisites)
                {
                    Console.WriteLine($"   {subject} (puede cursarse primero)");
                }
            }

            Console.WriteLine("\nEjemplos de secuencias de prerrequisitos:");
            if (graph.HasEdge("Sistemas", "Algoritmos"))
            {
                var path = graph.GetPath("Sistemas", "Programación I");
                if (path.Count > 0)
                {
                    Console.WriteLine($"   Para cursar Sistemas: {string.Join(" ← ", path)}");
                }
            }
        }
    }
}