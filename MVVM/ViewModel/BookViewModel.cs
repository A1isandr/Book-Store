using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.ViewModel
{
    internal class BookViewModel
    {
        public BookModel Model { get; set; }

        public BookViewModel(Book book)
        {
            Model = new BookModel(book);
        }
    }
}
