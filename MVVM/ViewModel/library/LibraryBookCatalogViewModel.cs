using Book_Store.MVVM.Model;
using Book_Store.src;
using Book_Store.src.book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.library
{
    class LibraryBookCatalogViewModel : ObservableObject,
                                        IBookCatalog<LibraryBook, ElementClickedEventArgs>
    {
        private readonly StoreContext db = new();

        private RelayCommand? _bookClickedCommand;

        public ObservableCollection<LibraryBook> Books { get; set; }

        public event EventHandler<ElementClickedEventArgs>? BookClicked;

        public LibraryBookCatalogViewModel()
        {
            db.Database.EnsureCreated();
            db.LibraryBooks.Load();
            Books = db.LibraryBooks.Local.ToObservableCollection();

            Books.CollectionChanged += RefreshDB;
        }

        public RelayCommand BookClickedCommand
        {
            get
            {
                return _bookClickedCommand ??= new RelayCommand((o) =>
                {
                    LibraryBook book;
                    if (o is int bookId)
                    {
                        book = Books.First(x => x.Id == bookId);
                        BookClicked?.Invoke(this, new ElementClickedEventArgs(book));
                    }
                });
            }
        }

        private void RefreshDB(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
            {
                foreach (var item in e.NewItems)
                {
					db.LibraryBooks.AddRange((LibraryBook)item);
				}
			}

            db.SaveChanges();
        }
    }
}
