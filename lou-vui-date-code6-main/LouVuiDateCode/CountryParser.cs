using System;
using System.Reflection;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            string[] france = { "France", "A0", "A1", "A2", "AA", "AH", "AN", "AR", "AS", "BA", "BJ", "BU", "DR", "DU", "DR", "DT", "CO", "CT", "CX", "ET", "FL", "LW", "MB", "MI", "NO", "RA", "RI", "SD", "SF", "SL", "SN", "SP", "SR", "TJ", "TH", "TR", "TS", "VI", "VX" };
            string[] germany = { "Germany", "LP", "OL" };
            string[] italy = { "Italy", "BC", "BO", "CE", "FO", "MA", "OB", "RC", "RE", "SA", "TD" };
            string[] spain = { "Spain", "CA", "LO", "LB", "LM", "GI", "LW" };
            string[] switz = { "Switzerland", "DI", "FA" };
            string[] uSA = { "USA", "FC", "FH", "LA", "OS", "SD", "FL" };

            string[][] countries = new string[][]
            {
                france,
                germany,
                italy,
                spain,
                switz,
                uSA,
            };

            int count = 0;
            Country[] factoryCountries = new Country[2];

            for (int i = 0; i < countries.Length; i++)
            {
                Console.WriteLine(countries[i]);

                for (int j = 1; j < countries[i].Length; j++)
                {
                    if (Array.IndexOf(countries[i], factoryLocationCode) != -1)
                    {
                        Country codeCountry = (Country)Enum.Parse(typeof(Country), countries[i][0].ToString());
                        factoryCountries[count] = codeCountry;
                        count++;
                        break;
                    }
                }
            }

            if (factoryCountries[0] == Country.NAN && factoryCountries[1] == Country.NAN)
            {
                throw new ArgumentException("invalid");
            }

            if (factoryCountries[0] == Country.NAN || factoryCountries[1] == Country.NAN)
            {
                Country[] factCountries = new Country[1];
                factCountries[0] = factoryCountries[0];
                return factCountries;
            }

            return factoryCountries;
        }
    }
}
