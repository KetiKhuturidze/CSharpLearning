namespace ForStatements
{
    public static class Factorial
    {
        public static int GetFactorial(int n)
        {
            int prod = 1;
            for (; n > 0; n--)
            {
                prod *= n;
            }

            return prod;
        }

        public static int SumFactorialDigits(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int prod = 1;
            for (; n > 0; n--)
            {
                prod *= n;
            }

            int sum = 0;

            for (; prod > 0; prod /= 10)
            {
                sum += prod % 10;
            }

            return sum;
        }
    }
}
