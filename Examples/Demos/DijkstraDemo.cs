using Estructuras_de_Datos.Structures.Graphs;

namespace Estructuras_de_Datos.Examples.Demos
{
    public static class DijkstraDemo
    {
        public static void ShowDijkstraMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" DIJKSTRA - ALGORITMO DE CAMINOS MÍNIMOS");
                Console.WriteLine("═══════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine(" DEMOS DISPONIBLES:");
                Console.WriteLine("   1. Demo Básico (Red de Ciudades)");
                Console.WriteLine("   2. Red de Transporte Urbano");
                Console.WriteLine("   3. Red de Computadoras");
                Console.WriteLine("   4. Sistema de Navegación GPS");
                Console.WriteLine("   5. Demo Interactivo");
                Console.WriteLine();
                Console.WriteLine(" ANÁLISIS:");
                Console.WriteLine("   6. Comparación con BFS");
                Console.WriteLine("   7. Análisis de Complejidad");
                Console.WriteLine("   8. Casos de Uso Prácticos");
                Console.WriteLine();
                Console.WriteLine("   0. ← Volver al menú principal");
                Console.WriteLine("═══════════════════════════════════════════════");
                Console.Write("Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunBasicDijkstraDemo();
                        break;
                    case "2":
                        RunUrbanTransportDemo();
                        break;
                    case "3":
                        RunNetworkRoutingDemo();
                        break;
                    case "4":
                        RunGPSNavigationDemo();
                        break;
                    case "5":
                        RunInteractiveDijkstraDemo();
                        break;
                    case "6":
                        RunDijkstraVsBFSComparison();
                        break;
                    case "7":
                        RunComplexityAnalysis();
                        break;
                    case "8":
                        RunUseCasesDemo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine(" Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RunBasicDijkstraDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO BÁSICO - DIJKSTRA EN RED DE CIUDADES");
            Console.WriteLine("══════════════════════════════════════════════");

            var cityGraph = new Graph<string>();

            Console.WriteLine("\n Creando red de ciudades...");
            string[] cities = { "Buenos Aires", "Córdoba", "Rosario", "Mendoza", "La Plata", "Mar del Plata" };

            foreach (string city in cities)
            {
                cityGraph.AddVertex(city);
                Console.WriteLine($"   Ciudad agregada: {city}");
                System.Threading.Thread.Sleep(200);
            }

            Console.WriteLine("\n Estableciendo rutas con distancias (km)...");
            cityGraph.AddEdge("Buenos Aires", "La Plata", 60);
            cityGraph.AddEdge("Buenos Aires", "Rosario", 300);
            cityGraph.AddEdge("Buenos Aires", "Mar del Plata", 400);
            cityGraph.AddEdge("La Plata", "Buenos Aires", 60);
            cityGraph.AddEdge("Rosario", "Buenos Aires", 300);
            cityGraph.AddEdge("Rosario", "Córdoba", 400);
            cityGraph.AddEdge("Córdoba", "Rosario", 400);
            cityGraph.AddEdge("Córdoba", "Mendoza", 420);
            cityGraph.AddEdge("Córdoba", "Buenos Aires", 700);
            cityGraph.AddEdge("Mendoza", "Córdoba", 420);
            cityGraph.AddEdge("Mar del Plata", "Buenos Aires", 400);

            Console.WriteLine("    Todas las rutas establecidas");

            Console.WriteLine("\n MAPA DE LA RED:");
            cityGraph.DisplayGraph();

            Console.WriteLine("\n APLICANDO DIJKSTRA desde Buenos Aires:");
            var dijkstraResult = DijkstraAlgorithm.FindShortestPaths(cityGraph, "Buenos Aires");

            Console.WriteLine("\n RESULTADOS - DISTANCIAS MÍNIMAS:");
            DisplayDijkstraResults(dijkstraResult);

            Console.WriteLine("\n RUTAS ESPECÍFICAS:");
            ShowSpecificRoutes(cityGraph, "Buenos Aires", new[] { "Mendoza", "Mar del Plata", "Córdoba" });

            PauseForUser();
        }

        private static void RunUrbanTransportDemo()
        {
            Console.Clear();
            Console.WriteLine("RED DE TRANSPORTE URBANO - DIJKSTRA");
            Console.WriteLine("═══════════════════════════════════════");

            var transportGraph = new Graph<string>();

            Console.WriteLine("\n Configurando paradas de transporte...");
            string[] stops = { 
                "Terminal", "Centro", "Universidad", "Hospital", 
                "Aeropuerto", "Estadio", "Mall", "Barrio Norte" 
            };

            foreach (string stop in stops)
            {
                transportGraph.AddVertex(stop);
                Console.WriteLine($"    Parada: {stop}");
            }

            Console.WriteLine("\n Estableciendo rutas con tiempos (minutos)...");
            transportGraph.AddEdge("Terminal", "Centro", 15);
            transportGraph.AddEdge("Terminal", "Aeropuerto", 45);
            transportGraph.AddEdge("Centro", "Universidad", 20);
            transportGraph.AddEdge("Centro", "Hospital", 12);
            transportGraph.AddEdge("Centro", "Mall", 25);
            transportGraph.AddEdge("Universidad", "Estadio", 18);
            transportGraph.AddEdge("Universidad", "Barrio Norte", 22);
            transportGraph.AddEdge("Hospital", "Aeropuerto", 35);
            transportGraph.AddEdge("Mall", "Estadio", 15);
            transportGraph.AddEdge("Mall", "Barrio Norte", 20);
            transportGraph.AddEdge("Estadio", "Barrio Norte", 10);

            AddBidirectionalTransportEdges(transportGraph);

            Console.WriteLine("   Red de transporte configurada");

            Console.WriteLine("\nPLANIFICADOR DE RUTAS desde Terminal:");
            var result = DijkstraAlgorithm.FindShortestPaths(transportGraph, "Terminal");

            Console.WriteLine("\n TIEMPOS MÍNIMOS DE VIAJE:");
            DisplayDijkstraResults(result);

            Console.WriteLine("\n RECOMENDACIONES DE RUTAS:");
            ShowTransportRecommendations(transportGraph, "Terminal");

            PauseForUser();
        }

        private static void RunNetworkRoutingDemo()
        {
            Console.Clear();
            Console.WriteLine(" ENRUTAMIENTO DE RED - DIJKSTRA");
            Console.WriteLine("════════════════════════════════════");

            var networkGraph = new Graph<string>();

            Console.WriteLine("\n Configurando topología de red...");
            string[] nodes = { 
                "Router-A", "Router-B", "Router-C", "Router-D", 
                "Router-E", "Server", "Client-1", "Client-2" 
            };

            foreach (string node in nodes)
            {
                networkGraph.AddVertex(node);
                Console.WriteLine($"    Nodo: {node}");
            }

            Console.WriteLine("\n🔗 Estableciendo enlaces con latencias (ms)...");
            networkGraph.AddEdge("Router-A", "Router-B", 10);
            networkGraph.AddEdge("Router-A", "Router-C", 15);
            networkGraph.AddEdge("Router-B", "Router-D", 12);
            networkGraph.AddEdge("Router-B", "Server", 5);
            networkGraph.AddEdge("Router-C", "Router-D", 8);
            networkGraph.AddEdge("Router-C", "Router-E", 20);
            networkGraph.AddEdge("Router-D", "Router-E", 6);
            networkGraph.AddEdge("Router-D", "Client-1", 3);
            networkGraph.AddEdge("Router-E", "Client-2", 4);
            networkGraph.AddEdge("Server", "Router-A", 7);

            AddBidirectionalNetworkEdges(networkGraph);

            Console.WriteLine("   Topología de red establecida");

            Console.WriteLine("\n ANÁLISIS DE ENRUTAMIENTO desde Server:");
            var routingResult = DijkstraAlgorithm.FindShortestPaths(networkGraph, "Server");

            Console.WriteLine("\nLATENCIAS MÍNIMAS:");
            DisplayDijkstraResults(routingResult);

            Console.WriteLine("\n️ RUTAS ÓPTIMAS DE RED:");
            ShowNetworkRoutes(networkGraph, "Server", new[] { "Client-1", "Client-2", "Router-E" });

            PauseForUser();
        }

        private static void RunGPSNavigationDemo()
        {
            Console.Clear();
            Console.WriteLine(" SISTEMA DE NAVEGACIÓN GPS - DIJKSTRA");
            Console.WriteLine("═══════════════════════════════════════════");

            var gpsGraph = new Graph<string>();

            Console.WriteLine("\n Mapeando intersecciones de la ciudad...");
            string[] intersections = { 
                "Casa", "Supermercado", "Banco", "Farmacia", 
                "Escuela", "Trabajo", "Centro Comercial", "Gasolinera" 
            };

            foreach (string intersection in intersections)
            {
                gpsGraph.AddVertex(intersection);
                Console.WriteLine($"    Punto: {intersection}");
            }

            Console.WriteLine("\n️ Calculando distancias entre puntos (km)...");
            gpsGraph.AddEdge("Casa", "Supermercado", 2);
            gpsGraph.AddEdge("Casa", "Escuela", 3);
            gpsGraph.AddEdge("Supermercado", "Banco", 1);
            gpsGraph.AddEdge("Supermercado", "Centro Comercial", 4);
            gpsGraph.AddEdge("Banco", "Farmacia", 2);
            gpsGraph.AddEdge("Banco", "Trabajo", 5);
            gpsGraph.AddEdge("Farmacia", "Trabajo", 3);
            gpsGraph.AddEdge("Escuela", "Gasolinera", 2);
            gpsGraph.AddEdge("Gasolinera", "Centro Comercial", 3);
            gpsGraph.AddEdge("Centro Comercial", "Trabajo", 6);

            AddBidirectionalGPSEdges(gpsGraph);

            Console.WriteLine("    Mapa de navegación listo");

            Console.WriteLine("\n NAVEGADOR GPS desde Casa:");
            var gpsResult = DijkstraAlgorithm.FindShortestPaths(gpsGraph, "Casa");

            Console.WriteLine("\n DISTANCIAS A DESTINOS:");
            DisplayDijkstraResults(gpsResult);

            Console.WriteLine("\n RUTAS RECOMENDADAS:");
            ShowGPSRoutes(gpsGraph, "Casa");

            Console.WriteLine("\n OPTIMIZACIÓN DE RUTA:");
            ShowRouteOptimization(gpsGraph, "Casa", new[] { "Banco", "Supermercado", "Trabajo" });

            PauseForUser();
        }

        private static void RunInteractiveDijkstraDemo()
        {
            Console.Clear();
            Console.WriteLine(" DEMO INTERACTIVO - DIJKSTRA");
            Console.WriteLine("════════════════════════════════");

            var graph = new Graph<string>();

            while (true)
            {
                Console.WriteLine("\n OPCIONES DISPONIBLES:");
                Console.WriteLine("   1. Agregar vértice");
                Console.WriteLine("   2. Agregar arista con peso");
                Console.WriteLine("   3. Mostrar grafo");
                Console.WriteLine("   4. Ejecutar Dijkstra");
                Console.WriteLine("   5. Buscar ruta específica");
                Console.WriteLine("   6. Cargar grafo de ejemplo");
                Console.WriteLine("   7. Limpiar grafo");
                Console.WriteLine("   0. Salir");
                Console.Write("\n Seleccione: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddVertexInteractive(graph);
                        break;
                    case "2":
                        AddWeightedEdgeInteractive(graph);
                        break;
                    case "3":
                        DisplayGraphStructure(graph);
                        break;
                    case "4":
                        RunDijkstraInteractive(graph);
                        break;
                    case "5":
                        FindSpecificPathInteractive(graph);
                        break;
                    case "6":
                        LoadSampleGraph(graph);
                        break;
                    case "7":
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

        private static void RunDijkstraVsBFSComparison()
        {
            Console.Clear();
            Console.WriteLine("️ DIJKSTRA vs BFS - COMPARACIÓN");
            Console.WriteLine("════════════════════════════════════");

            var graph = CreateComparisonGraph();

            Console.WriteLine(" Grafo de ejemplo para comparación:");
            graph.DisplayGraph();

            Console.WriteLine("\n BFS - Búsqueda en Anchura:");
            var bfsPath = graph.GetPath("A", "E");
            Console.WriteLine($"   Ruta BFS: {string.Join(" → ", bfsPath)}");
            Console.WriteLine($"   Pasos: {bfsPath.Count - 1}");

            Console.WriteLine("\n DIJKSTRA - Camino Mínimo:");
            var dijkstraPath = DijkstraAlgorithm.GetShortestPath(graph, "A", "E");
            var dijkstraDistance = DijkstraAlgorithm.GetShortestDistance(graph, "A", "E");
            Console.WriteLine($"   Ruta Dijkstra: {string.Join(" → ", dijkstraPath)}");
            Console.WriteLine($"   Distancia total: {dijkstraDistance}");

            Console.WriteLine("\n DIFERENCIAS CLAVE:");
            ShowAlgorithmDifferences();

            Console.WriteLine("\n CUÁNDO USAR CADA UNO:");
            ShowUsageRecommendations();

            PauseForUser();
        }

        private static void RunComplexityAnalysis()
        {
            Console.Clear();
            Console.WriteLine("ANÁLISIS DE COMPLEJIDAD - DIJKSTRA");
            Console.WriteLine("═══════════════════════════════════════");

            ShowComplexityAnalysis();
            ShowPerformanceCharacteristics();
            ShowOptimizationTechniques();

            PauseForUser();
        }

        private static void RunUseCasesDemo()
        {
            Console.Clear();
            Console.WriteLine(" CASOS DE USO PRÁCTICOS - DIJKSTRA");
            Console.WriteLine("══════════════════════════════════════════");

            ShowRealWorldApplications();
            ShowIndustryExamples();
            ShowImplementationTips();

            PauseForUser();
        }

        private static void PauseForUser()
        {
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine(" Demo completado. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void DisplayDijkstraResults<T>(DijkstraResult<T> result)
        {
            foreach (var vertex in result.Distances.Keys)
            {
                if (!vertex.Equals(result.Source))
                {
                    string distance = result.Distances[vertex] == int.MaxValue ? "∞" : result.Distances[vertex].ToString();
                    string path = result.HasPath(vertex) ? string.Join(" → ", result.GetPath(vertex)) : "Sin ruta";
                    
                    Console.WriteLine($"    {vertex}: {distance} unidades");
                    Console.WriteLine($"      Ruta: {path}");
                }
            }
        }

        private static void ShowSpecificRoutes(Graph<string> graph, string source, string[] destinations)
        {
            foreach (string destination in destinations)
            {
                var path = DijkstraAlgorithm.GetShortestPath(graph, source, destination);
                var distance = DijkstraAlgorithm.GetShortestDistance(graph, source, destination);
                
                if (path.Count > 0)
                {
                    Console.WriteLine($"    {source} → {destination}:");
                    Console.WriteLine($"      Ruta: {string.Join(" → ", path)}");
                    Console.WriteLine($"      Distancia: {distance} km");
                }
                else
                {
                    Console.WriteLine($"   No hay ruta de {source} a {destination}");
                }
            }
        }

        private static void AddBidirectionalTransportEdges(Graph<string> graph)
        {
            var connections = new (string, string, int)[]
            {
                ("Terminal", "Centro", 15),
                ("Terminal", "Aeropuerto", 45),
                ("Centro", "Universidad", 20),
                ("Centro", "Hospital", 12),
                ("Centro", "Mall", 25),
                ("Universidad", "Estadio", 18),
                ("Universidad", "Barrio Norte", 22),
                ("Hospital", "Aeropuerto", 35),
                ("Mall", "Estadio", 15),
                ("Mall", "Barrio Norte", 20),
                ("Estadio", "Barrio Norte", 10)
            };

            foreach (var (from, to, weight) in connections)
            {
                graph.AddEdge(to, from, weight);
            }
        }

        private static void AddBidirectionalNetworkEdges(Graph<string> graph)
        {
            var connections = new (string, string, int)[]
            {
                ("Router-A", "Router-B", 10),
                ("Router-A", "Router-C", 15),
                ("Router-B", "Router-D", 12),
                ("Router-B", "Server", 5),
                ("Router-C", "Router-D", 8),
                ("Router-C", "Router-E", 20),
                ("Router-D", "Router-E", 6),
                ("Router-D", "Client-1", 3),
                ("Router-E", "Client-2", 4),
                ("Server", "Router-A", 7)
            };

            foreach (var (from, to, weight) in connections)
            {
                graph.AddEdge(to, from, weight);
            }
        }

        private static void AddBidirectionalGPSEdges(Graph<string> graph)
        {
            var connections = new (string, string, int)[]
            {
                ("Casa", "Supermercado", 2),
                ("Casa", "Escuela", 3),
                ("Supermercado", "Banco", 1),
                ("Supermercado", "Centro Comercial", 4),
                ("Banco", "Farmacia", 2),
                ("Banco", "Trabajo", 5),
                ("Farmacia", "Trabajo", 3),
                ("Escuela", "Gasolinera", 2),
                ("Gasolinera", "Centro Comercial", 3),
                ("Centro Comercial", "Trabajo", 6)
            };

            foreach (var (from, to, weight) in connections)
            {
                graph.AddEdge(to, from, weight);
            }
        }

        private static void ShowTransportRecommendations(Graph<string> graph, string origin)
        {
            string[] popularDestinations = { "Universidad", "Hospital", "Mall", "Aeropuerto" };
            
            Console.WriteLine($"    Desde {origin}:");
            foreach (string destination in popularDestinations)
            {
                var time = DijkstraAlgorithm.GetShortestDistance(graph, origin, destination);
                if (time != int.MaxValue)
                {
                    Console.WriteLine($"      → {destination}: {time} minutos");
                }
            }
        }

        private static void ShowNetworkRoutes(Graph<string> graph, string source, string[] targets)
        {
            foreach (string target in targets)
            {
                var path = DijkstraAlgorithm.GetShortestPath(graph, source, target);
                var latency = DijkstraAlgorithm.GetShortestDistance(graph, source, target);
                
                if (path.Count > 0)
                {
                    Console.WriteLine($"    {source} → {target}:");
                    Console.WriteLine($"      Ruta: {string.Join(" → ", path)}");
                    Console.WriteLine($"      Latencia: {latency} ms");
                }
            }
        }

        private static void ShowGPSRoutes(Graph<string> graph, string home)
        {
            string[] destinations = { "Trabajo", "Supermercado", "Centro Comercial" };
            
            foreach (string destination in destinations)
            {
                var distance = DijkstraAlgorithm.GetShortestDistance(graph, home, destination);
                var path = DijkstraAlgorithm.GetShortestPath(graph, home, destination);
                
                if (path.Count > 0)
                {
                    Console.WriteLine($"    {home} → {destination}: {distance} km");
                    Console.WriteLine($"      Via: {string.Join(" → ", path)}");
                }
            }
        }

        private static void ShowRouteOptimization(Graph<string> graph, string start, string[] stops)
        {
            Console.WriteLine($"    Ruta optimizada visitando múltiples destinos:");
            
            int totalDistance = 0;
            string currentLocation = start;
            List<string> fullRoute = new List<string> { start };
            
            foreach (string stop in stops)
            {
                var distance = DijkstraAlgorithm.GetShortestDistance(graph, currentLocation, stop);
                var path = DijkstraAlgorithm.GetShortestPath(graph, currentLocation, stop);
                
                if (path.Count > 1)
                {
                    fullRoute.AddRange(path.Skip(1));
                    totalDistance += distance;
                    currentLocation = stop;
                }
            }
            
            Console.WriteLine($"      Ruta completa: {string.Join(" → ", fullRoute)}");
            Console.WriteLine($"      Distancia total: {totalDistance} km");
        }

        private static void AddVertexInteractive(Graph<string> graph)
        {
            Console.Write(" Nombre del vértice: ");
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
        }

        private static void AddWeightedEdgeInteractive(Graph<string> graph)
        {
            Console.Write(" Vértice origen: ");
            string source = Console.ReadLine();
            Console.Write(" Vértice destino: ");
            string destination = Console.ReadLine();
            Console.Write("Peso/distancia: ");
            
            if (int.TryParse(Console.ReadLine(), out int weight))
            {
                try
                {
                    graph.AddEdge(source, destination, weight);
                    Console.WriteLine($" Arista '{source}' → '{destination}' (peso: {weight}) agregada");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine(" Peso inválido");
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
                Console.WriteLine("\n ESTRUCTURA ACTUAL:");
                graph.DisplayGraph();
            }
        }

        private static void RunDijkstraInteractive(Graph<string> graph)
        {
            if (graph.IsEmpty())
            {
                Console.WriteLine(" El grafo está vacío");
                return;
            }

            Console.Write(" Vértice de origen: ");
            string source = Console.ReadLine();
            
            try
            {
                var result = DijkstraAlgorithm.FindShortestPaths(graph, source);
                Console.WriteLine($"\n⚡ RESULTADOS DE DIJKSTRA desde '{source}':");
                DisplayDijkstraResults(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private static void FindSpecificPathInteractive(Graph<string> graph)
        {
            Console.Write(" Origen: ");
            string source = Console.ReadLine();
            Console.Write(" Destino: ");
            string destination = Console.ReadLine();
            
            try
            {
                var path = DijkstraAlgorithm.GetShortestPath(graph, source, destination);
                var distance = DijkstraAlgorithm.GetShortestDistance(graph, source, destination);
                
                if (path.Count > 0)
                {
                    Console.WriteLine($" Ruta encontrada: {string.Join(" → ", path)}");
                    Console.WriteLine($" Distancia: {distance} unidades");
                }
                else
                {
                    Console.WriteLine(" No existe ruta entre los vértices");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private static void LoadSampleGraph(Graph<string> graph)
        {
            graph.Clear();
            
            string[] vertices = { "A", "B", "C", "D", "E", "F" };
            foreach (string vertex in vertices)
            {
                graph.AddVertex(vertex);
            }
            
            graph.AddEdge("A", "B", 4);
            graph.AddEdge("A", "C", 2);
            graph.AddEdge("B", "C", 1);
            graph.AddEdge("B", "D", 5);
            graph.AddEdge("C", "D", 8);
            graph.AddEdge("C", "E", 10);
            graph.AddEdge("D", "E", 2);
            graph.AddEdge("D", "F", 6);
            graph.AddEdge("E", "F", 3);
            
            Console.WriteLine(" Grafo de ejemplo cargado correctamente");
        }

        private static Graph<string> CreateComparisonGraph()
        {
            var graph = new Graph<string>();
            
            string[] vertices = { "A", "B", "C", "D", "E" };
            foreach (string vertex in vertices)
            {
                graph.AddVertex(vertex);
            }
            
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "C", 4);
            graph.AddEdge("B", "C", 2);
            graph.AddEdge("B", "D", 5);
            graph.AddEdge("C", "E", 3);
            graph.AddEdge("D", "E", 1);
            
            return graph;
        }

        private static void ShowAlgorithmDifferences()
        {
            Console.WriteLine("    BFS (Breadth-First Search):");
            Console.WriteLine("      • Encuentra camino con menos saltos");
            Console.WriteLine("      • No considera pesos de aristas");
            Console.WriteLine("      • Útil para grafos no ponderados");
            
            Console.WriteLine("\n    Dijkstra:");
            Console.WriteLine("      • Encuentra camino de menor costo total");
            Console.WriteLine("      • Considera pesos de aristas");
            Console.WriteLine("      • Óptimo para grafos ponderados");
        }

        private static void ShowUsageRecommendations()
        {
            Console.WriteLine("    Usar BFS cuando:");
            Console.WriteLine("      • Todas las aristas tienen el mismo peso");
            Console.WriteLine("      • Se busca el camino con menos pasos");
            Console.WriteLine("      • Análisis de redes sociales");
            
            Console.WriteLine("\n    Usar Dijkstra cuando:");
            Console.WriteLine("      • Las aristas tienen diferentes pesos");
            Console.WriteLine("      • Se busca optimizar costo/distancia/tiempo");
            Console.WriteLine("      • Navegación GPS, routing de red, etc.");
        }

        private static void ShowComplexityAnalysis()
        {
            Console.WriteLine(" COMPLEJIDAD TEMPORAL:");
            Console.WriteLine("   • Implementación básica: O(V²)");
            Console.WriteLine("   • Con heap binario: O((V + E) log V)");
            Console.WriteLine("   • Con heap de Fibonacci: O(V log V + E)");
            
            Console.WriteLine("\n COMPLEJIDAD ESPACIAL:");
            Console.WriteLine("   • O(V) para estructuras auxiliares");
            Console.WriteLine("   • O(V) para almacenar distancias y predecesores");
        }

        private static void ShowPerformanceCharacteristics()
        {
            Console.WriteLine("\n CARACTERÍSTICAS DE RENDIMIENTO:");
            Console.WriteLine("    Ventajas:");
            Console.WriteLine("      • Garantiza camino óptimo");
            Console.WriteLine("      • Funciona con pesos positivos");
            Console.WriteLine("      • Ampliamente optimizado");
            
            Console.WriteLine("\n   Limitaciones:");
            Console.WriteLine("      • No funciona con pesos negativos");
            Console.WriteLine("      • Más lento que BFS para grafos no ponderados");
            Console.WriteLine("      • Requiere más memoria");
        }

        private static void ShowOptimizationTechniques()
        {
            Console.WriteLine("\n TÉCNICAS DE OPTIMIZACIÓN:");
            Console.WriteLine("   1. Usar heap de prioridad (priority queue)");
            Console.WriteLine("   2. Parada temprana al encontrar destino");
            Console.WriteLine("   3. Heurística A* para casos específicos");
            Console.WriteLine("   4. Preprocesamiento para consultas frecuentes");
        }

        private static void ShowRealWorldApplications()
        {
            Console.WriteLine(" APLICACIONES DEL MUNDO REAL:");
            Console.WriteLine("    Navegación GPS:");
            Console.WriteLine("      • Google Maps, Waze");
            Console.WriteLine("      • Optimización de rutas de entrega");
            Console.WriteLine("      • Planificación de rutas de emergencia");
            
            Console.WriteLine("\n    Redes de Computadoras:");
            Console.WriteLine("      • Protocolos de enrutamiento (OSPF)");
            Console.WriteLine("      • Optimización de latencia en CDN");
            Console.WriteLine("      • Balanceadores de carga");
            
            Console.WriteLine("\n    Videojuegos:");
            Console.WriteLine("      • Pathfinding de NPCs");
            Console.WriteLine("      • Navegación de IA");
            Console.WriteLine("      • Optimización de movimiento");
            
            Console.WriteLine("\n    Finanzas:");
            Console.WriteLine("      • Arbitraje de divisas");
            Console.WriteLine("      • Optimización de portafolios");
            Console.WriteLine("      • Análisis de riesgo crediticio");
        }

        private static void ShowIndustryExamples()
        {
            Console.WriteLine("\n EJEMPLOS POR INDUSTRIA:");
            Console.WriteLine("    Logística y Transporte:");
            Console.WriteLine("      • UPS ORION (optimización de rutas)");
            Console.WriteLine("      • Amazon (rutas de drones)");
            Console.WriteLine("      • Uber/Lyft (matching conductor-pasajero)");
            
            Console.WriteLine("\n    Salud:");
            Console.WriteLine("      • Rutas de ambulancias");
            Console.WriteLine("      • Distribución de medicamentos");
            Console.WriteLine("      • Planificación hospitalaria");
            
            Console.WriteLine("\n    Utilities:");
            Console.WriteLine("      • Redes eléctricas inteligentes");
            Console.WriteLine("      • Distribución de agua");
            Console.WriteLine("      • Redes de gas natural");
        }

        private static void ShowImplementationTips()
        {
            Console.WriteLine("\n CONSEJOS DE IMPLEMENTACIÓN:");
            Console.WriteLine("    Optimizaciones:");
            Console.WriteLine("      • Usar PriorityQueue<T> en .NET 6+");
            Console.WriteLine("      • Implementar parada temprana");
            Console.WriteLine("      • Cache para consultas repetidas");
            
            Console.WriteLine("\n    Consideraciones:");
            Console.WriteLine("      • Validar pesos no negativos");
            Console.WriteLine("      • Manejar grafos desconectados");
            Console.WriteLine("      • Considerar memoria para grafos grandes");
            
            Console.WriteLine("\n    Alternativas:");
            Console.WriteLine("      • A* para heurísticas conocidas");
            Console.WriteLine("      • Bellman-Ford para pesos negativos");
            Console.WriteLine("      • Floyd-Warshall para todos los pares");
        }
    }
}