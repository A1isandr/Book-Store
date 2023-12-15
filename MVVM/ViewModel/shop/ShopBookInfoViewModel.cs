using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using Book_Store.src.book;

namespace Book_Store.MVVM.ViewModel.shop
{
    internal class ShopBookInfoViewModel : ObservableObject, IInfo
    {
		public Readable? Book { get; set; }

		/// <summary>
		/// Fires when certain book is purchased by a user.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemAddedToCart;

		private RelayCommand? _addToCartCommand;
		/// <summary>
		/// Adds chosen book to user's library.
		/// </summary>
		public RelayCommand AddToCartCommand
		{
			get
			{
				return _addToCartCommand ??= new RelayCommand((o) =>
				{
                    if (Book is not null)
                    {
						ItemAddedToCart?.Invoke(this, new ItemEventArgs(Book));
					}
				});
			}
		}
	}
}
