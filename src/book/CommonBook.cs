using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes basic behavior of a book.
    /// </summary>
    class CommonBook : Book
    {
        public override int Id {  get; set; }
        protected string? _title;
		protected string? _genre;
		protected string? _publication_date;
		protected string? _description;
        protected string? _author;
        protected string? _cover;

        public override string? Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

		public override string? Genre
		{
			get => _genre;
			set
			{
				_genre = value;
			}
		}

		public override string? PublicationDate
		{
			get => _publication_date;
			set
			{
				_publication_date = value;
			}
		}

		public override string? Description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }

        public override string? Author
        {
            get => _author;
            set
            {
                _author = value;
            }
        }

		public override string? Cover
		{
			get => _cover;
			set
			{
				_cover = value;
			}
		}
	}
}
