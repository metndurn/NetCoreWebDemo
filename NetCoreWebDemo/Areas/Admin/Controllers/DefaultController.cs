using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.Areas.Admin.Controllers
{
	[Area("Admin")]/*admin girişini çalıstırmak için bu gereklidir*/
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
