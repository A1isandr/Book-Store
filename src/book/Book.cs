using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes the book type.
    /// </summary>
    abstract class Book
    {
        /// <summary>
        /// Book's Id.
        /// </summary>
        public abstract int Id { get; set; }
        /// <summary>
        /// Book's title.
        /// </summary>
        public abstract string? Title { get; set; }
        /// <summary>
        /// Book's genre.
        /// </summary>
		public abstract string? Genre { get; set; }
        /// <summary>
        /// Book's first publication date.
        /// </summary>
        public abstract string? PublicationDate { get; set; }
		/// <summary>
		/// Book's description.
		/// </summary>
		public abstract string? Description { get; set; }
        /// <summary>
        /// Book's author.
        /// </summary>
        public abstract string? Author { get; set; }
        /// <summary>
        /// Book's cover.
        /// </summary>
		public abstract string? Cover { get; set; }
	}
}
