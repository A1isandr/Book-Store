using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src.book
{
    interface ICatalog : INotifyPropertyChanged
    {
		/// <summary>
		/// Opens detailed information about chosen item.
		/// </summary>
		public RelayCommand ItemClickedCommand { get; }
		/// <summary>
		/// Collection of readables presented in the catalog.
		/// </summary>
		public ObservableCollection<Readable> Readables {  get; set; }
		/// <summary>
		/// Fires when certain item is clicked by a user.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemClicked;
	}
}
