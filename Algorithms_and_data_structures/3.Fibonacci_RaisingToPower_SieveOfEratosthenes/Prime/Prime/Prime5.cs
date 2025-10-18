using System;
using System.Collections.Generic;
using System.Linq;
using Tester;

namespace Prime
{
    //Решето Эратосфена со сложностью O(n)
    public class Prime5 : ITask
    {
        private static List<long> _pr;

        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return CountPrimes(n).ToString();
        }

        public int CountPrimes(int n)
        {
            if (n <= 1)
                return 0;
            IsPrime(n);
            return _pr.Count;
        }

        public static bool IsPrime(int n)
        {
            var lp = new long[n+1]; 
            _pr = new List<long>(n);

            for (int i = 2; i <= n; i++)
            {
                if (lp[i] == 0)
                {
                    lp[i] = i;
                    _pr.Add(i);
                }

                foreach (var p in _pr)
                    if (p <= lp[i] && p * i <= n)
                        lp[p * i] = p;
            }

            return _pr.Last() == n;
        }
    }
}