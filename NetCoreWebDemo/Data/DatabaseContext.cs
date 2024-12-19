using Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreWebDemo.Data
{
	public class DatabaseContext : DbContext
	{
        public DbSet<Category> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<User> Users { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//base.OnConfiguring(optionsBuilder);  /*MultipleActiveResultSets=true*/ 
			optionsBuilder.UseSqlServer(@" Server=.; Database=NetCoreWebDemo; Trusted_Connection=True; TrustServerCertificate=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Name = "Admin",
					SurName = "1234567890",
					Password = "12345",
					UserName = "Admin",
					Email = "admin@NetCoreWebDemo.net",
					Phone ="1234567890",
					IsActive = true,
					CreateDate = DateTime.Now
				}
				);
			base.OnModelCreating(modelBuilder);	
		}
	}
}
