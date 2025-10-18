namespace BitCount
{
    public static class BitCount
    {
        public static int Popcnt(this ulong mask)
        {
            int cnt = 0;
            while (mask > 0)
            {
                if((mask&1) == 1)
                    cnt++;
                mask >>= 1;
            }
            return cnt;
        }

        public static int Popcnt2(this ulong mask)
        {
            int cnt =0;
            while (mask>0)
            {
                cnt++;
                mask &= mask - 1;
            }

            return cnt;
        }

        public static int Popcnt3(this ulong mask)
        {
            int cnt = 0;

            var bits = new int[256];

            for (ulong b = 0; b < 256; b++)
            {
                bits[b] = Popcnt2(b);
            }

            while (mask>0)
            {
                cnt += bits[mask & 255];
                mask >>= 8;
            }

            return cnt;
        }
    }
}