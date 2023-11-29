using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes basic behavior of a book
    /// </summary>
    class Book : ObservableObject, IBook
    {
        public int Id {  get; set; }
        protected string? _title;
		protected string? _genre;
		protected string? _publication_date;
		protected string? _description;
        protected string? _author;
        protected string? _cover;

        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

		public string? Genre
		{
			get => _genre;
			set
			{
				_genre = value;
				OnPropertyChanged("Genre");
			}
		}

		public string? PublicationDate
		{
			get => _publication_date;
			set
			{
				_publication_date = value;
				OnPropertyChanged("PublicationDate");
			}
		}

		public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string? Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }

		public string? Cover
		{
			get => _cover;
			set
			{
				_cover = value;
				OnPropertyChanged("Cover");
			}
		}
	}
}
