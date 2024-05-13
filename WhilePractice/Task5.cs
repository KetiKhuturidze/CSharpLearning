namespace WhilePractice
{
    public static class Task5
    {
        public static double GetSequenceProduct(int n)
        {
            double i = 1;
            double product = 1;

            if (n == 0)
            {
                return 0;
            }

            while (i <= n)
            {
                product *= CalcTerm(i);
                i++;
            }

            return product;
        }

        public static double CalcTerm(double i)
        {
            return 1 + (1 / (i * i));
        }
    }
}
