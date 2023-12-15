using Book_Store.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
	/// <summary>
	/// Describes context of store.
	/// </summary>
    class StoreContext : DbContext
    {
		/// <summary>
		/// Set of products.
		/// </summary>
		public DbSet<Book> Products { get; set; } = null!;
		/// <summary>
		/// Set of library.
		/// </summary>
		public DbSet<Book> Library { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\store.db");
        }
	}
}
