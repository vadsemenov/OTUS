using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphStorage
{
    //8.Структура с оглавлением
    public class StructureWithTableOfContents:IGraphStorage
    {
        private int[] _tableofContent;

        private int[] _structure;

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

            _tableofContent = new int[verticesNumber+1];

            FileGraphToGraph(tempGraph, verticesNumber);
        }

        private void FileGraphToGraph(int[][] tempGraph, int verticesNumber)
        {
            var edgesVertices = tempGraph.Select(x => new { Min = x.Min(), Max = x.Max() }).OrderBy(x => x.Min);

            //-------Get structure size-----------------
            var verticesPower = new int[verticesNumber];

            for (int i = 1; i <= verticesNumber; i++)
            {
                verticesPower[i - 1] = edgesVertices.Count(x => x.Min == i || x.Max == i);
            }

            var maxPower = verticesPower.Max();

            _structure = new int[verticesNumber * maxPower + 1];
            //-------Get structure size-----------------

            var structureIndex = 0;
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

                _tableofContent[i - 1] = structureIndex;
                Array.Copy(adjacencyVertices,0,_structure,structureIndex,adjacencyVertices.Length);
                structureIndex += adjacencyVertices.Length;
            }

            _structure[structureIndex] = -1;
            _tableofContent[_tableofContent.Length - 1] = structureIndex;

        }

        public bool IsAdjacentcyVertices(int firstVertice, int secondVertice)
        {
            for (int i = _tableofContent[firstVertice-1]; i < _tableofContent[firstVertice]; i++)
            {
                if (_structure[i]==secondVertice)
                    return true;
            }

            return false;
        }

        public List<int> GetAdjacentcyVertices(int vertice)
        {
            var result = new List<int>();
            
            for (int i = _tableofContent[vertice - 1]; i < _tableofContent[vertice]; i++)
            {
                result.Add(_structure[i]);
            }

            return result;
        }

        public int GetVerticePower(int vertice)
        {
            return _tableofContent[vertice] - _tableofContent[vertice - 1];
        }
    }
}