using BL;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.Controllers
{
	public class PostsController : Controller
	{
		PostManager postManager = new PostManager();
		public IActionResult Index(int? id)
		{
			if (id == null)
			{
				return View(postManager.GetAll());
			}
			else
			{
				return View(postManager.GetAll(x => x.CategoryId == id));
			}
			
		}
		public IActionResult Detail(int id)
		{
			return View(postManager.Find(id));
		}
	}
}
