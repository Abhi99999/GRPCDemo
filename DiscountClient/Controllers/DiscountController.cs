using DiscountClient.Entity;
using DiscountClient.Service;
using DiscountServer.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountGrpcService _grpc;
        public DiscountController(DiscountGrpcService grpc)
        {
            _grpc = grpc;
        }
        [HttpPost]
        public async Task<ActionResult<DiscountDtoModel>> Create([FromBody] CreateDiscountRequest request)
        {
            var grpcModel = new DiscountModel
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Price = request.Price
            };
            var created = await _grpc.CreateDiscount(grpcModel);
            return Ok(created);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            // Call gRPC client
            var discount = await _grpc.GetDiscount(id);
            if (discount == null)
                return NotFound();
            return Ok(discount);
        }
    }
}
