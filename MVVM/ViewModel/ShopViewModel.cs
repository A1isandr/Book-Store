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
    class ShopViewModel : ObservableObject
    {
		private StoreContext db = new();

		/// <summary>
		/// Collection of books presented in the shop.
		/// </summary>
		public ObservableCollection<ShopBook> Books { get; set; }
		/// <summary>
		/// Fires when certain book is clicked by a user.
		/// </summary>
		public event EventHandler<ElementClickedEventArgs>? BookClicked;

		private RelayCommand? _bookCommand;

		public ShopViewModel()
		{
			db.Database.EnsureCreated();
			db.ShopBooks.Load();
			Books = db.ShopBooks.Local.ToObservableCollection();
		}

		/// <summary>
		/// BookCommand logic.
		/// </summary>
		public RelayCommand BookCommand
		{
			get
			{
				return _bookCommand ??= new RelayCommand((o) =>
				{
					ShopBook book;
					if (o is int bookId)
					{
						book = Books.First(x => x.Id == bookId);
						BookClicked?.Invoke(this, new ElementClickedEventArgs(book));
					}
				});
			}
		}
	}
}
