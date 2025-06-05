using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos.ServiceDtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _ServiceDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ServiceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var resMessage = await client.GetAsync("https://localhost:7168/api/Services/");

			if (resMessage.IsSuccessStatusCode)
			{
				var jsonData = await resMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
