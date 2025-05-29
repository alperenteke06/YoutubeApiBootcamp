using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _AboutDefaultComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
