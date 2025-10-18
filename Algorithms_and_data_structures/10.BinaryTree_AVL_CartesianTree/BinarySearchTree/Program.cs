namespace TreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new BinarySearchTree<int>();

            tree1.Insert(8);

            tree1.Insert(3);

            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(4);
            tree1.Insert(7);

            tree1.Insert(10);
            tree1.Insert(9);
            tree1.Insert(15);
            tree1.Insert(13);

            tree1.Remove(3);

            tree1.Insert(14);

            tree1.WalkInDepthRecursive(PrintIntValue);
            Console.WriteLine();

            tree1.WalkInDepth(PrintIntValue);
            Console.WriteLine();

            tree1.WalkInBreadth(PrintIntValue);
            Console.WriteLine();

            Console.WriteLine(tree1.Search(20));

            Console.WriteLine(tree1.Count);

            Console.WriteLine();

            Console.Read();
        }

        private static void PrintIntValue(int value)
        {
            Console.Write(value + " ");
        }
    }
}
