using Book_Store.src;
using System;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.shop
{
	class ShopViewModel : ObservableObject
    {
        private ShopReadableInfoViewModel ReadableInfoVM { get; set; }
        private ShopCatalogViewModel CatalogVM { get; set; }

        private RelayCommand? returnToCatalogCommand;
		/// <summary>
		/// Command for returning back to catalog
		/// </summary>
		public RelayCommand ReturnToCatalogCommand
		{
			get
			{
				return returnToCatalogCommand ??= new RelayCommand((o) =>
				{
					CurrentView = CatalogVM;
					Title = "Магазин";
					ReturnButtonVisibility = Visibility.Collapsed;
				});
			}
		}

        private RelayCommand? searchCommand;
		/// <summary>
		/// Command for searching in the shop
		/// </summary>
		public RelayCommand SearchCommand
		{
			get
			{
				return searchCommand ??= new RelayCommand((o) =>
				{
					if (o is not null)
                    {
                        if (o is string query)
                        {
							CatalogVM.Search(query);

							CurrentView = CatalogVM;
						}
                    }
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

		/// <summary>
		/// Fires when the user adds book to the cart.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemAddedToCart;



		public ShopViewModel()
        {
			ReadableInfoVM = new ShopReadableInfoViewModel();
            CatalogVM = new ShopCatalogViewModel();

            CatalogVM.ItemClicked += (sender, e) =>
            {
				ReadableInfoVM.NewItem(e.Item);
				CurrentView = ReadableInfoVM;

				Title += $" / {e.Item.Title}";
				ReturnButtonVisibility = Visibility.Visible;
			};

			ReadableInfoVM.ItemAddedToCart += (sender, e) =>
            {
				ItemAddedToCart?.Invoke(sender, e);
			};

			Title = "Магазин";
			ReturnButtonVisibility = Visibility.Collapsed;

			CurrentView = CatalogVM;
        }
    }
}
