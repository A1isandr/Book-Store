using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes basic behavior of a book.
    /// </summary>
    class Book : Readable
    {
        /// <summary>
        /// Book's author.
        /// </summary>
        public string? Author { get; set; }

        public override decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
