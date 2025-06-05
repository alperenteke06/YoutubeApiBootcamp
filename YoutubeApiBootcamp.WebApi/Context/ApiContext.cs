using Microsoft.EntityFrameworkCore;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Context
{
	public class ApiContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=LOCALHOST;initial catalog=ApiYummyDb;integrated security=true;");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Chef> Chefs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<ContactMessage> ContactMessages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}
