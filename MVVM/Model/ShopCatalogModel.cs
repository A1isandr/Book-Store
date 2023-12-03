using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Book_Store.src;

namespace Book_Store.MVVM.Model
{
    /// <summary>
    /// Describes behavior of shop book.
    /// </summary>
    class ShopBook : CommonShopBook
	{
		private decimal _price;

		public override decimal Price
		{
			get => _price;
			set
			{
				_price = value;
			}
		}
	}
}
