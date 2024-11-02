using Microsoft.EntityFrameworkCore;
using PaymentSystem.DataLayer.Entities;

namespace PaymentSystem.DataLayer.EF
{
	public class PaymentSystemContext : DbContext
	{
		DbSet<Card> Cards { get; set; }
		DbSet<Card> Products { get; set; }
		public PaymentSystemContext(DbContextOptions options) : base(options)
		{
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed the data only if it doesn't already exist
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Description = "Milk", Price = 1.07m, QuantityInStock = 10, IsWholesaleProduct = true },
				new Product { Id = 2, Description = "Cream 400g", Price = 2.71m, QuantityInStock = 20, IsWholesaleProduct = true },
				new Product { Id = 3, Description = "Yogurt 400g", Price = 2.10m, QuantityInStock = 7, IsWholesaleProduct = true },
				new Product { Id = 4, Description = "Packed potatoes 1kg", Price = 1.47m, QuantityInStock = 30, IsWholesaleProduct = false },
				new Product { Id = 5, Description = "Packed cabbage 1kg", Price = 1.19m, QuantityInStock = 15, IsWholesaleProduct = false },
				new Product { Id = 6, Description = "Packed tomatoes 350g", Price = 1.60m, QuantityInStock = 50, IsWholesaleProduct = false },
				new Product { Id = 7, Description = "Packed apples 1kg", Price = 2.78m, QuantityInStock = 18, IsWholesaleProduct = false },
				new Product { Id = 8, Description = "Packed oranges 1kg", Price = 3.20m, QuantityInStock = 12, IsWholesaleProduct = false },
				new Product { Id = 9, Description = "Packed bananas 1kg", Price = 1.10m, QuantityInStock = 25, IsWholesaleProduct = true },
				new Product { Id = 10, Description = "Packed beef fillet 1kg", Price = 12.8m, QuantityInStock = 7, IsWholesaleProduct = false },
				new Product { Id = 11, Description = "Packed pork fillet 1kg", Price = 8.52m, QuantityInStock = 14, IsWholesaleProduct = false },
				new Product { Id = 12, Description = "Packed chicken breasts 1kg", Price = 10.75m, QuantityInStock = 18, IsWholesaleProduct = false },
				new Product { Id = 13, Description = "Baguette 360g", Price = 1.30m, QuantityInStock = 10, IsWholesaleProduct = true },
				new Product { Id = 14, Description = "Drinking water 1,51", Price = 0.80m, QuantityInStock = 100, IsWholesaleProduct = false },
				new Product { Id = 15, Description = "Olive oil 500ml", Price = 5.30m, QuantityInStock = 16, IsWholesaleProduct = false },
				new Product { Id = 16, Description = "Sunflower oil 1l", Price = 1.20m, QuantityInStock = 12, IsWholesaleProduct = false },
				new Product { Id = 17, Description = "Chocolate Ritter sport 100g", Price = 1.10m, QuantityInStock = 50, IsWholesaleProduct = true },
				new Product { Id = 18, Description = "Paulaner 0,5l", Price = 1.10m, QuantityInStock = 100, IsWholesaleProduct = false },
				new Product { Id = 19, Description = "Whiskey Jim Beam 1l", Price = 13.99m, QuantityInStock = 30, IsWholesaleProduct = false },
				new Product { Id = 20, Description = "Whiskey Jack Daniels 11", Price = 17.19m, QuantityInStock = 20, IsWholesaleProduct = false }
			);

			modelBuilder.Entity<Card>().HasData(
				new Card { Id = 1, CardNumber = 1111, Discount = 0.03m },
				new Card { Id = 2, CardNumber = 2222, Discount = 0.03m },
				new Card { Id = 3, CardNumber = 3333, Discount = 0.04m },
				new Card { Id = 4, CardNumber = 4444, Discount = 0.05m }
			);
		}
	}
}
