namespace HashTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();

            hashTable.Add("cat", 25);
            hashTable.Add("dog", 26);
            hashTable.Add("god", 28);
            hashTable.Add("hat", 15);
            hashTable.Add("act", 16);
            hashTable.Add("owl", 18);

            Console.WriteLine("Hashtable count: " + hashTable.Count);
            Console.WriteLine("Value of god: " + hashTable.GetValue("god"));

            Console.WriteLine("Key-Value list:");
            foreach (var node in hashTable)
            {
                Console.WriteLine(node.Key + "-" + node.Value);
            }
        }
    }
}