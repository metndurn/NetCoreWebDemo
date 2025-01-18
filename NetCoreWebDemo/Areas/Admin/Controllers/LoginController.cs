using BL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NetCoreWebDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		UserManager userManager = new UserManager();
		public IActionResult Index()
		{/*tempdata ile admin cıkıs yaptıgı zaman son kaldıgı yerı verır*/
			TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"];
			return View();
		}
		[HttpPost]//metod ismi detistirildi asynce dönüştürüldü ve login yaptırma işlemi yapıldı
		public async Task<IActionResult> IndexAsync(string email, string password, string ReturnUrl)
		{
			try
			{
				var account = userManager.Get(x => x.Email == email && x.Password == password && x.IsActive == true);
				if (account != null)
				{
					ModelState.AddModelError("", "Kullanıcı Bulunamadı!");
					TempData["Mesaj"] = "Kullanıcı Bulunamadı!";
				}
				else
				{
					var claims = new List<Claim>
				    {
					   new Claim(ClaimTypes.Email, email)
				    };
					var userIdentity = new ClaimsIdentity(claims, "Login");
					ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
					await HttpContext.SignInAsync(principal);
					//
					if (string.IsNullOrWhiteSpace(ReturnUrl)) return RedirectToAction("Index", "Default");
					else return Redirect(ReturnUrl);
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Hata Oluştu! Kullanıcı Bulunamadı!");
				TempData["Mesaj"] = "Hata Oluştu! Kullanıcı Bulunamadı!";
			}
			return View();
		}
		/*burada admin cıkıs yaptıgı zaman her turlu tekrardan gırıs yapması ıcın yazıldı*/
		[Route("Admin/Logout")]
		public async Task<IActionResult> LogoutAsync()//metod ismi detistirildi asynce dönüştürüldü ve loginden cıkıs yaptırma işlemi yapıldı
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
