using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
