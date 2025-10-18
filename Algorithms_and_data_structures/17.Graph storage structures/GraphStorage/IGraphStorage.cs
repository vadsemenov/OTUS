using System.Collections.Generic;

namespace GraphStorage
{
    public interface IGraphStorage
    {
        void InitializeStorage(string graphPath, bool isOrgraph = false);
        bool IsAdjacentcyVertices(int firstVertice, int secondVertice);
        List<int> GetAdjacentcyVertices(int vertice);
        int GetVerticePower(int vertice);
        // int[] GetEdge(int edgeNumber);
        // void SetEdge(int verticeNumber, int firstVertice, int secondVertice);
    }
}