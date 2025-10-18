using System.Collections;

namespace HashTable;

public class HashTable : IEnumerable<Node>
{
    private const int DefaultCapacity = 5;

    private int _capacity;

    private int _count;

    private Node[] _buckets;

    public int Count => _count;

    public HashTable()
    {
        _capacity = DefaultCapacity;
        _buckets = new Node[DefaultCapacity];
    }

    public void Add(string key, int value)
    {
        _count++;

        if (_count >= _capacity)
        {
            ReHash();
        }

        var bucketIndex = GetBucketIndex(key);

        if (_buckets[bucketIndex] == null)
        {
            _buckets[bucketIndex] = new Node(key, value);
        }
        else
        {
            var lastNode = _buckets[bucketIndex];

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = new Node(key, value);
        }
    }

    private int GetBucketIndex(string key)
    {
        var keySum = key.ToCharArray()
            .Select(c => (int)c)
            .Sum();

        var bucketIndex = keySum % _capacity;

        return bucketIndex;
    }

    private void ReHash()
    {
        _capacity *= 2;

        var newBuckets = new Node[_capacity];

        foreach (var node in this)
        {
            var bucketIndex = GetBucketIndex(node.Key);

            if (newBuckets[bucketIndex] == null)
            {
                newBuckets[bucketIndex] = new Node(node.Key, node.Value);
            }
            else
            {
                var lastNode = newBuckets[bucketIndex];

                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                lastNode.Next = new Node(node.Key,node.Value);
            }
        }

        _buckets = newBuckets;
    }

    public int GetValue(string key)
    {
        foreach (var node in this)
        {
            if (node.Key == key)
            {
                return node.Value;
            }
        }

        throw new Exception("HashTable does not contain this key!");
    }


    public IEnumerator<Node> GetEnumerator()
    {
        foreach (var bucket in _buckets)
        {
            if (bucket == null)
            {
                continue;
            }

            var currentNode = bucket;

            yield return currentNode;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                yield return currentNode;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}