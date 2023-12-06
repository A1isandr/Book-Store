using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Data.SqlTypes;
using Book_Store.MVVM.View;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace Book_Store.MVVM.ViewModel.shop
{
    class ShopViewModel : ObservableObject
    {
        private BookInfoViewModel BookInfoVM { get; set; }
        private ShopBookCatalogViewModel CatalogVM { get; set; }

        public ObservableCollection<Notification> Notifications { get; set; }

        private RelayCommand? _returnToCatalogCommand;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ElementClickedEventArgs>? BookPurchased;

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

        public ShopViewModel()
        {
            BookInfoVM = new BookInfoViewModel();
            CatalogVM = new ShopBookCatalogViewModel();

            Notifications = new ObservableCollection<Notification>();

            CatalogVM.BookClicked += CatalogVM_BookClicked;
            BookInfoVM.BookPurchased += CatalogVM_BookPurchased;

            CurrentView = CatalogVM;

            Title = "Магазин";
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
                    Title = "Магазин";
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

		private void CatalogVM_BookPurchased(object? sender, ElementClickedEventArgs e)
        {
            BookPurchased?.Invoke(sender, e);

            Notifications.Add(new Notification("Добавлено в корзину"));
        }
	}
}
