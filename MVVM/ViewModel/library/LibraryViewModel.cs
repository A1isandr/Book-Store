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
        private LibraryBookInfoViewModel BookInfoVM { get; set; }
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
            BookInfoVM = new LibraryBookInfoViewModel();
            CatalogVM = new LibraryBookCatalogViewModel();

            CatalogVM.ItemClicked += CatalogVM_BookClicked;

            CurrentView = CatalogVM;

            Title = "Моя Библиотека";
			ReturnButtonVisibility = Visibility.Collapsed;
		}

		/// <summary>
		/// 
		/// </summary>
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
		private void CatalogVM_BookClicked(object? sender, ItemEventArgs e)
        {
            BookInfoVM.Book = e.Item;
            CurrentView = BookInfoVM;

            Title += $" / {e.Item.Title}";
			ReturnButtonVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Event handler for BookPurchased event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        public void AddNewBook(object? sender, ItemsEventArgs e)
        {
			foreach (var item in e.Items)
			{
				//CatalogVM.Readables.Add(item);
			}
		}
    }
}
