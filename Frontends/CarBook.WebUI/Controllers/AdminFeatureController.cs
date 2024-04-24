using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarDtos;
using CarBook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron. 
        {
            var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Features"); //GetAsync verileri listelemek için kullandığımız metotdur. 

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(values);
            }
            return View();

        }

        [HttpGet]

        public IActionResult CreateFeature()
        {
           
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);//Metin tabanında  gönderdiğim veriyi Json formatında gönderip serilize edecek bunun sayesinde 

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İnputlarda Türkçe karakter göndermemizi sağlar .. 

            var responseMessage = await client.PostAsync("https://localhost:7049/api/Features", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }


        public async Task<IActionResult> RemoveFeature(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7049/api/Features/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateFeature(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7049/api/Features/{id}"); //Güncellenecek veriyi getirmemizi sağlaaycak..
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)  //Güncelleme işlemin post tarafını sağlayacak kısım
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContet = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7049/api/Features/", stringContet);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }




    }
}
