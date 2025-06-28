using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeApiBootcamp.WebUI.Dtos.ContactMessageDtos;
using YoutubeApiBootcamp.WebUI.Dtos.NotificationDto;

namespace YoutubeApiBootcamp.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarNotificationListAdminLayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarNotificationListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var resMessage = await client.GetAsync("https://localhost:7168/api/Notifications");

            if (resMessage.IsSuccessStatusCode)
            {
                var jsonData = await resMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
