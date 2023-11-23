using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Book_Store.src;

namespace Book_Store.MVVM.Model
{
	class ShopBook : ObservableObject, IBook
	{
		public int Id { get; set; }

		private string? name;
		private string? description;
		private string? author;
		private decimal price;

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

		/// <summary>
		/// Book's price.
		/// </summary>
		public decimal Price
		{
			get => price;
			set 
			{
				price = value;
				OnPropertyChanged("Price");
			}
		}
	}
}
