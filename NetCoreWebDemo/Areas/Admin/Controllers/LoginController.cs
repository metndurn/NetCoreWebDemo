using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
