using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _ChefDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ChefDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var resMessage = await client.GetAsync("https://localhost:7168/api/Chefs/");

			if (resMessage.IsSuccessStatusCode)
			{
				var jsonData = await resMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
