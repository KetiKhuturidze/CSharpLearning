using System.Globalization;

#pragma warning disable
[assembly: CLSCompliant(true)]

namespace BookStoreItem
{
    /// <summary>
    /// Represents an item in a book store.
    /// </summary>
    // TODO Declare a class.
    public class BookStoreItem
    {
        // TODO Add fields.
        private readonly string authorName;
        private readonly string? isni = "ISNI IS NOT SET";
        private readonly bool hasIsni;
        private decimal price;
        private string currency = "USD";
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string isbn)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author", nameof(authorName));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("Publisher", nameof(publisher));
            }

            this.AuthorName = authorName;
            this.Title = title;
            this.Publisher = publisher;
            if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException($"{isbn}", nameof(isbn));
            }

            this.Isbn = isbn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string isni, string title, string publisher, string isbn)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author", nameof(authorName));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("Publisher", nameof(publisher));
            }

            if (!ValidateIsni(isni) || string.IsNullOrEmpty(isni))
            {
                throw new ArgumentException("Invalid ISNI.", nameof(isni));
            }

            if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Invalid ISBN.", nameof(isbn));
            }

            this.AuthorName = authorName;
            this.Isni = isni;
            this.Title = title;
            this.Publisher = publisher;
            this.Isbn = isbn;
            this.HasIsni = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
            : this(authorName, title, publisher, isbn)
        {
            if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn))
            {
                throw new ArgumentException("Invalid ISBN.");
            }

            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author", nameof(authorName));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("Publisher", nameof(publisher));
            }

            if (price < 0)
            {
                throw new ArgumentException(null, nameof(price));
            }

            if (amount < 0)
            {
                throw new ArgumentException(null, nameof(price));
            }

            ThrowExceptionIfCurrencyIsNotValid(currency);

            this.Published = published;
            this.BookBinding = bookBinding;
            this.Price = price;
            this.Currency = currency;
            this.Amount = amount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string isni, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
            : this(authorName, isni, title, publisher, isbn)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author", nameof(authorName));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("Publisher", nameof(publisher));
            }

            if (!ValidateIsni(isni) || string.IsNullOrWhiteSpace(isni))
            {
                throw new ArgumentException("Invalid ISNI.", nameof(isni));
            }

            if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn))
            {
                throw new ArgumentException("Invalid ISBN.", nameof(isbn));
            }

            if (price < 0)
            {
                throw new ArgumentException(null, nameof(price));
            }

            if (amount < 0)
            {
                throw new ArgumentException(null, nameof(price));
            }

            ThrowExceptionIfCurrencyIsNotValid(currency);

            this.Published = published;
            this.Isni = isni;
            this.BookBinding = bookBinding;
            this.Price = price;
            this.Currency = currency;
            this.Amount = amount;
            this.HasIsni = true;
        }

        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        // TODO Add a property.
        public string AuthorName { get; }

        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        // TODO Add a property.
        public string? Isni { get; }

        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        // TODO Add a property.
        public bool HasIsni { get; }

        /// <summary>
        /// Gets a book title.
        /// </summary>
        // TODO Add a property.
        public string Title { get; private set; }

        /// <summary>
        /// Gets a book publisher.
        /// </summary>
        // TODO Add a property.
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        // TODO Add a property.
        public string Isbn { get; private set; }

        /// <summary>
        /// Gets or sets a book publishing date.
        /// </summary>
        // TODO Add a property.
        public DateTime? Published { get; set; }

        /// <summary>
        /// Gets or sets a book binding type.
        /// </summary>
        // TODO Add a property.
        public string BookBinding { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        // TODO Add a property.
        public string Currency
        {
            get
            {
                return this.currency;
            }

            set
            {
                ThrowExceptionIfCurrencyIsNotValid(value);
                this.currency = value;
            }
        }

        /// <summary>
        /// Gets or sets a price currency.
        /// </summary>
        // TODO Add a property.
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        // TODO Add a property.
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Amount));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        // TODO Add an instance method.
        public Uri GetIsniUri()
        {
            if (this.Isni == null)
            {
                throw new InvalidOperationException(nameof(this.isni));
            }

            return new Uri($"https://isni.org/isni/{this.Isni}");
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        // TODO Add an instance method.
        public Uri GetIsbnSearchUri()
        {
            if (string.IsNullOrEmpty(this.Isbn))
            {
                throw new InvalidOperationException("ISBN is not set.");
            }

            string isbnSearchUrl = $"https://isbnsearch.org/isbn/{this.Isbn}";
            return new Uri(isbnSearchUrl);
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        // TODO Add an instance method.
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Isni))
            {
                return $"{this.Title}, {this.AuthorName}, {this.isni}, {this.Price.ToString("N2", CultureInfo.InvariantCulture)} {this.Currency}, {this.Amount}";
            }

            if (this.Price != 0)
            {
                return $"{this.Title}, {this.AuthorName}, {this.Isni}, \"{this.Price.ToString("N2", CultureInfo.InvariantCulture)} {this.Currency}\", {this.Amount}";
            }

            return $"{this.Title}, {this.AuthorName}, {this.Isni}, {this.Price.ToString("N2", CultureInfo.InvariantCulture)} {this.Currency}, {this.Amount}";
        }

        // TODO Add a static method.
        private static bool ValidateIsni(string isni)
        {
            if (isni.Length != 16)
            {
                return false;
            }

            foreach (char c in isni)
                {
                    if (!char.IsDigit(c) && c != 'X')
                    {
                        return false;
                    }
                }

            return true;
        }

        // TODO Add a static method.
        private static bool ValidateIsbnFormat(string isbn)
        {
            if (isbn.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(isbn[i]) && isbn[i] != 'X')
                {
                    return false;
                }
            }

            return true;
        }

            // TODO Add a static method.
        private static bool ValidateIsbnChecksum(string isbn)
        {
            if (isbn.Length != 10)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                int currentDigit = isbn[i] == 'X' ? 10 : int.Parse(isbn[i].ToString());

                sum += (10 - i) * currentDigit;
            }

            return sum % 11 == 0;
        }

        // TODO Add a static method.
        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            if (currency.Length != 3)
            {
                foreach (char c in currency)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new ArgumentException("kkj", nameof(currency));
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("kkj", nameof(currency));
            }
        }
    }
}
