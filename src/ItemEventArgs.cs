using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.MVVM.Model;

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

	/// <summary>
	/// 
	/// </summary>
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

	/// <summary>
	/// 
	/// </summary>
	class ItemIdEventArgs : EventArgs
	{
		/// <summary>
		/// Item id.
		/// </summary>
		public int ItemId { get; }

		public ItemIdEventArgs(int itemId)
		{
			ItemId = itemId;
		}
	}
}
