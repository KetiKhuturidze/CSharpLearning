using System.Diagnostics;
using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents a book price.
    /// </summary>
    public class BookPrice
    {
        private decimal amount;
        private string currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class.
        /// Gets or sets initializes a new instance of the <see cref="BookPrice"/> class.
        /// </summary>
        public BookPrice()
        {
            this.Amount = 0;
            this.Currency = "USD";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class with specified <paramref name="amount"/> and <paramref name="currency"/>.
        /// </summary>
        /// <param name="amount">An amount of money of a book.</param>
        /// <param name="currency">A price currency.</param>
        public BookPrice(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException(null, nameof(amount));
            }

            ThrowExceptionIfAmountIsNotValid(amount);
            ThrowExceptionIfCurrencyIsNotValid(currency);
            this.Amount = amount;
            this.Currency = currency;
        }

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        public decimal Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(null, nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Gets or sets a book price currency.
        /// </summary>
        public string Currency
        {
            get
            {
                return this.currency;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length != 3 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(null, nameof(value));
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new ArgumentException(null, nameof(value));
                    }
                }

                this.currency = value;
            }
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Amount.ToString("N2", CultureInfo.InvariantCulture)} {this.Currency}";
        }

        private static void ThrowExceptionIfAmountIsNotValid(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(null, nameof(amount));
            }
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            if (currency is null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            if (currency.Length != 3 || string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException(null, nameof(currency));
            }

            foreach (char c in currency)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new ArgumentException(null, nameof(currency));
                    }
            }
        }
    }
}
