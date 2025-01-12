﻿using BL;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebDemo.Controllers
{
	public class PostsController : Controller/*burada hata var bulamadım*/
	{
		PostManager postManager = new PostManager();
		public IActionResult Index()
		{
			return View(postManager.GetAll());
		}
		public IActionResult Detail(int id)
		{
			return View(postManager.Find(id));
		}
	}
}
