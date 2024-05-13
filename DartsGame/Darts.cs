using System;

namespace DartsGame
{
    public static class Darts
    {
        public static int GetScore(double x, double y)
        {
            double distance = Math.Sqrt((x * x) + (y * y));

            if (distance > 10)
            {
                return 0;
            }
            else if (distance <= 1)
            {
                return 10;
            }
            else if (distance <= 5)
            {
                return 5;
            }
            else
            {
                return 1;
            }
        }
    }
}
