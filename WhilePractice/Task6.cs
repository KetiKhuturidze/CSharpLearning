namespace WhilePractice
{
    public static class Task6
    {
        public static double SumSequenceElements(int n)
        {
            double i = 1;
            double sum = 0;
            double sign = -1;
            if (n == 0)
            {
                return 0;
            }

            while (i <= n)
            {
                sum += sign / ((2 * i) + 1);
                sign *= -1;
                i++;
            }

            return sum;
        }
    }
}
