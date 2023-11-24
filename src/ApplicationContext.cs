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
	/// Describes context of store
	/// </summary>
    class StoreContext : DbContext
    {
		public DbSet<ShopBook> ShopBooks { get; set; } = null!;
        public DbSet<LibraryBook> LibraryBooks { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\shop.db");
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\library.db");
        }
	}
}
