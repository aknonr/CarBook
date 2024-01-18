
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)  //Yapıcı Method 
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> LocationList()
        {
            // Burada _mediator nesnesi,  CQRS (Command Query Responsibility Segregation) deseni kullanılarak uygulama içindeki işlemleri yöneten bir mediatordur. GetLocationQuery adında bir sorgu sınıfı oluşturulur ve bu sorgu mediatora gönderilir. await ifadesi, mediatordan gelen yanıtın tamamlanmasını bekler. Bu, asenkron bir işlemi bekletir ve kodun başka bir iş parçasını işlemesine izin verir.
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")] //Url kısmında ki id getirmesini sağlayacağız

        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id)); //Get feature sınıfını artık id'ye göre getirebilirz
            return Ok(value);
        }



        [HttpPost]

        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Lokasyon başarıyla silindi");
        }

        [HttpPut] //Bu attribute, UpdateLocation aksiyonunun HTTP PUT isteğine yanıt vereceğini belirtir. Yani, bu aksiyon bir kaynağı güncellemek için kullanılacaktır.
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon başarıyla güncellendi");
        }


        //Mediator tasarım desenine ait CRUID işlemleri API ile birlikte yaptık.

    }
}
