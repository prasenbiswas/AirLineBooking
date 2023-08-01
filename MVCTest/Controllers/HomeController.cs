using Microsoft.AspNetCore.Mvc;

namespace MVCTest.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
