using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] //Bu area Admin'e ait olacak.
    [Route("Admin/AdminStatistics")] //Bu controller içerisinde  tanımlanan metotların tamamı admin içerisinde yer alan adminbanner diziye alarak gidicek.

    public class AdminStatisticsController : Controller
    {

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
