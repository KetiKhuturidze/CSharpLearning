namespace WhilePractice
{
    public static class Task4
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
                sum += 1 / (((2 * i) + 1) * ((2 * i) + 1));
                i++;
                }

                return sum;
        }
    }
}
