using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{

    // Bir Area içerisine Contreller ekleniliyorsa bu contrellar hangi area ait olmasını belirlememiz lazım.

    [Area("Admin")] //Bu area Admin'e ait olacak.
    [Route("Admin/AdminBlog")] //Bu controller içerisinde  tanımlanan metotların tamamı admin içerisinde yer alan adminbanner diziye alarak gidicek.
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]

        public async Task<IActionResult> Index() //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron. 
        {
            var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Blogs/GetAllBlogsWithAuthorList"); //GetAsync verileri listelemek için kullandığımız metotdur. 

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);

                return View(values);
            }
            return View();

        }


        [HttpGet]
        [Route("CreateBlog")]

        public IActionResult CreateBlog()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlogDto);//Metin tabanında  gönderdiğim veriyi Json formatında gönderip serilize edecek bunun sayesinde 

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İnputlarda Türkçe karakter göndermemizi sağlar .. 

            var responseMessage = await client.PostAsync("https://localhost:7049/api/Blogs", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }


            return View();
        }



        [Route("RemoveBlog/{id}")]

        public async Task<IActionResult> RemoveBlog(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7049/api/Blogs?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }

            return View();
        }



        [HttpGet]
        [Route("UpdateBlog/{id}")]

        public async Task<IActionResult> UpdateBlog(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7049/api/Blogs/{id}"); //Güncellenecek veriyi getirmemizi sağlaaycak..
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpPost]
        [Route("UpdateBlog/{id}")]

        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)  //Güncelleme işlemin post tarafını sağlayacak kısım
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContet = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7049/api/Blogs/", stringContet);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }

            return View();


        }

    }
}

