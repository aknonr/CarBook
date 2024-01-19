using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)  //Yapıcı Method 
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> PricingList()
        {
            // Burada _mediator nesnesi,  CQRS (Command Query Responsibility Segregation) deseni kullanılarak uygulama içindeki işlemleri yöneten bir mediatordur. GetPricingQuery adında bir sorgu sınıfı oluşturulur ve bu sorgu mediatora gönderilir. await ifadesi, mediatordan gelen yanıtın tamamlanmasını bekler. Bu, asenkron bir işlemi bekletir ve kodun başka bir iş parçasını işlemesine izin verir.
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")] //Url kısmında ki id getirmesini sağlayacağız

        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id)); //Get feature sınıfını artık id'ye göre getirebilirz
            return Ok(value);
        }



        [HttpPost]

        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme türü Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Ödeme türü başarıyla silindi");
        }

        [HttpPut] //Bu attribute, UpdatePricing aksiyonunun HTTP PUT isteğine yanıt vereceğini belirtir. Yani, bu aksiyon bir kaynağı güncellemek için kullanılacaktır.
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme türü başarıyla güncellendi");
        }


        //Mediator tasarım desenine ait CRUID işlemleri API ile birlikte yaptık.
    }
}
