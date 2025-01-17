using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.ViewComponents
{
	public class Categories : ViewComponent
	{
		public IViewComponentResult Invoke()/*anasayfada categorileri liste halinde gostermek ıcın yazıyoruz*/
		{
			BL.CategoryManager categoryManager = new BL.CategoryManager();
			return View(categoryManager.GetAll());
		}
	}
}
