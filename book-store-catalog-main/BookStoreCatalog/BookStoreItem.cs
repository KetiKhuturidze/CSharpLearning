using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents the an item in a book store.
    /// </summary>
    public class BookStoreItem
    {
        private BookPublication publication;
        private BookPrice price;
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isniCode"/>, <paramref name="title"/>, <paramref name="publisher"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="bookBinding"/>, <paramref name="isbn"/>, <paramref name="priceAmount"/>, <paramref name="priceCurrency"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbn, decimal priceAmount, string priceCurrency, int amount)
        {
            if (string.IsNullOrEmpty(priceAmount.ToString()))
            {
                throw new ArgumentNullException(nameof(priceAmount));
            }

            this.Price = new BookPrice(priceAmount, priceCurrency);
            this.Publication = new BookPublication(authorName, isniCode, title, publisher, published, bookBinding, isbn);
            this.Amount = amount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="publication"/>, <paramref name="price"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(BookPublication publication, BookPrice price, int amount)
        {
            if (publication is null)
            {
                throw new ArgumentNullException(nameof(publication));
            }

            if (price is null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            this.Publication = publication;
            this.Price = price;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets or sets a <see cref="BookPublication"/>.
        /// </summary>
        public BookPublication Publication
        {
            get
            {
                return this.publication;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.publication = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="BookPrice"/>.
        /// </summary>
        public BookPrice Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
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
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (this.Publication.Author.HasIsni)
            {
                return $"{this.Publication.Title} by {this.Publication.Author.AuthorName} (ISNI:{this.Publication.Author.Isni}), {this.Price}, {this.Amount}";
            }

            string formattedPrice = this.Price.Amount.ToString("N2", CultureInfo.InvariantCulture);

            if (formattedPrice.Contains(','))
            {
                return $"{this.Publication.Title} by {this.Publication.Author.AuthorName}, \"{formattedPrice} {this.Price.Currency}\", {this.Amount}";
            }

            return $"{this.Publication.Title} by {this.Publication.Author.AuthorName}, {formattedPrice} {this.Price.Currency}, {this.Amount}";
        }
    }
}