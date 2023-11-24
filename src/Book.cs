using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes basic behavior for a book
    /// </summary>
    class Book : ObservableObject, IBook
    {
        public int Id {  get; set; }
        protected string? name;
        protected string? description;
        protected string? author;

        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
    }
}
