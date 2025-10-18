using System;
using Tester;

namespace LuckyNumberRecursive
{
    public class LuckyNumber : ITask
    {
        private long count = 0;

        public string Run(string [] data)
        {
            int N = Convert.ToInt32(data[0]);
            count = 0;
            GetLuckyCount(N, 0, 0);
            return count.ToString();
        }

        void GetLuckyCount(int N, int sumA, int sumB)
        {
            if (N == 0)
            {
                if (sumA == sumB)
                    count++;
                return;
            }

            for (int a = 0; a <= 9; a++)
            for (int b = 0; b <= 9; b++)
                GetLuckyCount(N - 1, sumA + a, sumB + b);
        }
    }
}