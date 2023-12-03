using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src.book
{
    interface IBookCatalog<T, E> : INotifyPropertyChanged
    {
		/// <summary>
		/// Opens detailed information about chosen book.
		/// </summary>
		public RelayCommand BookCommand { get; }
		/// <summary>
		/// Collection of books presented in the catalog.
		/// </summary>
		public ObservableCollection<T> Books {  get; set; }
		/// <summary>
		/// Fires when certain book is clicked by a user.
		/// </summary>
		public event EventHandler<E>? BookClicked;
	}
}
