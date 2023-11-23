using Book_Store.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.Model
{
	class LibraryBook : ObservableObject, IBook
	{
		public int Id { get; set; }

		private string? name;
		private string? description;
		private string? author;
		private DateTime date_added;

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

		public DateTime DateAdded
		{
			get => date_added;
			set
			{
				date_added = value;
				OnPropertyChanged("Price");
			}
		}
	}
}
