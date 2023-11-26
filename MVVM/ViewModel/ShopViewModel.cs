using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Data.SqlTypes;

namespace Book_Store.MVVM.ViewModel
{
    class ShopViewModel
    {
		StoreContext db = new();
		public ObservableCollection<ShopBook> Books { get; set; }

		RelayCommand? addCommand;
		RelayCommand? deleteCommand;

		public ShopViewModel()
		{
			db.Database.EnsureCreated();
			db.ShopBooks.Load();
			Books = db.ShopBooks.Local.ToObservableCollection();
		}

		public RelayCommand AddCommand
		{
			get
			{
				return addCommand ??= new RelayCommand((o) =>
				{
					ShopBook book = new ShopBook();
					db.ShopBooks.Add(book);
					db.SaveChanges();
				});
			}
		}

		public RelayCommand DeleteCommand
		{
			get
			{
				return deleteCommand ??= new RelayCommand((o) =>
				{
                    ShopBook book = new ShopBook();
                    db.ShopBooks.Add(book);
					db.SaveChanges();
				});
			}
		}
	}
}
