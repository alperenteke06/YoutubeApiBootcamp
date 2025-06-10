using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos.ProductDtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.DefaultMenuViewComponents
{
	public class _DefaultMenuProductComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultMenuProductComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var resMessage = await client.GetAsync("https://localhost:7168/api/Products/");

			if (resMessage.IsSuccessStatusCode)
			{
				var jsonData = await resMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
