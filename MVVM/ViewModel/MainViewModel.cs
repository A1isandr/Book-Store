using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Book_Store.MVVM.Model;
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
		private BookViewModel BookVM { get; set; }

		private object? _currentView;
        /// <summary>
        /// Represents currently opened tab.
        /// </summary>
        public object? CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ShopVM = new ShopViewModel();
			LibraryVM = new LibraryViewModel();
            BookVM = new BookViewModel();

            ShopVM.BookClicked += ShopVM_BookClicked;
			BookVM.BookPurchased += LibraryVM.BookVM_BookPurchased;

			CurrentView = ShopVM;
        }

		/// <summary>
		/// 
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
		/// 
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
		/// 
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
		/// 
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
		/// 
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

		/// <summary>
		/// Event handler for BookClicked event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShopVM_BookClicked(object? sender, ElementClickedEventArgs e)
		{
            if (e.EventInfo is Book book)
            {
                BookVM.Book = book;
                CurrentView = BookVM;
            }
		}
	}
}
