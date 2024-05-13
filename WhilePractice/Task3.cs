namespace WhilePractice
{
    public static class Task3
    {
        public static double SumSequenceElements(int n)
        {
            double i = 1;
            double sum = 0;

            if (n == 0)
            {
                return 0;
            }

            while (i <= n)
            {
                sum += 1 / GetPowerFive(i);
                i++;
            }

            return sum;
        }

        public static double GetPowerFive(double i)
        {
            double j = 1;
            double res = 1;
            while (j <= 5)
            {
                res *= i;
                j++;
            }

            return res;
        }
    }
}
