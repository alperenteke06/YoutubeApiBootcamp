using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
