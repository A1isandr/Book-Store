using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Book_Store.MVVM.ViewModel.shop
{
	internal class ShopReadableInfoViewModel : ObservableObject, IInfo
    {
		private Readable? item;
		/// <summary>
		/// Item currently selected.
		/// </summary>
		public Readable? Item
		{
			get => item;
			set
			{
				item = value;
				OnPropertyChanged(nameof(Item));
			}
		}

		private RelayCommand? addToCartCommand;
		/// <summary>
		/// Adds chosen book to user's library.
		/// </summary>
		public RelayCommand AddToCartCommand
		{
			get
			{
				return addToCartCommand ??= new RelayCommand(async (o) =>
				{
                    if (Item is not null)
                    {
						ItemAddedToCart?.Invoke(this, new ItemEventArgs(Item));

						await Task.Run(() =>
						{
							AddToCartButtonText = "В корзине";

							Thread.Sleep(3000);

							AddToCartButtonText = "Купить";
						});
					}
				});
			}
		}

		private string? addToCartButtonText;
		/// <summary>
		/// Add to cart button text.
		/// </summary>
		public string? AddToCartButtonText
		{
			get => addToCartButtonText;
			set
			{
				addToCartButtonText = value;
				OnPropertyChanged(nameof(AddToCartButtonText));
			}
		}

		/// <summary>
		/// Fires when certain book is purchased by a user.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemAddedToCart;



		/// <summary>
		/// Adds chosen book to user's library.
		/// </summary>
		/// <param name="item"></param>
		public void NewItem(Readable item)
		{
			Item = item;

			AddToCartButtonText = "Купить";
		}
	}
}
