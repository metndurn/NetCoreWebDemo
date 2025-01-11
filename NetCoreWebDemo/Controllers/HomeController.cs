using BL;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebDemo.Models;
using System.Diagnostics;

namespace NetCoreWebDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		/*tek tek istenip kodlar kullanılacaktır anasayfa ıcın gereklıdır*/
		CategoryManager categoryManager = new CategoryManager();
		SliderManager sliderManager = new SliderManager();
		NewsManager newsManager = new NewsManager();
		PostManager postManager = new PostManager();
		public HomeController(ILogger<HomeController> logger)//, CategoryManager categoryManager
		{
			_logger = logger;
			//_categoryManager = categoryManager;
		}

		public IActionResult Index()
		{/*ilgili alanların tek tek istenmesi gerekiyor bunu en basta verip daha sonra
		  burada doldurmak ıcın managerlardan ısteyıp gosterıcez*/
			var model = new HomePageViewModel()
			{
				Categories = categoryManager.GetAll(),
				Sliders = sliderManager.GetAll(),
				News = newsManager.GetAll(),
				Posts = postManager.GetAll()
			};
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}