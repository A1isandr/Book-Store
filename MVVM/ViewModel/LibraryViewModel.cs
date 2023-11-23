using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.MVVM.Model;
using Book_Store.src;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.MVVM.ViewModel
{
    class LibraryViewModel
    {
		LibraryContext db = new();
		public ObservableCollection<LibraryBook> Books { get; set; }

		RelayCommand? addCommand;
		RelayCommand? deleteCommand;

		public LibraryViewModel()
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
					LibraryBook book = new();
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
					LibraryBook book = new();
					db.Books.Add(book);
					db.SaveChanges();
				});

			}
		}



	}
}
