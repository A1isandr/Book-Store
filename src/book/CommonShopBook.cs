using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    abstract class CommonShopBook : CommonBook
    {
		/// <summary>
		/// Book's price.
		/// </summary>
		public abstract decimal Price { get; set; }
    }
}
