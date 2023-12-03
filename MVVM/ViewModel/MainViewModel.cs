using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Book_Store.MVVM.Model;
using Book_Store.MVVM.ViewModel.library;
using Book_Store.MVVM.ViewModel.shop;
using Book_Store.src;

namespace Book_Store.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
		private RelayCommand? _closeWindowCommand;
		private RelayCommand? _maxWindowCommand;
		private RelayCommand? _minWindowCommand;

        private RelayCommand? _shopCommand;
        private RelayCommand? _libraryCommand;

		private ShopViewModel ShopVM { get; set; }
		private LibraryViewModel LibraryVM { get; set; }

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

        public MainViewModel()
        {
            ShopVM = new ShopViewModel();
			LibraryVM = new LibraryViewModel();

			ShopVM.BookPurchased += LibraryVM.AddNewBook;

			CurrentView = ShopVM;
        }

		/// <summary>
		/// Changes the current view to shop.
		/// </summary>
		public RelayCommand ShopCommand
		{
			get
			{
				return _shopCommand ??= new RelayCommand((o) =>
				{
					CurrentView = ShopVM;
				});
			}
		}

		/// <summary>
		/// Changes the current view to library.
		/// </summary>
		public RelayCommand LibraryCommand
		{
			get
			{
				return _libraryCommand ??= new RelayCommand((o) =>
				{
					CurrentView = LibraryVM;
				});
			}
		}

		/// <summary>
		/// Closes the window.
		/// </summary>
		public RelayCommand CloseWindowCommand
		{
			get
			{
				return _closeWindowCommand ??= new RelayCommand((o) =>
				{
					if (o is MainWindow window)
					{
						window.Close();
					}
				});
			}
		}

		/// <summary>
		/// Maximizes the window.
		/// </summary>
		public RelayCommand MaxWindowCommand
		{
			get
			{
				return _maxWindowCommand ??= new RelayCommand((o) =>
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

		/// <summary>
		/// Minimizes the window.
		/// </summary>
		public RelayCommand MinWindowCommand
		{
			get
			{
				return _minWindowCommand ??= new RelayCommand((o) =>
				{
					if (o is MainWindow window)
					{
						window.WindowState = WindowState.Minimized;
					}
				});
			}
		}
	}
}
