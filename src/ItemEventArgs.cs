using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
	/// <summary>
	/// Class for providing event data.
	/// </summary>
	class ItemEventArgs : EventArgs
	{
		/// <summary>
		/// Item info.
		/// </summary>
		public Readable Item { get; }

		public ItemEventArgs(Readable item)
		{
			Item = item;
		}
	}

	class ItemsEventArgs : EventArgs
	{
		/// <summary>
		/// Collection of items.
		/// </summary>
		public ObservableCollection<Readable> Items { get; }

		public ItemsEventArgs(ObservableCollection<Readable> items)
		{
			Items = items;
		}
	}
}
