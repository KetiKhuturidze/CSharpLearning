namespace WhileStatements
{
    public static class QuadraticSequences
    {
        public static long SumQuadraticSequenceTerms1(long a, long b, long c, long maxTerm)
        {
            long sum = 0, term = 0, i = 1;

            while (term <= maxTerm)
            {
                term = (a * (i * i)) + (b * i) + c;

                if (term <= maxTerm)
                {
                    sum = sum + term;
                }

                i++;
            }

            return sum;
        }

        public static long SumQuadraticSequenceTerms2(long a, long b, long c, long startN, long count)
        {
            long sum = 0;
            long term = 0;
            long counter = 0;

            while (counter < count)
            {
                term = (a * (startN * startN)) + (b * startN) + c;
                sum += term;
                startN++;
                counter++;
            }

            return sum;
        }
    }
}
