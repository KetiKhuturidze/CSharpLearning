namespace ForStatements
{
    public static class GeometricSequences
    {
        public static ulong GetGeometricSequenceTermsProduct(uint a, uint r, uint n)
        {
            ulong product = 1;
            int i = 0;
            ulong rpow;

            for (; i < n; i++)
            {
                rpow = 1;
                int j = 0;
                for (; j < i; j++)
                {
                    rpow *= r;
                }

                product *= a * rpow;
            }

            return product;
        }

        public static ulong SumGeometricSequenceTerms(uint n)
        {
            const uint r = 3, firstTerm = 5;

            uint i = 0, j, rpow, sum = 0;

            for (; i < n; i++)
            {
                j = 0;

                rpow = 1;

                for (; j < i; j++)
                {
                    rpow *= r;
                }

                sum += rpow * firstTerm;
            }

            return sum;
        }

        public static ulong CountGeometricSequenceTerms1(uint a, uint r, uint maxTerm)
        {
            ulong nTerm = 0, i = 0, rpow, j;

            if (maxTerm < a)
            {
                return 0;
            }

            for (; nTerm <= maxTerm;)
            {
                j = 0;
                rpow = 1;
                for (; j < i; j++)
                {
                    rpow *= r;
                }

                nTerm = rpow * a;

                if (maxTerm == nTerm)
                {
                    return i + 1;
                }

                i++;
            }

            return i;
        }

        public static ulong CountGeometricSequenceTerms2(uint a, uint r, uint n, uint minTerm)
        {
            uint nTerm = 0, i = 0, rpow, j, count = 0;

            if (minTerm == 0)
            {
                return n;
            }

            for (; i < n;)
            {
                j = 0;
                rpow = 1;
                for (; j < i;)
                {
                    rpow *= r;
                    j++;
                }

                nTerm = rpow * a;

                if (minTerm == nTerm)
                {
                    return n - i;
                }

                i++;
            }

            return count;
        }
    }
}
