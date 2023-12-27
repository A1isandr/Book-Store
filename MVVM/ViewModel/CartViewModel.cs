using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.shop
{
	class CartViewModel : ObservableObject
    {
		private readonly StoreContext db = new();

		/// <summary>
		/// Books in cart.
		/// </summary>
		public ObservableCollection<Readable> Readables { get; set; }

		private int totalReadables;
		/// <summary>
		/// Total number of books.
		/// </summary>
		public int TotalReadables
        {
            get => totalReadables;
			set
			{
				totalReadables = value;
				OnPropertyChanged(nameof(TotalReadables));
			}
		}

		private decimal totalPrice;
		/// <summary>
		/// Total price.
		/// </summary>
		public decimal TotalPrice
        {
			get => totalPrice;
			set
			{
				totalPrice = value;
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private Visibility cartIsEmptyLabelVisibility;
		/// <summary>
		/// Visibility of empty cart label.
		/// </summary>
		public Visibility CartIsEmptyLabelVisibility
		{
			get => cartIsEmptyLabelVisibility;
			set
			{
				cartIsEmptyLabelVisibility = value;
				OnPropertyChanged(nameof(CartIsEmptyLabelVisibility));
			}
		}

		private RelayCommand? checkoutCommand;
		/// <summary>
		/// Moves all books in cart to the library.
		/// </summary>
		public RelayCommand CheckoutCommand
		{
			get
			{
				return checkoutCommand ??= new RelayCommand((o) =>
				{
					Checkout?.Invoke(this, new ItemsEventArgs(Readables));
					ClearCartCommand.Execute(null);
				});
			}
		}

		private RelayCommand? clearCartCommand;
		/// <summary>
		/// Clears cart.
		/// </summary>
		public RelayCommand ClearCartCommand
		{
			get
			{
				return clearCartCommand ??= new RelayCommand((o) =>
				{
					foreach (var item in Readables)
					{
						db.Readables.First(x => x.Id == item.Id).AmountInCart = 0;
					}

					Readables.Clear();

					db.SaveChanges();
				});
			}
		}

		private RelayCommand? removeItemCommand;
		/// <summary>
		/// Removes book from cart.
		/// </summary>
		public RelayCommand RemoveItemCommand
		{
			get
			{
				return removeItemCommand ??= new RelayCommand((o) =>
				{
					if (o is int itemId)
					{
						Readable readable = Readables.First(x => x.Id == itemId);
						readable.AmountInCart--;
						Readables.Remove(readable);
					}
				});
			}
		}

		/// <summary>
		/// Fired when cart is checked out.
		/// </summary>
		public event EventHandler<ItemsEventArgs>? Checkout;

		

		public CartViewModel()
        {
			Readables = new ObservableCollection<Readable>();

			foreach (var readable in db.Readables)
			{
				if (readable.AmountInCart > 0)
				{
					for (int i = 0; i < readable.AmountInCart; i++)
					{
						if (readable is Book book)
						{
							Readables.Add(new Book(book));
						}
						else if (readable is Magazine magazine)
						{
							Readables.Add(new Magazine(magazine));
						}
					}
				}
			}

			Readables.CollectionChanged += (sender, e) =>
			{
				var collection = sender as ObservableCollection<Readable>;

				RefreshStats(collection);

				if (e.NewItems is not null)
				{
					foreach (Readable readable in e.NewItems)
					{
						db.Readables.First(r => r.Id == readable.Id).AmountInCart++;
					}
				}
				else if (e.OldItems is not null)
				{
					foreach (Readable readable in e.OldItems)
					{
						db.Readables.First(r => r.Id == readable.Id).AmountInCart--;
					}
				}

				db.SaveChanges();
			};

			RefreshStats(Readables);
		}

		/// <summary>
		/// Adds new item to cart.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AddNewItem(object? sender, ItemEventArgs e)
		{
			Readables.Add(e.Item);
		}

		private void RefreshStats(ObservableCollection<Readable>? readables)
		{
			if (readables?.Count > 0)
			{
				CartIsEmptyLabelVisibility = Visibility.Collapsed;
			}
			else if (readables?.Count == 0)
			{
				CartIsEmptyLabelVisibility = Visibility.Visible;
			}

			if (readables is not null)
			{
				TotalReadables = readables.Count;
				TotalPrice = readables.Sum(x => x.Price);
			}
		}
	}
}
