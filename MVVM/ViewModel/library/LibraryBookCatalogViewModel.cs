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
    class LibraryBookCatalogViewModel : ObservableObject
    {
        private readonly StoreContext db = new();

        private RelayCommand? _itemClickedCommand;

        public ObservableCollection<Book> Readables { get; set; }

        public event EventHandler<ItemEventArgs>? ItemClicked;

        public LibraryBookCatalogViewModel()
        {
            db.Database.EnsureCreated();
            db.Library.Load();
			Readables = db.Library.Local.ToObservableCollection();

			Readables.CollectionChanged += RefreshDB;
        }

        public RelayCommand ItemClickedCommand
        {
            get
            {
                return _itemClickedCommand ??= new RelayCommand((o) =>
                {
                    Readable book;
                    if (o is int bookId)
                    {
                        //book = Readables.First(x => x.id == bookId);
                        //ItemClicked?.Invoke(this, new ItemEventArgs(book));
                    }
                });
            }
        }

        private void RefreshDB(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
            {
                foreach (Readable item in e.NewItems)
                {
					//db.Library.AddRange(item);
				}
			}

            db.SaveChanges();
        }
    }
}
