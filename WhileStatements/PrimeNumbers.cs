namespace WhileStatements
{
    public static class PrimeNumbers
    {
        public static bool IsPrimeNumber(uint n)
        {
            int i = 2, count = 1;
            while (i <= n)
            {
                if (n % i == 0)
                {
                    count++;
                }

                i++;
            }

            return count == 2;
        }

        public static uint GetLastPrimeNumber(uint n)
        {
            uint latestPrime;
            int i = 2, count = 1;

            if (n == 1)
            {
                return 0;
            }

            while (i <= n)
            {
                latestPrime = n;
                count = 1;
                while (i <= latestPrime)
                {
                    if (latestPrime % i == 0)
                    {
                        count++;
                    }

                    i++;
                }

                if (count == 2)
                {
                    return n;
                }

                i = 2;
                n--;
            }

            return n;
        }

        public static uint SumLastPrimeNumbers(uint n, uint count)
        {
            if (count == 0)
            {
                return 0;
            }

            uint sum = 0;
            uint currentNumber = n;

            while (count > 0)
            {
                if (IsPrime(currentNumber))
                {
                sum += currentNumber;
                count--;
                }

                if (currentNumber == 0)
                {
                    break;
                }

                currentNumber--;
            }

            return sum;
        }

        private static bool IsPrime(uint number)
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
