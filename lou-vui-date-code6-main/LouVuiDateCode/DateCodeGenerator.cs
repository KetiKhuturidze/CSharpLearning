using System;
using System.Globalization;
using System.Text;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear >= 1990 || manufacturingYear < 1980)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth > 12 || manufacturingMonth < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            string man = manufacturingYear.ToString();
            string answ = man[^2..] + manufacturingMonth.ToString();
            return answ;
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year >= 1990 || manufacturingDate.Year < 1980)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (manufacturingDate.Month > 12 || manufacturingDate.Month < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            string manYear = manufacturingDate.Year.ToString();
            string manMonth = manufacturingDate.Month.ToString();

            string answ = manYear[^2..] + manMonth.ToString();

            return answ;
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1986 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("invalid factory loc code");
            }

            string answ = manufacturingYear.ToString()[^2..] + manufacturingMonth.ToString() + factoryLocationCode.ToUpper();
            return answ;
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year >= 1990 || manufacturingDate.Year < 1980)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (manufacturingDate.Month > 12 || manufacturingDate.Month < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("invalid factory loc code");
            }

            string manYear = manufacturingDate.Year.ToString();
            string manMonth = manufacturingDate.Month.ToString();

            string answ = manYear[^2..] + manMonth.ToString() + factoryLocationCode.ToUpper();

            return answ;
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingMonth > 12 || manufacturingMonth < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("invalid factory loc code");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(factoryLocationCode.ToUpper());

            if (manufacturingMonth >= 1 && manufacturingMonth <= 9)
            {
                sb.Append('0').Append(manufacturingYear.ToString()[2]).Append(manufacturingMonth).Append(manufacturingYear.ToString()[3]);
            }
            else if (manufacturingMonth >= 10)
            {
                sb.Append(manufacturingMonth.ToString()[0]).Append(manufacturingYear.ToString()[2]).Append(manufacturingMonth.ToString()[1]).Append(manufacturingYear.ToString()[3]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year < 1990 || manufacturingDate.Year > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Invalid manufacturing year");
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("Invalid factory loc code");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(factoryLocationCode.ToUpper());

            string manufacturingYear = manufacturingDate.Year.ToString();
            uint manufacturingMonth = (uint)manufacturingDate.Month;

            if (manufacturingMonth >= 1 && manufacturingMonth <= 9)
            {
                sb.Append('0').Append(manufacturingYear[2]).Append(manufacturingMonth).Append(manufacturingYear[3]);
            }
            else if (manufacturingMonth >= 10)
            {
                sb.Append(manufacturingMonth.ToString()[0]).Append(manufacturingYear[2]).Append(manufacturingMonth.ToString()[1]).Append(manufacturingYear[3]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int currentYear = DateTime.Now.Year;

            if (manufacturingYear < 2007 || manufacturingYear > currentYear)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            if (manufacturingWeek > 53)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            DateTime lastThursday = GetLastThursdayOfYear((int)manufacturingYear);
            Calendar calendar = CultureInfo.InvariantCulture.Calendar;
            int lastWeekNumber = calendar.GetWeekOfYear(lastThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            static DateTime GetLastThursdayOfYear(int year)
            {
                DateTime lastDayOfYear = new DateTime(year, 12, 31);
                DayOfWeek dayOfWeek = lastDayOfYear.DayOfWeek;

                int daysToLastThursday = (dayOfWeek - DayOfWeek.Thursday + 7) % 7;

                return lastDayOfYear.AddDays(-daysToLastThursday);
            }

            bool has53Weeks = lastWeekNumber == 53;

            if (manufacturingWeek >= 53 && !has53Weeks)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("Invalid factory loc code");
            }

            StringBuilder sb = new StringBuilder();

            if (manufacturingWeek <= 9)
            {
                sb.Append('0');
            }
            else
            {
                sb.Append(manufacturingWeek.ToString()[0]);
            }

            sb.Append(manufacturingYear.ToString()[2]);
            if (manufacturingWeek <= 9)
            {
                sb.Append(manufacturingWeek.ToString()[0]);
            }
            else
            {
                sb.Append(manufacturingWeek.ToString()[1]);
            }

            sb.Append(manufacturingYear.ToString()[3]);

            return factoryLocationCode.ToUpper() + sb.ToString();
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int currentYear = DateTime.Now.Year;

            if (manufacturingDate.Year < 2007 || manufacturingDate.Year > currentYear)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            int weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            bool canBe53 = false;

            if (manufacturingDate.Day == 1 && manufacturingDate.DayOfWeek == DayOfWeek.Thursday)
            {
                canBe53 = true;
            }

            if (weekNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (weekNumber > 53 && !canBe53)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out int result) || int.TryParse(factoryLocationCode[1].ToString(), out int rr))
            {
                throw new ArgumentException("Invalid factory loc code");
            }

            StringBuilder sb = new StringBuilder();

            if (weekNumber <= 9)
            {
                sb.Append('0');
            }
            else
            {
                sb.Append(weekNumber.ToString()[0]);
            }

            sb.Append(manufacturingDate.Year.ToString()[2]);
            if (weekNumber <= 9)
            {
                sb.Append(weekNumber.ToString()[0]);
            }
            else
            {
                sb.Append(weekNumber.ToString()[1]);
            }

            DateTime gmtPlus4DateTime = manufacturingDate;

            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(gmtPlus4DateTime, TimeZoneInfo.Utc);

            long epochTime = (long)(utcDateTime - new DateTime(1970, 1, 1)).TotalSeconds;

            DateTimeOffset dTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochTime);
            DateTime dateTime = dTimeOffset.DateTime;
            int year = dateTime.Year;

            if (year != manufacturingDate.Year)
            {
                sb.Append(year.ToString()[3]);
            }
            else
            {
                sb.Append(manufacturingDate.Year.ToString()[3]);
            }

            return factoryLocationCode.ToUpper() + sb.ToString();
        }
    }
}
