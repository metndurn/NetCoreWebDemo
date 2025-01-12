using BL;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.Controllers
{
	public class NewsController : Controller
	{
		NewsManager newsManager = new NewsManager();/*burada hata var bulamadım*/
		public IActionResult Index()
		{
			return View(newsManager.GetAll());
		}
		public IActionResult Detail(int id)
		{
			return View(newsManager.Find(id));
		}
	}
}
