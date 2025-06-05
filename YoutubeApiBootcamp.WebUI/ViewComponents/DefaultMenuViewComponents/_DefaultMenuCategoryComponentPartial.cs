using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos.CategoryDtos;
using YoutubeApiBootcamp.WebUI.Dtos.ServiceDtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMenuCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var resMessage = await client.GetAsync("https://localhost:7168/api/Categories/");

            if (resMessage.IsSuccessStatusCode)
            {
                var jsonData = await resMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
