using Microsoft.EntityFrameworkCore;

namespace EasyShop.Api.Data
{
	public class ShopContext : DbContext
	{
		public ShopContext(DbContextOptions<ShopContext> options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasMany(p => p.ProductImages)
				.WithOne(pi => pi.Product)
				.HasForeignKey(pi => pi.ProductId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
