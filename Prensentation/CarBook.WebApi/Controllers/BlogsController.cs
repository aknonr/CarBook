using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)  //Yapıcı Method 
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> BlogList()
        {
            // Burada _mediator nesnesi,  CQRS (Command Query Responsibility Segregation) deseni kullanılarak uygulama içindeki işlemleri yöneten bir mediatordur. GetBlogQuery adında bir sorgu sınıfı oluşturulur ve bu sorgu mediatora gönderilir. await ifadesi, mediatordan gelen yanıtın tamamlanmasını bekler. Bu, asenkron bir işlemi bekletir ve kodun başka bir iş parçasını işlemesine izin verir.
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")] //Url kısmında ki id getirmesini sağlayacağız

        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id)); //Get feature sınıfını artık id'ye göre getirebilirz
            return Ok(value);
        }



        [HttpPost]

        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi");
        }

        [HttpPut] //Bu attribute, UpdateBlog aksiyonunun HTTP PUT isteğine yanıt vereceğini belirtir. Yani, bu aksiyon bir kaynağı güncellemek için kullanılacaktır.
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla güncellendi");
        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]

        public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());

            return Ok(values);
        }

        //Mediator tasarım desenine ait CRUID işlemleri API ile birlikte yaptık.
    }
}
