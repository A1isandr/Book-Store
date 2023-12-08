using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store.MVVM.ViewModel
{
    internal class BookInfoViewModel : ObservableObject
    {
		private RelayCommand? _purchaseCommand;

		/// <summary>
		/// Fires when certain book is purchased by a user.
		/// </summary>
		public event EventHandler<ElementClickedEventArgs>? BookAddedToCart;

		private Book? _book;
		/// <summary>
		/// Book currently being viewed
		/// </summary>
		public Book? Book
        { 
            get
            {
                if (_book is ShopBook shopBook)
                {
                    return shopBook;
                }
                else if (_book is LibraryBook libraryBook)
                {
                    return libraryBook;
                }
                else
                {
                    return _book;
                }
            }
            set => _book = value; 
        }

		/// <summary>
		/// Adds chosen book to user's library.
		/// </summary>
		public RelayCommand PurchaseCommand
		{
			get
			{
				return _purchaseCommand ??= new RelayCommand((o) =>
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
