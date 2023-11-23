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

namespace Book_Store.MVVM.ViewModel
{
    class ShopViewModel
    {
		ShopContext db = new();
		public ObservableCollection<ShopBook> Books { get; set; }

		RelayCommand? addCommand;
		RelayCommand? deleteCommand;

		public ShopViewModel()
		{
			db.Database.EnsureCreated();
			db.Books.Load();
			Books = db.Books.Local.ToObservableCollection();
		}

		public RelayCommand AddCommand
		{
			get
			{
				return addCommand ??= new RelayCommand((o) =>
				{
					ShopBook book = new();
					db.Books.Add(book);
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
					ShopBook book = new();
					db.Books.Add(book);
					db.SaveChanges();
				});

			}
		}
	}
}
