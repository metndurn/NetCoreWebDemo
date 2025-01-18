using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using NetCoreWebDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//chgbt ye gore bu kod yazýldý ama kullandýgým zamanda cozum olmadý sýmdýlýk burada kalacak
/*builder.Configuration.GetConnectionString("DefaultConnection")*/
builder.Services.AddDbContext<DatabaseContext>();//admin tarafý ýcýn kullanýlýyor sistem hata verirse bunu geri koy options => options.UseSqlServer()
builder.Services.AddDbContext<DataBaseContext>();//Dal katmaný icin context olustu katmanlý mimari icin olusturuldu
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x =>
	{
		x.LoginPath = "/Admin/Login";
		//x.AccessDeniedPath = "/Admin/AccessDenied";
	});
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

app.UseAuthentication();//önce UseAuthentication gelir yani giriþ yapýldýgý zaman olacak
app.UseAuthorization();//sonra UseAuthorization bu ise yetkilendirme ile ilgili kod alanýdýr

app.MapControllerRoute(
		   name: "admin",
		   pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
		 );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
