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

		public event EventHandler<ElementClickedEventArgs>? BookClicked;

		public RelayCommand BookCommand { get; set; }

		public ShopViewModel()
		{
			db.Database.EnsureCreated();
			db.ShopBooks.Load();
			Books = db.ShopBooks.Local.ToObservableCollection();

			BookCommand = new RelayCommand(BookCommand_Executed);
		}

		private void BookCommand_Executed(object o)
		{
			ShopBook book;
			if (o is int bookId)
			{
				book = Books.First(x => x.Id == bookId);
				BookClicked?.Invoke(this, new ElementClickedEventArgs(book));
			}	
		}
	}
}
