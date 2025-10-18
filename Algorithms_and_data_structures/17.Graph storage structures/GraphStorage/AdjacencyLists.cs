using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphStorage
{
    //7.Списки смежности (На базе LinkedList)
    public class AdjacencyLists : IGraphStorage
    {

        private LinkedList<int>[] _graph;
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

                tempGraph[i - 1] = new int[2] { vertice1, vertice2 };
            }

            FileGraphToGraph(tempGraph, verticesNumber);
        }

        private void FileGraphToGraph(int[][] tempGraph, int verticesNumber)
        {
            var edgesVertices = tempGraph.Select(x => new { Min = x.Min(), Max = x.Max() }).OrderBy(x => x.Min);

            _graph = new LinkedList<int>[verticesNumber];

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
                _graph[i - 1] = new LinkedList<int>(adjacencyVertices);
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            if (_graph[firstVertice - 1].Contains(secondVertice))
                return true;

            return false;
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            return _graph[vertice - 1].ToList();
        }

        public int GetVerticePower(int vertice)
        {
            return _graph[vertice - 1].Count;
        }
    }
}