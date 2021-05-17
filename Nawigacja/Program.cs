using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace B12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> adjacencyMatrix;
            adjacencyMatrix = new List<List<int>>();
            adjacencyMatrix.Add(new List<int>() { 0, 5, 0, 8, 0, 0, 0 });
            adjacencyMatrix.Add(new List<int>() { 5, 0, 4, 6, 5, 0, 0 });
            adjacencyMatrix.Add(new List<int>() { 0, 4, 0, 0, 0, 0, 0 });
            adjacencyMatrix.Add(new List<int>() { 8, 6, 0, 0, 9, 0, 0 });
            adjacencyMatrix.Add(new List<int>() { 0, 5, 0, 9, 0, 12, 0 });
            adjacencyMatrix.Add(new List<int>() { 0, 0, 0, 0, 12, 0, 5 });
            adjacencyMatrix.Add(new List<int>() { 0, 0, 0, 0, 0, 5, 0 });


            int[,] graph = new int[,] { { 0, 5, 0, 8, 0, 0, 0 },
                                      { 5, 0, 4, 6, 5, 0, 0 },
                                      { 0, 4, 0, 0, 0, 0, 0 },
                                      { 8, 6, 0, 0, 9, 0, 0 },
                                      { 0, 5, 0, 9, 0, 12, 0 },
                                      { 0, 0, 0, 0, 12, 0, 5 },
                                      { 0, 0, 0, 0, 0, 5, 0 } };

            Nawigacja test = new Nawigacja();
            test.dijkstra_1(graph, "Bagatela");
            test.ListaWMacierz(adjacencyMatrix);
            test.dijkstra_2(graph, "Bagatela");
        }
          
    }
}