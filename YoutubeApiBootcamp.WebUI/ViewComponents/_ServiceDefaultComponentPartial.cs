using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _ServiceDefaultComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
