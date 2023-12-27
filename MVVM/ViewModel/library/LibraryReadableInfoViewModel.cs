using Book_Store.MVVM.Model;
using Book_Store.src;
using System;

namespace Book_Store.MVVM.ViewModel.library
{
	class LibraryReadableInfoViewModel : ObservableObject
    {
		/// <summary>
		/// Item currently selected.
		/// </summary>
		public Readable? Item { get; set; }

		private RelayCommand? deleteFromLibraryCommand;
		/// <summary>
		/// Delete item from library.
		/// </summary>
		public RelayCommand? DeleteFromLibraryCommand
        {
            get
            {
                return deleteFromLibraryCommand ??= new RelayCommand((o) =>
                {
                    if (Item is not null)
                    {
                        ItemDeletedFromLibrary?.Invoke(this, new ItemEventArgs(Item));
                    }
				});
            }
        }

		/// <summary>
		/// Fire when item is deleted.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemDeletedFromLibrary;
	}
}
