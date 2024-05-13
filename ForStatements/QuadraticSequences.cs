namespace ForStatements
{
    public static class QuadraticSequences
    {
        public static uint CountQuadraticSequenceTerms(long a, long b, long c, long maxTerm)
        {
            long term = 0, i = 1;

            for (; term < maxTerm; i++)
            {
                term = (a * i * i) + (b * i) + c;
            }

            if (i > 0)
            {
                return (uint)(i - 1);
            }
            else
            {
                return 0;
            }
        }

        public static ulong GetQuadraticSequenceTermsProduct1(uint count)
        {
            ulong i = 1;
            ulong prod = 1;
            for (; i <= count; i++)
            {
                prod *= (7 * i * i) + (4 * i) + 2;
            }

            return prod;
        }

        public static ulong GetQuadraticSequenceProduct2(long a, long b, long c, long startN, long count)
        {
            long i = startN;
            long prod = 1;
            int j = 0;
            for (; j < count; i++)
            {
                prod *= (a * i * i) + (b * i) + c;
                j++;
            }

            return (ulong)prod;
        }
    }
}
