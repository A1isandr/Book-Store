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
		public ObservableCollection<Readable> Readables { get; set; }

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

		public event EventHandler<ItemsEventArgs>? Checkout;

		public CartViewModel()
        {
			Readables = new ObservableCollection<Readable>();
			Readables.CollectionChanged += (sender, e) =>
			{
				TotalBooks = Readables.Count;
				TotalPrice = Readables.Sum(x => x.Price);
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
					Checkout?.Invoke(this, new ItemsEventArgs(Readables));
					Readables.Clear();
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
					Readables.Clear();
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
						Readables.Remove(Readables.First(x => x.id == bookId));
					}
				});
			}
		}

	}
}
