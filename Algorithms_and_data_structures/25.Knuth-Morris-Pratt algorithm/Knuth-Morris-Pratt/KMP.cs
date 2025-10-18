namespace Knuth_Morris_Pratt
{
    public class KMP
    {
        public int[] GetPiSlow(string pattern)
        {
            int[] result = new int[pattern.Length + 1];

            for (int i = 2; i < result.Length; i++)
            {
                string line = pattern.Substring(0, i);

                int pi = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    string left = line.Substring(0, j);
                    string right = line.Substring(line.Length - j);

                    if (left == right)
                    {
                        pi = j;
                    }
                }

                result[i] = pi;
            }

            return result;
        }

        public int[] GetPiFast(string pattern)
        {
            int[] pi = new int[pattern.Length + 1];

            pi[1] = 0;

            for (int q = 1; q < pattern.Length; q++)
            {
                int len = pi[q];
                while (len > 0 && pattern[len] != pattern[q])
                {
                    len = pi[len];
                }

                if (pattern[len] == pattern[q])
                {
                    len++;
                }

                pi[q + 1] = len;
            }

            return pi;
        }

        public int PrefixFind(string text, string pattern, int[] pi)
        {
            pi[0] = 0; // в i-м элементе (его индекс i-1) количество совпавших 
                       // символов в начале образца и в конце подстроки длины i. 
                       // p[0]=0 всегда, p[1]=1, если начинается с двух одинаковых 
            int l;     // будет длина образца

            int j;

            // заполняем массив длин префиксов для образца
            for (l = 1; l < pattern.Length; ++l)
            {
                j = pi[l - 1];

                while ((j > 0) && (pattern[l] != pattern[j])) // не равны
                {
                    j = pi[j - 1]; // берем ранее рассчитанное значение (начиная с максимально возможных)
                }

                if (pattern[l] == pattern[j]) // равны 
                {
                    ++j;
                }

                pi[l] = j;
            }

            j = 0; // количество совпавших символов, оно же индекс сравниваемого 
                   // символа в образце. В строке сравниваемый символ будет иметь индекс i

            for (int i = 0; i < text.Length; ++i)
            {
                while ((j > 0) && (text[i] != pattern[j]))
                {
                    // Очередной символ строки не совпал с символом в образце. Сдвигаем образец, 
                    // причем точно знаем, что первые j символов образца совпали с символами строки 
                    // и надо сравнить j+1й символ образца (его индекс j) с i+1м символом строки.
                    // если j=0, то достигли начала образца и цикл следует прервать
                    j = pi[j - 1];
                }

                if (text[i] == pattern[j]) // есть совпадение очередного символа 
                {
                    ++j; // увеличиваем длину совпавшего фрагмента на 1
                }

                if (j == l)
                {
                    return (i - l + 1);
                }
            }

            return -1;
        }
    }
}