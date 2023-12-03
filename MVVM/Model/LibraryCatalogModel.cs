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
	/// Describes behavior of library book.
	/// </summary>
	class LibraryBook : CommonLibraryBook
	{
		private string _dateAdded;

		public override string DateAdded
		{
			get => _dateAdded;
			set
			{
				_dateAdded = value;
			}
		}
	}
}
