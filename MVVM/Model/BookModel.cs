using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.Model
{
    internal class BookModel : ObservableObject
    {
        Book _bookInfo;

        public Book BookInfo
        {
            get => _bookInfo;
            set
            {
                _bookInfo = value;
                OnPropertyChanged("Price");
            }
        }

        public BookModel(Book book)
        {
            BookInfo = book;
        }
    }
}
