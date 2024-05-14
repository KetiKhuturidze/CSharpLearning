namespace BookStoreCatalog
{
    /// <summary>
    /// Represents an International Standard Book Number (ISBN).
    /// </summary>
    public class BookNumber
    {
        private readonly string code; // isbn code

        /// <summary>
        /// Initializes a new instance of the <see cref="BookNumber"/> class with the specified 10-digit ISBN <paramref name="isbnCode"/>.
        /// </summary>
        /// <param name="isbnCode">A 10-digit ISBN code.</param>
        /// <exception cref="ArgumentNullException">a code argument is null.</exception>
        /// <exception cref="ArgumentException">a code argument is invalid or a code has wrong checksum.</exception>
        public BookNumber(string isbnCode)
        {
            if (isbnCode is null)
            {
                throw new ArgumentNullException(nameof(isbnCode));
            }

            if (!ValidateCode(isbnCode) || !ValidateChecksum(isbnCode))
            {
                throw new ArgumentException(null, nameof(isbnCode));
            }

            this.code = isbnCode;
        }

        /// <summary>
        /// Gets a 10-digit ISBN code.
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        public Uri GetSearchUri()
        {
            if (string.IsNullOrEmpty(this.Code))
            {
                throw new InvalidOperationException("ISBN is not set.");
            }

            string isbnSearchUrl = $"https://isbnsearch.org/isbn/{this.Code}";
            return new Uri(isbnSearchUrl);
        }

        public override string ToString()
        {
            return $"{this.Code}";
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        private static bool ValidateCode(string isbnCode)
        {
            if (isbnCode.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(isbnCode[i]) && isbnCode[i] != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateChecksum(string isbnCode)
        {
            if (isbnCode.Length != 10)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                int currentDigit = isbnCode[i] == 'X' ? 10 : int.Parse(isbnCode[i].ToString());

                sum += (10 - i) * currentDigit;
            }

            return sum % 11 == 0;
        }
    }
}
