using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
	public class _NavbarFormInlineAdminLayoutComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
