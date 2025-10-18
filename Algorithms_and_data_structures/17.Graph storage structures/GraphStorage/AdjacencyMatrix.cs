using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GraphStorage
{
    //2.Матрица смежности
    public class AdjacencyMatrix : IGraphStorage
    {
        private int[,] _graph;

        public void InitializeStorage(string graphPath, bool isOrgraph = false)
        {
            var text = File.ReadAllLines(graphPath);
            var verticesEdges = text[0].Split(' ');

            var verticesNumber = Convert.ToInt32(verticesEdges[0]);
            var edgesNumber = Convert.ToInt32(verticesEdges[1]);

            _graph = new int[verticesNumber, verticesNumber];

            for (int i = 1; i <= edgesNumber; i++)
            {
                var vertices = text[i].Split(' ');
                var vertice1 = Convert.ToInt32(vertices[0]);
                var vertice2 = Convert.ToInt32(vertices[1]);

                _graph[vertice1 - 1, vertice2 - 1] += 1;
                _graph[vertice2 - 1, vertice1 - 1] += 1;
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            for (int i = 0; i < _graph.GetLength(0); i++)
            {
                if (_graph[firstVertice - 1, secondVertice - 1] >= 1)
                    return true;
            }

            return false;
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            return _graph.OfType<int>()
                .Select((s, i) => new {Val = s, PosX = i / _graph.GetLength(1), PosY = i % _graph.GetLength(1)})
                .Where(t => (t.PosX == vertice - 1) && (t.Val >= 1))
                .Select(t => t.PosY + 1)
                .ToList();
        }

        public int GetVerticePower(int vertice)
        {
            var cols = _graph.GetLength(1);

            return _graph.OfType<int>()
                .Select((s, i) => new {Val = s, PosX = i / cols, PosY = i % cols})
                .Where(t => t.PosX == vertice - 1).Sum(x => x.Val);
        }
    }
}