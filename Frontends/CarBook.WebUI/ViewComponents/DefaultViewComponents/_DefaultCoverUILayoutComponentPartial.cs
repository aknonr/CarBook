using CarBook.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() //View Component'ları, parçacıklar halinde kullanıcı arayüzü bileşenleri oluşturmamıza olanak tanıyan yapısal bir özelliktir. Bu özel View Component, bir HTTP GET isteği kullanarak bir API'den veri çeker ve ardından bu veriyi bir View'a gönderir. Invoke Metodu: Bu metot, View Component'ının başlatılması veya çağrılması sırasında çalıştırılan ana metottur.
        {

            var client = _httpClientFactory.CreateClient(); // 'HttpClient' Oluşturulması; '_httpClientFactory' aracılığıyla bir HttpClient örneği oluşturuluyor. HttpClientFactory, HttpClient'ın yönetimini ve performansını artırmak için kullanılır. Her istek için yeni bir HttpClient oluşturmak yerine, aynı HttpClient örneğini paylaşarak kaynakları daha etkili kullanmanızı sağlar bize.

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Banners"); //Get isteğini gönderdiğimiz yer burası

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
                //View'a Veri Gönderme: Başarılı deserialization işlemi sonrasında, View Component, bir View'a values adı altında bu deserialization sonucu elde edilen liste verisini gönderiyor.

                //View Döndürme: Eğer API'den başarılı bir şekilde veri çekilebilirse, bu veri ile birlikte bir View döndürülüyor. Aksi takdirde, boş bir View döndürülüyor.
            }
            
            return View();
        }
    }
}
