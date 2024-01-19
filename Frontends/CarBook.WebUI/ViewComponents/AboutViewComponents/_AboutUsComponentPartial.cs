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

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            //InvokeAsync adında bir asenkron metot tanımladık ve  Bu metot, bir IViewComponentResult döndürmektedir, bu genellikle bir view component'in sonucudur.
            //IHttpClientFactory kullanılarak bir HttpClient örneği oluşturulur. Bu, IHttpClientFactory'nin sağladığı avantajlardan biridir. Yeni bir HttpClient oluşturmak yerine, var olanları kullanarak performansı artırır.

            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7049/api/Abouts");//Burda API GET isteği gönderdik 

            if(responseMessage.IsSuccessStatusCode) //API'den alınan cevabın başarı durumunu kontrol eder. Eğer HTTP yanıtı başarılıysa (HTTP 2xx), işleme devam edilir.
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                //Başarılı bir durumda, API'den gelen veri, önce bir string olarak okunur (ReadAsStringAsync()). Ardından, bu JSON verisi JsonConvert.DeserializeObject kullanılarak belirli bir tipe (List<ResultAboutDto>) deserialization edilir.
                return View(values);
            }

            return View();
        }
    }
}
