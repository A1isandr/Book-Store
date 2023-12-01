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
    class LibraryViewModel : ObservableObject
    {
		private StoreContext db = new();

		/// <summary>
		/// Collection of books presented in the library.
		/// </summary>
		public ObservableCollection<LibraryBook> Books { get; set; }

		public LibraryViewModel()
		{
			db.Database.EnsureCreated();
			db.LibraryBooks.Load();
			Books = db.LibraryBooks.Local.ToObservableCollection();
		}

		/// <summary>
		/// Adds purchased book to the library.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void BookVM_BookPurchased(object? sender, ElementClickedEventArgs e)
		{
			if (e.EventInfo is Book book && e.EventInfo is not null)
			{
				LibraryBook libraryBook = new()
				{
					Title = book.Title,
					Genre = book.Genre,
					PublicationDate = book.PublicationDate,
					Description = book.Description,
					Author = book.Author,
					Cover = book.Cover,
					DateAdded = DateTime.UtcNow.ToString()
				};

				db.LibraryBooks.Add(libraryBook);
				db.SaveChanges();

				db.LibraryBooks.Load();
				Books = db.LibraryBooks.Local.ToObservableCollection();
			}
		}
	}
}
