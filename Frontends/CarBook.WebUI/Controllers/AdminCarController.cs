using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
           _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron. 
        {
            var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Cars/GetCarWithBrand"); //GetAsync verileri listelemek için kullandığımız metotdur. 

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                var values =JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(jsonData);
                
                return View(values);
            }
            return View();

        }

        [HttpGet]

        public async Task<IActionResult> CreateCar()
        {
            var client= _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Brands");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values= JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

            List<SelectListItem> brandValues=(from x in values 
                                              select new SelectListItem
                                              {
                                                  Text=x.name,
                                                  Value=x.brandID.ToString()

                                              }).ToList();

            ViewBag.BrandValues = brandValues;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {

            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createCarDto);//Metin tabanında  gönderdiğim veriyi Json formatında gönderip serilize edecek bunun sayesinde 

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İnputlarda Türkçe karakter göndermemizi sağlar .. 

            var responseMessage = await client.PostAsync("https://localhost:7049/api/Cars", stringContent); 
            
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {

            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7049/api/Cars/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateCar(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7049/api/Brands");

            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();

            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);

            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.name,
                                                    Value = x.brandID.ToString()

                                                }).ToList();

            ViewBag.BrandValues = brandValues;




            var resposenMessage = await client.GetAsync($"https://localhost:7049/api/Cars/{id}"); //Güncellenecek veriyi getirmemizi sağlaaycak..
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)  //Güncelleme işlemin post tarafını sağlayacak kısım
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContet=new StringContent(jsonData, Encoding.UTF8, "application/json" );
            var responseMessage = await client.PutAsync("https://localhost:7049/api/Cars/", stringContet);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }


    }
}
