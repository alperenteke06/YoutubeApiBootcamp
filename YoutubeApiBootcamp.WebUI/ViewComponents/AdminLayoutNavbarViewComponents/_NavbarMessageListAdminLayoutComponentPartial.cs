using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos;
using YoutubeApiBootcamp.WebUI.Dtos.ContactMessageDtos;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
	public class _NavbarMessageListAdminLayoutComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var resMessage = await client.GetAsync("https://localhost:7168/api/ContactMessages/MessageListByIsReadyFalse");

			if (resMessage.IsSuccessStatusCode)
			{
				var jsonData = await resMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultContactMessageIsReadFalseDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
