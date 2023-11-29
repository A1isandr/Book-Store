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
	/// <summary>
	/// Describes behavior of library book
	/// </summary>
	class LibraryBook : Book, ILibraryBook
	{
		private string _date_added;

		/// <summary>
		/// Book's purchase date 
		/// </summary>
		public string DateAdded
		{
			get => _date_added;
			set
			{
				_date_added = value;
				OnPropertyChanged("DateAdded");
			}
		}
	}
}
