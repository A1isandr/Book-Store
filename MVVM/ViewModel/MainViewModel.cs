using Book_Store.MVVM.ViewModel.library;
using Book_Store.MVVM.ViewModel.shop;
using Book_Store.src;
using System.Windows;

namespace Book_Store.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
    {
		private ShopViewModel ShopVM { get; set; }
		private LibraryViewModel LibraryVM { get; set; }
		private CartViewModel CartVM { get; set; }

		private RelayCommand? shopCommand;
		/// <summary>
		/// Changes the current view to shop.
		/// </summary>
		public RelayCommand ShopCommand
		{
			get
			{
				return shopCommand ??= new RelayCommand((o) =>
				{
					CurrentView = ShopVM;
				});
			}
		}

		private RelayCommand? libraryCommand;
		/// <summary>
		/// Changes the current view to library.
		/// </summary>
		public RelayCommand LibraryCommand
		{
			get
			{
				return libraryCommand ??= new RelayCommand((o) =>
				{
					CurrentView = LibraryVM;
				});
			}
		}

		private RelayCommand? cartCommand;
		/// <summary>
		/// Changes the current view to cart.
		/// </summary>
		public RelayCommand CartCommand
		{
			get
			{
				return cartCommand ??= new RelayCommand((o) =>
				{
					CurrentView = CartVM;
				});
			}
		}

		private RelayCommand? closeWindowCommand;
		/// <summary>
		/// Closes the window.
		/// </summary>
		public RelayCommand CloseWindowCommand
		{
			get
			{
				return closeWindowCommand ??= new RelayCommand((o) =>
				{
					if (o is MainWindow window)
					{
						window.Close();
					}
				});
			}
		}

		private RelayCommand? maxWindowCommand;
		/// <summary>
		/// Maximizes the window.
		/// </summary>
		public RelayCommand MaxWindowCommand
		{
			get
			{
				return maxWindowCommand ??= new RelayCommand((o) =>
				{
					if (o is MainWindow window)
					{
						window.WindowState =
						(
							window.WindowState == WindowState.Maximized ? WindowState.Normal :
																		  WindowState.Maximized
						);
					}
				});
			}
		}

		private RelayCommand? minWindowCommand;
		/// <summary>
		/// Minimizes the window.
		/// </summary>
		public RelayCommand MinWindowCommand
		{
			get
			{
				return minWindowCommand ??= new RelayCommand((o) =>
				{
					if (o is MainWindow window)
					{
						window.WindowState = WindowState.Minimized;
					}
				});
			}
		}

		private object? _currentView;
        /// <summary>
        /// Represents currently opened tab.
        /// </summary>
        public object? CurrentView
        {
            get => _currentView;
            set 
            { 
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

		private decimal totalCartPrice;
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalCartPrice
		{
			get => totalCartPrice;
			set
			{
				totalCartPrice = value;
				OnPropertyChanged(nameof(TotalCartPrice));
			}
		}

		private int totalReadablesInCart;
		/// <summary>
		/// 
		/// </summary>
		public int TotalReadablesInCart
		{
			get => totalReadablesInCart;
			set
			{
				totalReadablesInCart = value;
				OnPropertyChanged(nameof(TotalReadablesInCart));
			}
		}



		public MainViewModel()
        {
            ShopVM = new ShopViewModel();
			LibraryVM = new LibraryViewModel();
			CartVM = new CartViewModel();

			ShopVM.ItemAddedToCart += CartVM.AddNewItem;

			CartVM.Checkout += LibraryVM.AddNewItems;

			CartVM.Readables.CollectionChanged += (sender, e) =>
			{
				RefershCartStats();
			};

			RefershCartStats();

			CurrentView = ShopVM;
        }

		private void RefershCartStats()
		{
			TotalCartPrice = CartVM.TotalPrice;
			TotalReadablesInCart = CartVM.TotalReadables;
		}
	}
}
