using Book_Store.MVVM.Model;
using Book_Store.src;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.library
{
	class LibraryViewModel : ObservableObject
    {
        private LibraryReadableInfoViewModel ReadableInfoVM { get; set; }
        private LibraryCatalogViewModel CatalogVM { get; set; }

		private RelayCommand? returnToCatalogCommand;
		/// <summary>
		/// Returns to the catalog.
		/// </summary>
		public RelayCommand ReturnToCatalogCommand
		{
			get
			{
				return returnToCatalogCommand ??= new RelayCommand((o) =>
				{
					CurrentView = CatalogVM;
					ReturnButtonVisibility = Visibility.Collapsed;
					Title = "Моя Библиотека";
				});
			}
		}

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
            ReadableInfoVM = new LibraryReadableInfoViewModel();
            CatalogVM = new LibraryCatalogViewModel();

			ReadableInfoVM.ItemDeletedFromLibrary += (sender, e) =>
			{
				CurrentView = CatalogVM;

				if (e.Item is Book book)
				{
					CatalogVM.Books.Remove(book);
				}
				else if (e.Item is Magazine magazine)
				{
					CatalogVM.Magazines.Remove(magazine);
				}
			};

			CatalogVM.ItemClicked += (sender, e) =>
			{
				ReadableInfoVM.Item = e.Item;
				CurrentView = ReadableInfoVM;

				Title += $" / {e.Item.Title}";
				ReturnButtonVisibility = Visibility.Visible;
			};

			Title = "Моя Библиотека";
			ReturnButtonVisibility = Visibility.Collapsed;

			CurrentView = CatalogVM;
		}

        /// <summary>
        /// Event handler for BookPurchased event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        public void AddNewItems(object? sender, ItemsEventArgs e)
        {
			foreach (var item in e.Items)
			{
				if (item is Book book)
				{
					CatalogVM.Books.Add(book);
				}
				else if (item is Magazine magazine)
				{
					CatalogVM.Magazines.Add(magazine);
				}
			}
		}
	}
}
