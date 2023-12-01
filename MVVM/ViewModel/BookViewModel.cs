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
    internal class BookViewModel : ObservableObject
    {
		/// <summary>
		/// Fires when certain book is purchased by a user.
		/// </summary>
		public event EventHandler<ElementClickedEventArgs>? BookPurchased;

		private RelayCommand? _purchaseCommand;

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

		public RelayCommand PurchaseCommand
		{
			get
			{
				return _purchaseCommand ??= new RelayCommand((o) =>
				{
                    if (Book is not null)
                    {
						BookPurchased?.Invoke(this, new ElementClickedEventArgs(Book));
					}
				});
			}
		}
	}
}
