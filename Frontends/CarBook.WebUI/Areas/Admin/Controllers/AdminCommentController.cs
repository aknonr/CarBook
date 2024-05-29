using CarBook.DTO.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{


    // Bir Area içerisine Contreller ekleniliyorsa bu contrellar hangi area ait olmasını belirlememiz lazım.

    [Area("Admin")] //Bu area Admin'e ait olacak.
    [Route("Admin/AdminComment")] //Bu controller içerisinde  tanımlanan metotların tamamı admin içerisinde yer alan adminbanner diziye alarak gidicek.

    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //  IHttpClientFactory İnterface örnekleyerek bizim Api tarafından Consume işlemimizin başlangıcı olarak kabul ederiz. Bizim istek yapabilmemizi sağlayan köprü görevine üstlenecek . 

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]

        public async Task<IActionResult> Index(int id) //asenkron kullanmamızın sebebi  bu field alanın içerisinde metotta asenkron olacak..  İşlem devam ederken Aynı anda birden fazla işlem yapmamıza işlem sağlar asenkron.  İd değeri alacak dışarıdan
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient(); // İstemcinin oluşturulma adımı 

            var responseMessage = await client.GetAsync("https://localhost:7049/api/Comments/CommentListByBlog?id="+ id); //GetAsync verileri listelemek için kullandığımız metotdur. 

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response message bize gelen durum kodunu string moduna dönüştürüp bizim oluşturduğumuz jsonData değişkenin içerisine atayacak . 
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                return View(values);
            }
            return View();

        }
    }
}
