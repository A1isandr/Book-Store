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
        protected string? title;
		protected string? genre;
		protected string? publication_date;
		protected string? description;
        protected string? author;
        protected string? cover;

        public string? Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

		public string? Genre
		{
			get => genre;
			set
			{
				genre = value;
				OnPropertyChanged("Genre");
			}
		}

		public string? PublicationDate
		{
			get => publication_date;
			set
			{
				publication_date = value;
				OnPropertyChanged("Title");
			}
		}

		public string? Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string? Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

		public string? Cover
		{
			get => cover;
			set
			{
				cover = value;
				OnPropertyChanged("Author");
			}
		}
	}
}
