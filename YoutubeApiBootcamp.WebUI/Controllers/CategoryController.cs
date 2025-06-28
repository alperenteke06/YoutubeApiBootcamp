using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }
    }
}
