using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    abstract class CommonLibraryBook : CommonBook
    {
		/// <summary>
		/// Book's purchase date 
		/// </summary>
		public abstract string DateAdded { get; set; }
    }
}
