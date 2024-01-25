using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

using CarBook.Application.Features.Mediator.Queries.TestİmonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)  //Yapıcı Method 
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> TestimonialList()
        {
            // Burada _mediator nesnesi,  CQRS (Command Query Responsibility Segregation) deseni kullanılarak uygulama içindeki işlemleri yöneten bir mediatordur. GetTestimonialQuery adında bir sorgu sınıfı oluşturulur ve bu sorgu mediatora gönderilir. await ifadesi, mediatordan gelen yanıtın tamamlanmasını bekler. Bu, asenkron bir işlemi bekletir ve kodun başka bir iş parçasını işlemesine izin verir.
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")] //Url kısmında ki id getirmesini sağlayacağız

        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id)); //Get feature sınıfını artık id'ye göre getirebilirz
            return Ok(value);
        }



        [HttpPost]

        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans başarıyla silindi");
        }

        [HttpPut] //Bu attribute, UpdateTestimonial aksiyonunun HTTP PUT isteğine yanıt vereceğini belirtir. Yani, bu aksiyon bir kaynağı güncellemek için kullanılacaktır.
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans başarıyla güncellendi");
        }


        //Mediator tasarım desenine ait CRUID işlemleri API ile birlikte yaptık.
    }
}
