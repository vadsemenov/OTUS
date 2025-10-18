using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GraphStorage
{
    //5.Векторы смежности
    public class AdjacencyVectors : IGraphStorage
    {
        private int[,] _graph;

        public void InitializeStorage(string graphPath, bool isOrgraph = false)
        {
            var text = File.ReadAllLines(graphPath);
            var verticesEdges = text[0].Split(' ');

            var verticesNumber = Convert.ToInt32(verticesEdges[0]);
            var edgesNumber = Convert.ToInt32(verticesEdges[1]);

            var tempGraph = new int[edgesNumber][];

            for (int i = 1; i <= edgesNumber; i++)
            {
                var vertices = text[i].Split(' ');
                var vertice1 = Convert.ToInt32(vertices[0]);
                var vertice2 = Convert.ToInt32(vertices[1]);

                tempGraph[i - 1] = new int[2] {vertice1, vertice2};
            }

            FileGraphToGraph(tempGraph, verticesNumber);
        }

        private void FileGraphToGraph(int[][] tempGraph, int verticesNumber)
        {
            var edgesVertices = tempGraph.Select(x => new {Min = x.Min(), Max = x.Max()}).OrderBy(x => x.Min);
            var verticesPower = new int[verticesNumber];

            for (int i = 1; i <= verticesNumber; i++)
            {
                verticesPower[i - 1] = edgesVertices.Count(x => x.Min == i || x.Max == i);
            }

            var maxPower = verticesPower.Max();

            _graph = new int[verticesNumber, maxPower];

            for (int i = 1; i <= verticesNumber; i++)
            {
                var adjacencyVertices = edgesVertices
                    .Where(x => x.Min == i || x.Max == i)
                    .Select(x =>
                    {
                        if (x.Min == i)
                            return x.Max;

                        if (x.Max == i && x.Min != i)
                            return x.Min;

                        return -1;
                    })
                    .OrderBy(x => x)
                    .Where(x => x != -1).ToArray();

                for (int j = 0; j < adjacencyVertices.Length; j++)
                {
                    _graph[i - 1, j] = adjacencyVertices[j];
                }
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            for (int i = firstVertice; i < _graph.GetLength(1); i++)
                if (_graph[firstVertice - 1, i] == secondVertice)
                    return true;

            return false;
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            var vertices = new List<int>();
            for (int i = 0; i < _graph.GetLength(1); i++)
            {
                if (_graph[vertice - 1, i] != 0)
                    vertices.Add(_graph[vertice - 1, i]);
            }

            return vertices;
        }

        public int GetVerticePower(int vertice)
        {
            var count=0;

            for (int i = 0; i < _graph.GetLength(1); i++)
            {
                if (_graph[vertice - 1, i] != 0)
                    count++;
            }

            return count;
        }
    }
}