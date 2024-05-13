namespace WhilePractice
{
    public static class Task1
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
                sum += 1 / i;
                i++;
            }

            return sum;
        }
    }
}
