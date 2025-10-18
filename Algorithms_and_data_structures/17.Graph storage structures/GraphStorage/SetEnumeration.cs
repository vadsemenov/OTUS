using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphStorage
{
    //1. Перечисление множеств (на основе хэш таблицы) 
    public class SetEnumeration : IGraphStorage
    {
        private Dictionary<int, int[]> _graph = new Dictionary<int, int[]>();

        public void InitializeStorage(string graphPath, bool isOrgraph = false)
        {
            var text = File.ReadAllLines(graphPath);
            var verticesEdges = text[0].Split(' ');

            var verticesNumber = Convert.ToInt32(verticesEdges[0]);
            var edgesNumber = Convert.ToInt32(verticesEdges[1]);

            for (int i = 1; i <= edgesNumber; i++)
            {
                var vertices = text[i].Split(' ');
                _graph.Add(i, new int[2] {Convert.ToInt32(vertices[0]), Convert.ToInt32(vertices[1])});
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            return _graph.Values.Select(x => (x[0] == firstVertice && x[1] == secondVertice) ||
                                                        (x[1] == firstVertice && x[0] == secondVertice))
                .FirstOrDefault(x => x);
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            return _graph.Values.Where(x => x[0] == vertice || x[1] == vertice).Select(x =>
            {
                if (x[0] == vertice)
                    return x[1];

                return x[0];
            }).ToList();
        }

        public int GetVerticePower(int vertice)
        {
            return _graph.Values.Select(x =>
            {
                var count = 0;
                if (x[0] == vertice)
                    count++;
                if (x[1] == vertice)
                    count++;
                return count;
            }).Sum();
        }
    }
}