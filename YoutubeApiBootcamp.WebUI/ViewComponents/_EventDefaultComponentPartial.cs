using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos.EventDtos;
using YoutubeApiBootcamp.WebUI.Dtos.ServiceDtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _EventDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _EventDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var resMessage = await client.GetAsync("https://localhost:7168/api/YummyEvents/");

			if (resMessage.IsSuccessStatusCode)
			{
				var jsonData = await resMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
