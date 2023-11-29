using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Book_Store.src;

namespace Book_Store.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
		public RelayCommand CloseWindowCommand { get; set; }
		public RelayCommand MaxWindowCommand { get; set; }
		public RelayCommand MinWindowCommand { get; set; }

		public RelayCommand ShopCommand { get; set; }
		public RelayCommand LibraryCommand { get; set; }

		private ShopViewModel ShopVM { get; set; }
		private LibraryViewModel LibraryVM { get; set; }

		private object _currentView;

        /// <summary>
        /// Represents currently opened tab
        /// </summary>
        public object CurrentView
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
            // Initializing View Models
            ShopVM = new ShopViewModel();
			LibraryVM = new LibraryViewModel();

            // Subscribing to BookClicked event
            ShopVM.BookClicked += ShopVM_BookClicked;

			// Initializing Current View
			CurrentView = ShopVM;

            // Logic for ShopCommand
            ShopCommand = new RelayCommand(o =>
            {
                CurrentView = ShopVM;
            });

            // Logic for LibraryCommand
            LibraryCommand = new RelayCommand(o =>
            {
                CurrentView = LibraryVM;
            });

			// Logic for CloseWindowCommand
			CloseWindowCommand = new RelayCommand(o =>
            {
                if (o is MainWindow window)
                {
                    window.Close();
                }
            });

			// Logic for MaxWindowCommand
			MaxWindowCommand = new RelayCommand(o =>
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

			// Logic for MinWindowCommand
			MinWindowCommand = new RelayCommand(o =>
            {
                if (o is MainWindow window)
                {
					window.WindowState = WindowState.Minimized;
				}
            });
        }

        /// <summary>
        /// Event handler for BookClicked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ShopVM_BookClicked(object? sender, ElementClickedEventArgs e)
		{
            if (e.EventInfo is Book book)
            {
                CurrentView = new BookViewModel(book);
            }
		}
	}
}
