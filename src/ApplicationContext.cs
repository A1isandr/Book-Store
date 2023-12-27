using Book_Store.MVVM.Model;
using Microsoft.EntityFrameworkCore;

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
		public DbSet<Readable> Readables { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=..\..\..\db\store.db");
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Readable>()
				.ToTable("Readables")
				.HasDiscriminator<string>("Type") // Добавляем дискриминатор
				.HasValue<Book>("book") // Значение дискриминатора для книг
				.HasValue<Magazine>("magazine"); // Значение дискриминатора для журналов
		}
	}
}
