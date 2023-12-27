using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.Model
{
    /// <summary>
    /// Describes basic behavior of a book.
    /// </summary>
    class Book : Readable
    {
        public Book() { }

        public Book(Book book)
        {
            Id = book.Id;
			Title = book.Title;
			Author = book.Author;
            Genre = book.Genre;
			Description = book.Description;
			Cover = book.Cover;
			ContentCount = book.ContentCount;
		}

        public override decimal Price
        {
            get
            {
                // Пример формулы: базовая цена + (цена за страницу * количество страниц)
                decimal basePrice = 100.99m;
                decimal pricePerPage = 0.4m;

                return basePrice + pricePerPage * ContentCount;
            }
        }
    }
}
