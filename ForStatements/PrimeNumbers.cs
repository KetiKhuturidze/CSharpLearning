namespace ForStatements
{
    public static class PrimeNumbers
    {
        public static bool IsPrimeNumber(uint n)
        {
            int i = 2, count = 1;
            for (; i <= n;)
            {
                if (n % i == 0)
                {
                    count++;
                }

                i++;
            }

            return count == 2;
        }

        public static ulong SumDigitsOfPrimeNumbers(int start, int end)
        {
            uint sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    sum += SumDigits(i);
                }
            }

            return sum;
        }

        private static uint SumDigits(int i)
        {
            int sumDigits = 0;
            for (; i > 0; i /= 10)
            {
                sumDigits += i % 10;
            }

            return (uint)sumDigits;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (uint i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}