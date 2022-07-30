using System;
using System.Globalization;
using VerificationService;

namespace BookClass
{
    /// <summary>
    /// Represents the book as a type of publication.
    /// </summary>
    public sealed class Book
    {
        private bool published;
        private DateTime datePublished;
        private int totalPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Autor of the book.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">Publisher of the book.</param>
        /// <exception cref="ArgumentNullException">Throw when author or title or publisher is null.</exception>
        public Book(string author, string title, string publisher)
        {
            if (author is null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (publisher is null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }

            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Autor of the book.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">Publisher of the book.</param>
        /// <param name="isbn">International Standard Book Number.</param>
        /// <exception cref="ArgumentNullException">Throw when author or title or publisher or ISBN is null.</exception>
        public Book(string author, string title, string publisher, string isbn)
            : this(author, title, publisher)
        {
            if (isbn is null)
            {
                throw new ArgumentNullException(nameof(isbn));
            }

            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets author of the book.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets title of the book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets publisher of the book.
        /// </summary>
        public string Publisher { get; }

        /// <summary>
        /// Gets or sets total pages in the book.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Pages less or equal zero.</exception>
        public int Pages
        {
            get
            {
                return this.totalPages;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.totalPages = value;
            }
        }

        /// <summary>
        /// Gets International Standard Book Number.
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// Gets price.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets currency.
        /// </summary>
        public string Currency { get; private set; }

        /// <summary>
        /// Publishes the book if it has not yet been published.
        /// </summary>
        /// <param name="dateTime">Date of publish.</param>
        public void Publish(DateTime dateTime)
        {
            this.published = true;
            this.datePublished = dateTime;
        }

        /// <summary>
        /// String representation of book.
        /// </summary>
        /// <returns>Representation of book.</returns>
        public override string ToString()
        {
            return this.Title + " by " + this.Author;
        }

        /// <summary>
        /// Gets a information about time of publish.
        /// </summary>
        /// <returns>The string "NYP" if book not published, and the value of the datePublished if it is published.</returns>
        public string GetPublicationDate()
        {
            if (!this.published)
            {
                return "NYP";
            }
            else
            {
                return this.datePublished.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
            }
        }

        /// <summary>
        /// Sets the prise and currency of the book.
        /// </summary>
        /// <param name="price">Price of book.</param>
        /// <param name="currency">Currency of book.</param>
        /// <exception cref="ArgumentException">Throw when Price less than zero or currency is invalid.</exception>
        /// <exception cref="ArgumentNullException">Throw when currency is null.</exception>
        public void SetPrice(decimal price, string currency)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price is less than zero", nameof(price));
            }

            if (IsoCurrencyValidator.IsValid(currency))
            {
                this.Price = price;
                this.Currency = currency;
            }
        }
    }
}