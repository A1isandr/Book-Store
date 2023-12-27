using Book_Store.MVVM.Model;
using Book_Store.src;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace Book_Store.MVVM.ViewModel.library
{
	class LibraryCatalogViewModel : ObservableObject
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
					Readable book;
					if (o is int Id)
					{
						book = db.Readables.First(x => x.Id == Id);
						ItemClicked?.Invoke(this, new ItemEventArgs(book));
					}
				});
			}
		}

		private Visibility noBooksFoundLabelVisibility;
		/// <summary>
		/// Visibility of NoBooksFoundLabel.
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
		/// Visibility of NoMagazinesFoundLabel.
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
		/// Fires when item is clicked.
		/// </summary>
		public event EventHandler<ItemEventArgs>? ItemClicked;



		public LibraryCatalogViewModel()
        {
            db.Database.EnsureCreated();

			Books = new ObservableCollection<Book>();
			Magazines = new ObservableCollection<Magazine>();

			foreach (var readable in db.Readables)
			{
				if (readable.AmountInLibrary > 0)
				{
					for (int i = 0; i < readable.AmountInLibrary; i++)
					{
						if (readable is Book book)
						{
							Books.Add(new Book(book));
						}
						else if (readable is Magazine magazine)
						{
							Magazines.Add(new Magazine(magazine));
						}
					}
				}
			}

			Magazines.CollectionChanged += (sender, e) =>
			{
				RefreshDB(sender, e);
				RefreshLabels();
			};

			Books.CollectionChanged += (sender, e) =>
			{
				RefreshDB(sender, e);
				RefreshLabels();
			};

			RefreshLabels();
		}

        private void RefreshDB(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
            {
				foreach (Readable readable in e.NewItems)
				{
                    db.Readables.First(r => r.Id == readable.Id).AmountInLibrary++;
				}
			}
			else if (e.OldItems is not null)
			{
				foreach (Readable readable in e.OldItems)
				{
					db.Readables.First(r => r.Id == readable.Id).AmountInLibrary--;
				}
			}

			db.SaveChanges();
        }

		private void RefreshLabels()
		{
			NoBooksFoundLabelVisibility = Books.Count == 0 ? Visibility.Visible :
															 Visibility.Collapsed;

			NoMagazinesFoundLabelVisibility = Magazines.Count == 0 ? Visibility.Visible :
																	 Visibility.Collapsed;
		}
    }
}
