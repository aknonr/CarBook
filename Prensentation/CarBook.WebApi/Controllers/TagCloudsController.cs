using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)  //Yapıcı Method 
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> TagCloudList()
        {
            // Burada _mediator nesnesi,  CQRS (Command Query Responsibility Segregation) deseni kullanılarak uygulama içindeki işlemleri yöneten bir mediatordur. GetTagCloudQuery adında bir sorgu sınıfı oluşturulur ve bu sorgu mediatora gönderilir. await ifadesi, mediatordan gelen yanıtın tamamlanmasını bekler. Bu, asenkron bir işlemi bekletir ve kodun başka bir iş parçasını işlemesine izin verir.
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{id}")] //Url kısmında ki id getirmesini sağlayacağız

        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id)); //Get feature sınıfını artık id'ye göre getirebilirz
            return Ok(value);
        }



        [HttpPost]

        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu  Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Bulutu başarıyla silindi");
        }

        [HttpPut] //Bu attribute, UpdateTagCloud aksiyonunun HTTP PUT isteğine yanıt vereceğini belirtir. Yani, bu aksiyon bir kaynağı güncellemek için kullanılacaktır.
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu  güncellendi");
        }

        [HttpGet("GetTagCloudByBlogId")]

        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
         var values= await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }

        //Mediator tasarım desenine ait CRUID işlemleri API ile birlikte yaptık.
    }
}
