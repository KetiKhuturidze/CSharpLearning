namespace WhileStatements
{
    public static class GeometricSequences
    {
        public static uint SumGeometricSequenceTerms1(uint a, uint r, uint n)
        {
            uint sum = 0;
            uint i = 0, j, rpow;

            while (i < n)
            {
                j = 0;

                rpow = 1;

                while (j < i)
                {
                    rpow *= r;

                    j++;
                }

                sum += rpow * a;

                i++;
            }

            return sum;
        }

        public static uint SumGeometricSequenceTerms2(uint n)
        {
            const uint r = 3, firstTerm = 13;

            uint i = 0, j, rpow, sum = 0;

            while (i < n)
            {
                j = 0;

                rpow = 1;

                while (j < i)
                {
                    rpow *= r;

                    j++;
                }

                sum += rpow * firstTerm;

                i++;
            }

            return sum;
        }

        public static uint CountGeometricSequenceTerms3(uint a, uint r, uint maxTerm)
        {
            uint nTerm = 0, i = 0, rpow, j;

            if (maxTerm < a)
            {
                return 0;
            }

            while (nTerm <= maxTerm)
            {
                j = 0;
                rpow = 1;
                while (j < i)
                {
                    rpow *= r;
                    j++;
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

        public static uint CountGeometricSequenceTerms4(uint a, uint r, uint n, uint minTerm)
        {
            uint nTerm = 0, i = 0, rpow, j, count = 0;

            if (minTerm == 0)
            {
                return n;
            }

            while (i < n)
            {
                j = 0;
                rpow = 1;
                while (j < i)
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
