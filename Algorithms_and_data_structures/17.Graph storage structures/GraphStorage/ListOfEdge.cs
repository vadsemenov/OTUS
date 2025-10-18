using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphStorage
{
    //4.Перечень рёбер
    public class ListOfEdge : IGraphStorage
    {
        private int[][] _graph;

        public void InitializeStorage(string graphPath, bool isOrgraph = false)
        {
            var text = File.ReadAllLines(graphPath);
            var verticesEdges = text[0].Split(' ');

            var verticesNumber = Convert.ToInt32(verticesEdges[0]);
            var edgesNumber = Convert.ToInt32(verticesEdges[1]);

            _graph = new int[edgesNumber][];

            for (int i = 1; i <= edgesNumber; i++)
            {
                var vertices = text[i].Split(' ');
                var vertice1 = Convert.ToInt32(vertices[0]);
                var vertice2 = Convert.ToInt32(vertices[1]);

                _graph[i - 1] = new int[2] {vertice1, vertice2};
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            return _graph.Select(x =>
                    (x[0] == firstVertice && x[1] == secondVertice) || (x[1] == firstVertice && x[0] == secondVertice))
                .FirstOrDefault();
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            return _graph.Select(x =>
            {
                if (x[0] == vertice)
                    return x[1];
                if (x[1] == vertice)
                    return x[0];

                return -1;
            }).Where(x => x != -1).ToList();
        }

        public int GetVerticePower(int vertice)
        {
            return _graph.Sum(x =>
            {
                var count = 0;
                if (x[0] == vertice)
                    count++;
                if (x[1] == vertice)
                    count++;

                return count;
            });
        }
    }
}