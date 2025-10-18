using System;
using System.Collections.Generic;
using System.IO;

namespace GraphStorage
{
    //3.Матрица инцидентности
    public class IncidenceMatrix:IGraphStorage
    {
        private int[,] _graph;
        public void InitializeStorage(string graphPath, bool isOrgraph = false)
        {
            var text = File.ReadAllLines(graphPath);
            var verticesEdges = text[0].Split(' ');

            var verticesNumber = Convert.ToInt32(verticesEdges[0]);
            var edgesNumber = Convert.ToInt32(verticesEdges[1]);

            _graph = new int[verticesNumber, edgesNumber];

            for (int i = 1; i <= edgesNumber; i++)
            {
                var vertices = text[i].Split(' ');
                var vertice1 = Convert.ToInt32(vertices[0]);
                var vertice2 = Convert.ToInt32(vertices[1]);

                _graph[vertice1 - 1, i-1] += 1;
                _graph[vertice2 - 1, i-1] += 1;
            }
        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            for (int i = 0; i < _graph.GetLength(1); i++)
            {
                if (_graph[firstVertice-1,i]==1 && _graph[secondVertice - 1, i] == 1)
                    return true;

                if (firstVertice == secondVertice && _graph[firstVertice - 1, i] == 2)
                    return true;
            }

            return false;
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            var result = new List<int>();

            for (int i = 0; i < _graph.GetLength(1); i++)
            {
                if (_graph[vertice - 1, i] == 1)
                    for (int j = 0; j < _graph.GetLength(0); j++)
                    {
                        if(j!=vertice-1 && _graph[j,i] ==1)
                            result.Add(j+1);
                    }

                if(_graph[vertice - 1, i] == 2)
                    result.Add(vertice);
            }

            return result;
        }

        public int GetVerticePower(int vertice)
        {
            var power = 0;
            for (int i = 0; i < _graph.GetLength(1); i++)
            {
                power += _graph[vertice - 1, i];
            }
            return power;
        }
    }
}