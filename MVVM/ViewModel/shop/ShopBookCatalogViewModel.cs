using Book_Store.MVVM.Model;
using Book_Store.src;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.src.book;

namespace Book_Store.MVVM.ViewModel.shop
{
    class ShopBookCatalogViewModel : ObservableObject,
                                     IBookCatalog<ShopBook, ElementClickedEventArgs>
    {
        private readonly StoreContext db = new();

        private RelayCommand? _bookClickedCommand;

        public ObservableCollection<ShopBook> Books { get; set; }

        public event EventHandler<ElementClickedEventArgs>? BookClicked;

        public ShopBookCatalogViewModel()
        {
            db.Database.EnsureCreated();
            db.ShopBooks.Load();
            Books = db.ShopBooks.Local.ToObservableCollection();
        }

        public RelayCommand BookClickedCommand
        {
            get
            {
                return _bookClickedCommand ??= new RelayCommand((o) =>
                {
                    ShopBook book;
                    if (o is int bookId)
                    {
                        book = (ShopBook)Books.First(x => x.Id == bookId);
                        BookClicked?.Invoke(this, new ElementClickedEventArgs(book));
                    }
                });
            }
        }
    }
}
