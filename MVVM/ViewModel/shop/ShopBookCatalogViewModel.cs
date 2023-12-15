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
    class ShopBookCatalogViewModel : ObservableObject
    {
        private readonly StoreContext db = new();

        private RelayCommand? _itemClickedCommand;

        public ObservableCollection<Book> Readables { get; set; }

        public event EventHandler<ItemEventArgs>? ItemClicked;

        public ShopBookCatalogViewModel()
        {
            db.Database.EnsureCreated();
            db.Products.Load();
			Readables = db.Products.Local.ToObservableCollection();
        }

        public RelayCommand ItemClickedCommand
        {
            get
            {
                return _itemClickedCommand ??= new RelayCommand((o) =>
                {
                    if (o is int itemId)
                    {
                        var book = Readables.First(x => x.id == itemId);
                        //ItemClicked?.Invoke(this, new ItemEventArgs(book));
                    }
                });
            }
        }
    }
}
