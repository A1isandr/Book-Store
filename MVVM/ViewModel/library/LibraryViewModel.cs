using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Book_Store.MVVM.Model;
using Book_Store.src;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.MVVM.ViewModel.library
{
    class LibraryViewModel : ObservableObject
    {
        private BookInfoViewModel BookInfoVM { get; set; }
        private LibraryBookCatalogViewModel CatalogVM { get; set; }

		private RelayCommand? _returnToCatalogCommand;

		private Visibility returnButtonVisibility;
		/// <summary>
		/// Visibility of the return button.
		/// </summary>
		public Visibility ReturnButtonVisibility
		{
			get => returnButtonVisibility;
			set
			{
				returnButtonVisibility = value;
				OnPropertyChanged(nameof(ReturnButtonVisibility));
			}
		}

		private string? _title;
		/// <summary>
		/// Current title.
		/// </summary>
		public string? Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private object? _currentView;
        /// <summary>
        /// Currently opened tab in the shop.
        /// </summary>
        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public LibraryViewModel()
        {
            BookInfoVM = new BookInfoViewModel();
            CatalogVM = new LibraryBookCatalogViewModel();

            CatalogVM.BookClicked += CatalogVM_BookClicked;

            CurrentView = CatalogVM;

            Title = "Моя Библиотека";
			ReturnButtonVisibility = Visibility.Collapsed;
		}

		public RelayCommand ReturnToCatalogCommand
		{
			get
			{
				return _returnToCatalogCommand ??= new RelayCommand((o) =>
				{
					CurrentView = CatalogVM;
					ReturnButtonVisibility = Visibility.Collapsed;
					Title = "Моя Библиотека";
				});
			}
		}

		/// <summary>
		/// Event handler for BookClicked event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CatalogVM_BookClicked(object? sender, ElementClickedEventArgs e)
        {
            if (e.EventInfo is Book book)
            {
                BookInfoVM.Book = book;
                CurrentView = BookInfoVM;

                Title += $" / {book.Title}";
				ReturnButtonVisibility = Visibility.Visible;
			}
        }

        /// <summary>
        /// Event handler for BookPurchased event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        public void AddNewBook(object? sender, ElementClickedEventArgs e)
        {
			if (e.EventInfo is ObservableCollection<Book> books)
			{
				foreach (var book in books)
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

					CatalogVM.Books.Add(libraryBook);
				}
			}
		}
    }
}
