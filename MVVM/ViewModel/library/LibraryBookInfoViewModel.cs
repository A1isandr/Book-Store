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
    class LibraryBookInfoViewModel : ObservableObject, IBookInfo<LibraryBook>
    {
        public LibraryBook? Book { get; set; }

        private RelayCommand? _deleteFromLibraryCommand;

        public event EventHandler<ElementClickedEventArgs> BookDeleted;

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
