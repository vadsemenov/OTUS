using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStorage
{
    //https://habr.com/ru/company/otus/blog/568026/
    //https://habr.com/ru/company/otus/blog/675730/
    public class Program
    {
        static void Main(string[] args)
        {
            var listGraphs = new List<IGraphStorage>();

            listGraphs.Add(new SetEnumeration());
            listGraphs.Add(new AdjacencyMatrix());
            listGraphs.Add(new IncidenceMatrix());
            listGraphs.Add(new ListOfEdge());
            listGraphs.Add(new AdjacencyVectors());
            listGraphs.Add(new AdjacencyArrays());
            listGraphs.Add(new AdjacencyLists());
            listGraphs.Add(new StructureWithTableOfContents());

            TestStorage(listGraphs);

            Console.Read();
        }

        public static void TestStorage(List<IGraphStorage> listGraph)
        {
            string filePath = @"G:\OTUS\Algorithms and data structures\17.Graph storage structures\Graphs\Graph1.txt";

            foreach (var graph in listGraph)
            {
                graph.InitializeStorage(filePath);

                Console.WriteLine("");
                Console.WriteLine("========"+graph.GetType()+"========");
                Console.WriteLine("5 and 1 Is Adjacentcy Vertices = " + graph.IsAdjacentcyVertices(5, 1));
                Console.WriteLine("2nd vertice power = " + graph.GetVerticePower(2));
                Console.WriteLine("2nd vertice Adjacentcy Vertices = " + string.Join(" ", graph.GetAdjacentcyVertices(2)));
            }
        }
    }
}
