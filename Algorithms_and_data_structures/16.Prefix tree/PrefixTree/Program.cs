using System;

namespace PrefixTree
{
    // https://leetcode.com/problems/implement-trie-prefix-tree/
    internal class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();

            trie.Insert("car");
            trie.Insert("cat");
            trie.Insert("carrot");
            trie.Insert("cabinet");
            trie.Insert("castrol");
            trie.Insert("box");
            trie.Insert("boss");
            trie.Insert("bort");

            Console.WriteLine(trie.StartsWith("castro"));
            Console.WriteLine(trie.Search("castro"));

            Console.Read();
        }
    }

    public class Trie
    {
        public const int A = 128;

        private Node root;

        public Trie()
        {
            root = new Node();
        }

        public void Insert(string word)
        {
            Node node = root;

            foreach (var ch in word)
            {
                node = node.Next(ch);
            }

            node.IsEnd = true;
        }

        public bool Search(string word)
        {
            Node node = Go(word);

            if (node == null)
            {
                return false;
            }

            return node.IsEnd;
        }

        private Node Go(string word)
        {
            Node node = root;

            foreach (var ch in word)
            {
                if (node.Exists(ch))
                {
                    node = node.Next(ch);
                }
                else
                {
                    return null;
                }
            }

            return node;
        }

        public bool StartsWith(string prefix)
        {
            return Go(prefix) != null;
        }

        public class Node
        {
            public Node[] child;
            public bool IsEnd;

            public Node()
            {
                this.child = new Node[A];
                IsEnd = false;
            }

            public Node Next(char ch)
            {
                if (!Exists(ch))
                {
                    child[ch] = new Node();
                }
                return child[ch];
            }

            public bool Exists(char ch)
            {
                return child[ch] != null;
            }
        }

    }
}
