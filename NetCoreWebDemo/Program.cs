using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetCoreWebDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//chgbt ye gore bu kod yaz�ld� ama kulland�g�m zamanda cozum olmad� s�md�l�k burada kalacak
/*builder.Configuration.GetConnectionString("DefaultConnection")*/
builder.Services.AddDbContext<DatabaseContext>();//admin taraf� �c�n kullan�l�yor sistem hata verirse bunu geri koy options => options.UseSqlServer()
builder.Services.AddDbContext<DatabaseContext>();//Dal katman� icin context olustu

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
		   name: "admin",
		   pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
		 );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
