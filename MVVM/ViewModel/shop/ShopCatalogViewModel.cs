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

		private ObservableCollection<Book> books;
		/// <summary>
		/// 
		/// </summary>
		public ObservableCollection<Book> Books
		{
			get => books;
			set
			{
				books = value;
				OnPropertyChanged(nameof(Books));
			}
		}

		private ObservableCollection<Magazine> magazines;
		/// <summary>
		/// 
		/// </summary>
		public ObservableCollection<Magazine> Magazines
		{
			get => magazines;
			set
			{
				magazines = value;
				OnPropertyChanged(nameof(Magazines));
			}
		}

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

		public void Search(string query)
		{
			db.Database.EnsureCreated();



			Magazines = new
			(
				db.Readables.OfType<Magazine>()
							.Where(r => r.Title.ToLower() == query.ToLower())
							.ToList()
			);

			Books = new
			(
				db.Readables.OfType<Book>()
							.Where(r => r.Title.ToLower() == query.ToLower())
							.ToList()
			);
		}
    }
}
