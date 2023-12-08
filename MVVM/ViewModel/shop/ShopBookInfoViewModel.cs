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
    internal class ShopBookInfoViewModel : ObservableObject, IBookInfo<ShopBook>
    {
		private RelayCommand? _addToCartCommand;

		/// <summary>
		/// Fires when certain book is purchased by a user.
		/// </summary>
		public event EventHandler<ElementClickedEventArgs>? BookAddedToCart;
		
		public ShopBook? Book { get; set; }

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
						BookAddedToCart?.Invoke(this, new ElementClickedEventArgs(Book));
					}
				});
			}
		}
	}
}
