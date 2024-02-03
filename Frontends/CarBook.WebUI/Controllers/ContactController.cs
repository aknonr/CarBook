using CarBook.DTO.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto) //Bu metot, bir HTTP POST isteği alarak çalışır. Parametre olarak CreateContactDto tipinde bir nesne alır ve Task<IActionResult> tipinde bir sonuç döner.
        {
            var client=_httpClientFactory.CreateClient(); //Client oluşturulmasını yaptım. _httpClientFactory sınıfını kullanarak bir HTTP istemcisini oluşturdum. HttpClient, HTTP istekleri göndermenizi sağlayan bir sınıftır.
            createContactDto.SendDate = DateTime.Now; //DateTime.Now;: createContactDto içindeki SendDate özelliğine, şu anki tarih ve saat değerini atamasını sağladım.
            var jsonData = JsonConvert.SerializeObject(createContactDto);//createContactDto nesnesini JSON formatına çevrilmesini sağladım. Bu, veriyi HTTP isteği ile iletmek için kullandım.

            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json"); // JSON verisini içeren StringContent nesnesi oluşturuldu ve Bu nesne, HTTP isteği ile gönderilecek veriyi içerir.

            var responseMessage = await client.PostAsync("https://localhost:7049/api/Contacts",stringContent);// client üzerinden, belirtilen URL'ye bir HTTP POST isteği gönderdim. Gönderdiğimiz JSON verisi stringContent içindedir. Sonuç olarak, bir HttpResponseMessage alacağız.


            if (responseMessage.IsSuccessStatusCode)
// Gönderilen isteğin başarıyla tamamlandığını kontrol edeceğiz. Eğer başarılıysa: return RedirectToAction("Index", "Default");: "Index" adlı eylemi içeren "Default" adlı kontrolcüye yönlendirme yapılır. Yani, isteği başarıyla gönderdikten sonra kullanıcıyı başka bir sayfaya yönlendireceğiz.
//return View();: Eğer istek başarısız olursa veya başarılı bir yanıt alınamazsa, aynı sayfaya(Index) geri dönülecek.



            {
                return RedirectToAction("Index", "Default");

            }
            return View();
            

        }
         

    }
}
