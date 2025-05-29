using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _HeadDefaultComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
