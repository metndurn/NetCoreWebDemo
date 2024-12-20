using Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreWebDemo.Data
{
	public class DataSeeding
	{
		public static void Seed(IApplicationBuilder app)
		{
			var scope = app.ApplicationServices.CreateScope();
			var context = scope.ServiceProvider.GetService<DatabaseContext>();

			context.Database.Migrate();

			if (context.Database.GetPendingMigrations().Count() == 0)
			{
				if (context.Users.Count() == 0)
				{
					User user = new User()
					{
						//Id = 1,
						//Name = "Admin",
						//SurName = "1234567890",
						//Password = "12345",
						//UserName = "Admin",
						//Email = "admin@NetCoreWebDemo.net",
						//Phone = "1234567890",
						//IsActive = true,
						//CreateDate = DateTime.Now
						Name = "Admin",
						Password = "12345",
						UserName = "Admin",
						Email = "admin@NetCoreWebDemo.net",
						IsActive = true,
						CreateDate = DateTime.Now
					};
					context.Users.Add(user);
				}
				context.SaveChanges();
			}
		}
	}
}
