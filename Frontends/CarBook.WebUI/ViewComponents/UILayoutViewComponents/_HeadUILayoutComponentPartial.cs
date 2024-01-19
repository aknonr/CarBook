using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            // View Component: Burada partial vivew compnent adı altında ayrı bir klasör oluşturulup daha sonra onun içine folder stracture uygun bir yapı kullanmamıza olanak sağlar. ViewComponent için backende tarafında işlemlerin yapılacağı bir class oluşturuluyor ve bu class ViewComponent'ten miras alıyoruz...  Bunndan sonra field alanından view geriye değer döndürecek bir method oluşturduk..
            //Genellikle Method ismini Invoke verildiği için bizde Invoke verdik..

            return View();
        }
    }
}
