using Book_Store.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    class ShopContext : DbContext
    {
		public DbSet<ShopBook> Books { get; set; } = null!;
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\shop.db");
		}
	}

	class LibraryContext : DbContext
	{
		public DbSet<LibraryBook> Books { get; set; } = null!;
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\library.db");
		}
	}
}
