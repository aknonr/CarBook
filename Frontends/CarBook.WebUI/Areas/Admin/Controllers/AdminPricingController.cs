using CarBook.DTO.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] //Bu area Admin'e ait olacak.
    [Route("Admin/AdminPricing")] //Bu controller içerisinde  tanımlanan metotların tamamı admin içerisinde yer alan adminbanner diziye alarak gidicek.

    public class AdminPricingController : Controller
    {
       
       
            private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

            public AdminPricingController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            [Route("Index")]

            public async Task<IActionResult> Index() //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron. 
            {
                var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

                var responseMessage = await client.GetAsync("https://localhost:7049/api/Pricings"); //GetAsync verileri listelemek için kullandığımız metotdur. 

                if (responseMessage.IsSuccessStatusCode)
                {

                    var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                    var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);

                    return View(values);
                }
                return View();

            }


            [HttpGet]
            [Route("CreatePricing")]

            public IActionResult CreatePricing()
            {

                return View();
            }

            [HttpPost]
            [Route("CreatePricing")]
            public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
            {

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createPricingDto);//Metin tabanında  gönderdiğim veriyi Json formatında gönderip serilize edecek bunun sayesinde 

                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İnputlarda Türkçe karakter göndermemizi sağlar .. 

                var responseMessage = await client.PostAsync("https://localhost:7049/api/Pricings", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
                }


                return View();
            }



            [Route("RemovePricing/{id}")]

            public async Task<IActionResult> RemovePricing(int id)
            {

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"https://localhost:7049/api/Pricings?id=" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
                }

                return View();
            }

            [HttpGet]
            [Route("UpdatePricing/{id}")]

            public async Task<IActionResult> UpdatePricing(int id)
            {

                var client = _httpClientFactory.CreateClient();
                var resposenMessage = await client.GetAsync($"https://localhost:7049/api/Pricings/{id}"); //Güncellenecek veriyi getirmemizi sağlaaycak..
                if (resposenMessage.IsSuccessStatusCode)
                {
                    var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                    return View(values);
                }
                return View();
            }



            [HttpPost]
            [Route("UpdatePricing/{id}")]

            public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)  //Güncelleme işlemin post tarafını sağlayacak kısım
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updatePricingDto);
                StringContent stringContet = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7049/api/Pricings/", stringContet);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
                }

                return View();


            }

        
    }

}


