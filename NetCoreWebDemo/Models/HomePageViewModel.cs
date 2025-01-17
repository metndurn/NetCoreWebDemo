using Entities;

namespace NetCoreWebDemo.Models
{
	public class HomePageViewModel
	{/*anasayfada gosterilecek olanları burada liste halinde tutuyoruz home controllerda gosterıcez*/
		public List<Category>? Categories { get; set; }
		public List<Slider>? Sliders { get; set; }
		public List<News>? News { get; set; }
		public List<Post>? Posts { get; set; }

	}
}
