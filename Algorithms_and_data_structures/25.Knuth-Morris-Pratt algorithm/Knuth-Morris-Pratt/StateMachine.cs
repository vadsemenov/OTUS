
namespace Knuth_Morris_Pratt
{
    public class StateMachine
    {
        private const string alphabet = "ABC";
        private string pattern;

        public int[,] CreateDelta(string pattern)
        {
            this.pattern = pattern;

            var delta = new int[pattern.Length, alphabet.Length];

            for (int i = 0; i < pattern.Length; i++)
                foreach (char a in alphabet)
                {
                    string line = pattern.Left(i) + a;
                    int k = i + 1;

                    while (pattern.Left(k) != line.Right(k) && k > 0)
                    {
                        k--;
                    }

                    delta[i, a - alphabet[0]] = k;
                }

            return delta;
        }

        public int Search(string text, int[,] delta)
        {
            int q = 0;

            for (int i = 0; i < text.Length; i++)
            {
                q = delta[q, text[i] - alphabet[0]];
                if (q == pattern.Length)
                    return i - pattern.Length + 1;
            }

            return -1;
        }

    }

    public static class StringExtensions
    {
        public static string Left(this string pattern, int x) => pattern.Substring(0, x);
        public static string Right(this string pattern, int x) => pattern.Substring(pattern.Length - x);
    }
}