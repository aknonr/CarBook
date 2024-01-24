using CarBook.DTO.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        //API Consume Edilmesi 
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //InvokeAsync adında bir asenkron metot tanımladık ve  Bu metot, bir IViewComponentResult döndürmektedir, bu genellikle bir view component'in sonucunda olur.
            //IHttpClientFactory kullanılarak bir HttpClient örneği oluşturulur. Bu, IHttpClientFactory'nin sağladığı avantajlardan biridir. Yeni bir HttpClient oluşturmak yerine, var olanları kullanarak performansı artırır.

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7049/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
