using Book_Store.MVVM.Model;
using Book_Store.src;
using Book_Store.src.book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.ViewModel.library
{
    class LibraryBookInfoViewModel : ObservableObject
    {
        public Readable? Book { get; set; }

		/// <summary>
		/// Fire when item is deleted
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemDeleted;

		private RelayCommand? _deleteFromLibraryCommand;
		/// <summary>
		/// Delete item from library
		/// </summary>
		public RelayCommand? DeleteFromLibraryCommand
        {
            get
            {
                return _deleteFromLibraryCommand ??= new RelayCommand((o) =>
                {
                    
                });
            }
        }
    }
}
