using System.Collections;

namespace Dijkstra;

public class Program
{
    private static int _rowsCount = 20;
    private static int _columnsCount = 30;

    private static Vertex[,] _field = new Vertex[_rowsCount, _columnsCount];
    private static bool[,] _visitedVertex = new bool[_rowsCount, _columnsCount];


    private const int PositiveInfinite = int.MaxValue - 1_000_000;

    static void Main(string[] args)
    {
        GenerateField();

        var minimalWeightPath = GetPathesWeights();
        PrintField(minimalWeightPath);
    }

    static List<(int row, int column)> GetPathesWeights()
    {
        var startPosition = (_rowsCount - 1, 0);
        var endPosition = (0, _columnsCount - 1);

        var comparer = new VertexComparer();
        var queue = new PriorityQueue<Vertex, int>(comparer);

        _field[startPosition.Item1, startPosition.Item2].MinimalPathWeight = 0;

        queue.Enqueue(_field[startPosition.Item1, startPosition.Item2], 0);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();

            _visitedVertex[vertex.Coordinate.y, vertex.Coordinate.x] = true;

            AddNeighboringVertexes(vertex, queue);
        }

        return GetMinimalPath(startPosition, endPosition);
    }

    private static List<(int row, int column)> GetMinimalPath((int y, int x) startPosition, (int y, int x) endPosition)
    {
        var minimalPath = new List<(int row, int column)>();

        var currentVertex = _field[endPosition.y, endPosition.x];

        while (true)
        {
            minimalPath.Add(currentVertex.Coordinate);

            if (currentVertex.Coordinate == startPosition)
            {
                break;
            }

            currentVertex = _field[currentVertex.ComeFromVertex.y, currentVertex.ComeFromVertex.x];
        }

        return minimalPath;
    }

    private static void AddNeighboringVertexes(Vertex vertex, PriorityQueue<Vertex, int> queue)
    {
        var y = vertex.Coordinate.y;
        var x = vertex.Coordinate.x;

        AddNeighboringVertex(vertex, queue, y - 1, x);
        AddNeighboringVertex(vertex, queue, y + 1, x);
        AddNeighboringVertex(vertex, queue, y, x - 1);
        AddNeighboringVertex(vertex, queue, y, x + 1);
    }

    private static void AddNeighboringVertex(Vertex vertex, PriorityQueue<Vertex, int> queue, int y, int x)
    {
        if (CheckIndex(y, x) && !_visitedVertex[y, x])
        {
            var neiboringVertex = _field[y, x];

            if (neiboringVertex.MinimalPathWeight > vertex.MinimalPathWeight + neiboringVertex.Value)
            {
                neiboringVertex.ComeFromVertex = vertex.Coordinate;
                neiboringVertex.MinimalPathWeight = vertex.MinimalPathWeight + neiboringVertex.Value;
            }

            queue.Enqueue(neiboringVertex, neiboringVertex.MinimalPathWeight);
        }
    }

    private static bool CheckIndex(int y, int x)
    {
        return y >= 0 && x >= 0 && y < _rowsCount && x < _columnsCount;
    }

    static void GenerateField()
    {
        var rnd = new Random(456);

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                _field[i, j] = new Vertex()
                {
                    Value = rnd.Next(10),
                    Coordinate = (i, j),
                    MinimalPathWeight = PositiveInfinite
                };
            }
        }
    }

    static void PrintField()
    {
        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                Console.Write(_field[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static void PrintField(List<(int row, int column)> path)
    {
        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                if (path.Contains((i, j)))
                {
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_field[i, j] + " ");
                    Console.ForegroundColor = oldColor;

                    continue;
                }

                Console.Write(_field[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}

public class Vertex
{
    public int Value { get; set; }

    public (int y, int x) Coordinate { get; set; }

    public (int y, int x) ComeFromVertex { get; set; }

    public int MinimalPathWeight { get; set; }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class VertexComparer : IComparer<int>
{

    public int Compare(int x, int y)
    {
        if (x > y)
        {
            return 1;
        }
        else if (x < y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}