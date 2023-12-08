using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Book_Store.MVVM.Model;
using Book_Store.src;

namespace Book_Store.MVVM.ViewModel.shop
{
    class CartViewModel : ObservableObject
    {
		/// <summary>
		/// Books in cart
		/// </summary>
		public ObservableCollection<ShopBook> Books { get; set; }

		private int _totalBooks;
		/// <summary>
		/// Total number of books
		/// </summary>
		public int TotalBooks
        {
            get => _totalBooks;
			set
			{
				_totalBooks = value;
				OnPropertyChanged(nameof(TotalBooks));
			}
		}

		private decimal _totalPrice;
		/// <summary>
		/// Total price
		/// </summary>
		public decimal TotalPrice
        {
			get => _totalPrice;
			set
			{
				_totalPrice = value;
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private RelayCommand? _checkoutCommand;
		private RelayCommand? _clearCartCommand;
		private RelayCommand? _removeBookCommand;

		public event EventHandler<ElementClickedEventArgs>? Checkout;

		public CartViewModel()
        {
            Books = new ObservableCollection<ShopBook>();
			Books.CollectionChanged += (sender, e) =>
			{
				TotalBooks = Books.Count;
				TotalPrice = Books.Sum(x => x.Price);
			};

		}

		/// <summary>
		/// 
		/// </summary>
		public RelayCommand CheckoutCommand
		{
			get
			{
				return _checkoutCommand ??= new RelayCommand((o) =>
				{
					Checkout?.Invoke(this, new ElementClickedEventArgs(Books));
					Books.Clear();
				});
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public RelayCommand ClearCartCommand
		{
			get
			{
				return _clearCartCommand ??= new RelayCommand((o) =>
				{
					Books.Clear();
				});
			}
		}

		public RelayCommand RemoveBookCommand
		{
			get
			{
				return _removeBookCommand ??= new RelayCommand((o) =>
				{
					if (o is int bookId)
					{
						Books.Remove(Books.First(x => x.Id == bookId));
					}
				});
			}
		}

	}
}
