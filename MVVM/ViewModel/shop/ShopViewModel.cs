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
using System.Collections.Specialized;
using System.ComponentModel;

namespace Book_Store.MVVM.ViewModel.shop
{
    class ShopViewModel : ObservableObject
    {
        private ShopBookInfoViewModel BookInfoVM { get; set; }
        private ShopBookCatalogViewModel CatalogVM { get; set; }

        private RelayCommand? _returnToCatalogCommand;

		/// <summary>
		/// Fires when the user adds book to the cart.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemAddedToCart;

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
            BookInfoVM = new ShopBookInfoViewModel();
            CatalogVM = new ShopBookCatalogViewModel();

			CatalogVM.ItemClicked += CatalogVM_ItemClicked;
            BookInfoVM.ItemAddedToCart += CatalogVM_ItemAddedToCart;

            CurrentView = CatalogVM;

            Title = "Магазин";
			ReturnButtonVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Command for returning back to catalog
        /// </summary>
        public RelayCommand ReturnToCatalogCommand
        {
            get
			{
				return _returnToCatalogCommand ??= new RelayCommand((o) =>
				{
					CurrentView = CatalogVM;
                    Title = "Магазин";
                    ReturnButtonVisibility = Visibility.Collapsed;
				});
			}
		}

        /// <summary>
        /// Event handler for BookClicked event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogVM_ItemClicked(object? sender, ItemEventArgs e)
        {
            BookInfoVM.Book = e.Item;
            CurrentView = BookInfoVM;

            Title += $" / {e.Item.Title}";
			ReturnButtonVisibility = Visibility.Visible;
        }

        private void CatalogVM_ItemAddedToCart(object? sender, ItemEventArgs e)
        {
            ItemAddedToCart?.Invoke(sender, e);
		}
    }
}
