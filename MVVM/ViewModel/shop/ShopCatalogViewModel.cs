using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.shop
{
	class ShopCatalogViewModel : ObservableObject
    {
        private readonly StoreContext db = new();

		public ObservableCollection<Book> Books { get; set; }
		public ObservableCollection<Magazine> Magazines { get; set; }

		private RelayCommand? itemClickedCommand;
		/// <summary>
		/// Shows readable info.
		/// </summary>
		public RelayCommand ItemClickedCommand
		{
			get
			{
				return itemClickedCommand ??= new RelayCommand((o) =>
				{
					if (o is int itemId)
					{
						var book = db.Readables.First(x => x.Id == itemId);
						ItemClicked?.Invoke(this, new ItemEventArgs(book));
					}
				});
			}
		}

        private Visibility noBooksFoundLabelVisibility;
		/// <summary>
		/// Visibility of NoBooksFoundLabel
		/// </summary>
		public Visibility NoBooksFoundLabelVisibility
		{
            get => noBooksFoundLabelVisibility;
            set
            {
				noBooksFoundLabelVisibility = value;
                OnPropertyChanged(nameof(NoBooksFoundLabelVisibility));
            }
        }

		private Visibility noMagazinesFoundLabelVisibility;
		/// <summary>
		/// Visibility of NoMagazinesFoundLabel
		/// </summary>
		public Visibility NoMagazinesFoundLabelVisibility
		{
			get => noMagazinesFoundLabelVisibility;
			set
			{
				noMagazinesFoundLabelVisibility = value;
				OnPropertyChanged(nameof(NoMagazinesFoundLabelVisibility));
			}
		}

		/// <summary>
		/// Fired when an item is clicked
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemClicked;



		public ShopCatalogViewModel()
		{
            db.Database.EnsureCreated();

			Magazines = new
			(
				db.Readables.OfType<Magazine>()
							.ToList()
			);

			Books = new
			(
				db.Readables.OfType<Book>()
							.ToList()
			);

			NoBooksFoundLabelVisibility = Books.Count == 0 ? Visibility.Visible :
                                                             Visibility.Collapsed;

			NoMagazinesFoundLabelVisibility = Magazines.Count == 0 ? Visibility.Visible :
															         Visibility.Collapsed;
		}
    }
}
