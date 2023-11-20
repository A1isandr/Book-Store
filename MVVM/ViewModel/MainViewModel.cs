using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.src;

namespace Book_Store.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand ShopCommand { get; set; }
		public RelayCommand LibraryCommand { get; set; }

		private ShopViewModel ShopVM { get; set; }
		private LibraryViewModel LibraryVM { get; set; }

		private object _currentView;

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
            ShopVM = new ShopViewModel();
			LibraryVM = new LibraryViewModel();

			CurrentView = ShopVM;

            ShopCommand = new RelayCommand(o =>
            {
                CurrentView = ShopVM;
            });

            LibraryCommand = new RelayCommand(o =>
            {
                CurrentView = LibraryVM;
            });
        }
    }
}
