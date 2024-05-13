namespace ForStatements
{
    public static class FibonacciSequence
    {
        public static int GetFibonacciNumber(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            int prevTerm = 1;
            int currentTerm = 1;

            for (int i = 3; i <= n; i++)
            {
                currentTerm = prevTerm + currentTerm;
                prevTerm = currentTerm - prevTerm;
            }

            return currentTerm;
        }

        public static ulong GetProductOfFibonacciNumberDigits(ulong n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            ulong prevTerm = 1;
            ulong currentTerm = 1;

            for (ulong i = 3; i <= n; i++)
            {
                currentTerm = prevTerm + currentTerm;
                prevTerm = currentTerm - prevTerm;
            }

            ulong prod = 1;

            for (; currentTerm > 0; currentTerm /= 10)
            {
                prod *= currentTerm % 10;
            }

            return prod;
        }
    }
}
