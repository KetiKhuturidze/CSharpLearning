using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length <= 2 || dateCode[0] == '7' || dateCode[0] == '9' || dateCode[2] == '0' || dateCode.Length > 4)
            {
                throw new ArgumentException("dateCode is invalid");
            }

            if (dateCode.Length == 4 && dateCode[3] == '3')
            {
                throw new ArgumentException("dateCode is invalid");
            }

            manufacturingYear = 1900 + uint.Parse(dateCode[..2]);
            manufacturingMonth = uint.Parse(dateCode[2..]);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length <= 4 || dateCode[0] == '7' || int.Parse(dateCode[0..2]) < 86 || dateCode[0] == '9' || dateCode.Length > 6)
            {
                throw new ArgumentException("dateCode is invalid");
            }

            manufacturingYear = 1900 + uint.Parse(dateCode[..2]);
            factoryLocationCode = dateCode[^2..];
            manufacturingMonth = uint.Parse(dateCode[2.. (dateCode.Length - 2)]);
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("datecode is invalid");
            }

            string stDate = dateCode.ToString();

            if (stDate[3] == '0')
            {
                manufacturingYear = 2000 + uint.Parse(string.Join(string.Empty, stDate[3], stDate[5]));
            }
            else
            {
                manufacturingYear = 1900 + uint.Parse(string.Join(string.Empty, stDate[3], stDate[5]));
            }

            factoryLocationCode = dateCode[..2];

            manufacturingMonth = uint.Parse(string.Join(string.Empty, stDate[2], stDate[4]));

            if (manufacturingYear < 1990 || manufacturingYear > 2005 || manufacturingMonth <= 0 || manufacturingMonth >= 13)
            {
                throw new ArgumentException("datecode is invalid");
            }

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("datecode is invalid");
            }

            string stDate = dateCode.ToString();

            manufacturingYear = 2000 + uint.Parse(string.Join(string.Empty, stDate[3], stDate[5]));

            factoryLocationCode = dateCode[..2];

            manufacturingWeek = uint.Parse(string.Join(string.Empty, stDate[2], stDate[4]));

            if (manufacturingYear < 2007 || manufacturingYear > DateTime.Now.Year || manufacturingWeek <= 0 || manufacturingWeek > 53)
            {
                throw new ArgumentException("datecode is invalid");
            }

             //////// gpt
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

            /////////

            bool has53Weeks = lastWeekNumber == 53; // can a year have 53 weeks?

            if (!has53Weeks && manufacturingWeek == 53)
            {
                throw new ArgumentException("this year can't have 53 weeks");
            }

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }
    }
}
