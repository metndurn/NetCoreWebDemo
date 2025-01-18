using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using NetCoreWebDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//chgbt ye gore bu kod yaz�ld� ama kulland�g�m zamanda cozum olmad� s�md�l�k burada kalacak
/*builder.Configuration.GetConnectionString("DefaultConnection")*/
builder.Services.AddDbContext<DatabaseContext>();//admin taraf� �c�n kullan�l�yor sistem hata verirse bunu geri koy options => options.UseSqlServer()
builder.Services.AddDbContext<DataBaseContext>();//Dal katman� icin context olustu katmanl� mimari icin olusturuldu
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

app.UseAuthentication();//�nce UseAuthentication gelir yani giri� yap�ld�g� zaman olacak
app.UseAuthorization();//sonra UseAuthorization bu ise yetkilendirme ile ilgili kod alan�d�r

app.MapControllerRoute(
		   name: "admin",
		   pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
		 );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
