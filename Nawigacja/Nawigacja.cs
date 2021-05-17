using System;
using System.Collections.Generic;
using System.Text;

namespace B12
{
    class Nawigacja
    {
        // Funkcja narzędzia do znajdowania pliku
        // wierzchołek z minimalną odległością
        // wartość ze zbioru wierzchołków
        // jeszcze nie uwzględniono w najkrótszym
        // drzewo ścieżki
        static int V = 7;
        private static readonly int NO_PARENT = -1;

        public List<string> vertices { get; private set; } = new List<string>()
            {
                "Bagatela",
                "Dworzec",
                "Politechnika",
                "Stradom",
                "R. Mogilskie",
                "R. Czyzynskie",
                "Nowa Huta",
            };

        public int[,] ListaWMacierz(List<List<int>> list)
        {

            // Initialize a matrix
            int[,] matrix = new int[list.Count, list.Count];

            for (int i = 0; i <list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                    matrix[i, j]=list[i][j];
            }
            //printMatrix(matrix, V);
            return matrix;
        }

        int minDistance(int[] dist, bool[] sptSet)
        {
            // Inicjalizuj wartość minimalną 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            return min_index;            
        }

        // Funkcja narzędziowa do drukowania
        // skonstruowana tablica odległości 
        void printSolution_1(int[] dist)
        {
            
            for (int i = 0; i < V; i++)
                Console.Write(vertices[i] + ": \t\t " + dist[i] + "\n");
        }

        
        // Funkcja implementująca Dijkstry
        // algorytm najkrótszej ścieżki z jednego źródła
        // dla wykresu reprezentowanego za pomocą sąsiedztwa
        // reprezentacja macierzy

        public void dijkstra_1(int[,] graph, string nazwa)
        {
            int src = vertices.BinarySearch(nazwa);
            //int[,] graph = ListaWMacierz(list);

            int[] dist = new int[V]; // Tablica wyjściowa. dist [i]
                                     // zatrzyma najkrótsze
                                     // odległość od źródła do i

            // sptSet [i] będzie prawdziwe, jeśli wierzchołek
            // i jest zawarte w najkrótszej ścieżce
            // drzewo lub najkrótsza odległość od
            // src do i jest sfinalizowane
            bool[] sptSet = new bool[V];

            // Zainicjuj wszystkie odległości jako
            // INFINITE i stpSet [] jako false
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Odległość wierzchołka źródłowego
            // od siebie zawsze wynosi 0
            dist[src] = 0;

            // Znajdź najkrótszą ścieżkę dla wszystkich wierzchołków
            for (int count = 0; count < V - 1; count++)
            {
                // Wybierz minimalną odległość wierzchołka
                // z zestawu wierzchołków jeszcze nie
                // przetworzone. u jest zawsze równe
                // src w pierwszej iteracji.
                int u = minDistance(dist, sptSet);

                // Oznacz wybrany wierzchołek jako przetworzony
                sptSet[u] = true;

                // Zaktualizuj wartość odległości sąsiedniego
                // wierzchołka od wskazanego wierzchołka.
                for (int v = 0; v < V; v++)
                {                    
                    // Aktualizuj dist [v] tylko wtedy, gdy go nie ma
                    // sptSet, jest krawędź od u
                    // do v i całkowita waga ścieżki
                    // od src do v przez u jest mniejsze
                    // niż aktualna wartość dist [v]
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }                    
                }
                
            }
            printSolution_1(dist);
           
        }

        public void dijkstra_2(int[,] graph, string nazwa )
        {
            int startVertex = vertices.BinarySearch(nazwa);
            int nVertices = graph.GetLength(0);

            // shortestDistances[i] will hold the  
            // shortest distance from src to i  
            int[] shortestDistances = new int[nVertices];

            // added[i] will true if vertex i is  
            // included / in shortest path tree  
            // or shortest distance from src to  
            // i is finalized  
            bool[] added = new bool[nVertices];

            // Initialize all distances as  
            // INFINITE and added[] as false  
            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            // Distance of source vertex from  
            // itself is always 0  
            shortestDistances[startVertex] = 0;

            // Parent array to store shortest  
            // path tree  
            int[] parents = new int[nVertices];

            // The starting vertex does not  
            // have a parent  
            parents[startVertex] = NO_PARENT;

            // Find shortest path for all  
            // vertices  
            for (int i = 1; i < nVertices; i++)
            {

                // Pick the minimum distance vertex  
                // from the set of vertices not yet  
                // processed. nearestVertex is  
                // always equal to startNode in  
                // first iteration.  
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                // Mark the picked vertex as  
                // processed  
                added[nearestVertex] = true;

                // Update dist value of the  
                // adjacent vertices of the  
                // picked vertex.  
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    int edgeDistance = graph[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) <
                            shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }

            printSolution(startVertex, shortestDistances, parents);
        }


    

            // wypisuje skonstruowaną tablicę odległości
            private void printSolution(int startVertex, int[] distances, int[] parents)
            {
                int nVertices = vertices.Count;
                Console.Write("");

                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    if (vertexIndex != startVertex)
                    {
                        Console.Write("\n "+ vertices[startVertex] + " to "+ vertices[vertexIndex] + " : ");
                        printPath(vertexIndex, parents);
                    }
                }
            }

            // Function to print shortest path  
            // from source to currentVertex  
            // using parents array  
            private void printPath(int currentVertex, int[] parents)
            {

                // Base case : Source node has  
                // been processed  
                if (currentVertex == NO_PARENT)
                {
                    return;
                }
                printPath(parents[currentVertex], parents);
                Console.Write(vertices[currentVertex]+ ", ");
            }
    }
}


