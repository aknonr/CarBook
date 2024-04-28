
using CarBook.DTO.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron. 
        {
            var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Brands"); //GetAsync verileri listelemek için kullandığımız metotdur. 

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                return View(values);
            }
            return View();

        }

        [HttpGet]

        public IActionResult CreateBrand()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);//Metin tabanında  gönderdiğim veriyi Json formatında gönderip serilize edecek bunun sayesinde 

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İnputlarda Türkçe karakter göndermemizi sağlar .. 

            var responseMessage = await client.PostAsync("https://localhost:7049/api/Brands", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }


        public async Task<IActionResult> RemoveBrand(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7049/api/Brands?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateBrand(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7049/api/Brands/{id}"); //Güncellenecek veriyi getirmemizi sağlaaycak..
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)  //Güncelleme işlemin post tarafını sağlayacak kısım
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContet = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7049/api/Brands/", stringContet);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }

    }
}
