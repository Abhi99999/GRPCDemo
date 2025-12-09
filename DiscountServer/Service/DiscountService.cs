using DiscountServer.Command;
using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Extension;
using DiscountServer.Protos;
using DiscountServer.Query;
using Grpc.Core;
using MediatR;

namespace DiscountServer.Service
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;

        public DiscountService(IMediator mediator) 
        { 
            _mediator = mediator;
        }
        public override async Task<DiscountModel> GetDiscount(DiscountId request, ServerCallContext context)
        {
            var query = new GetDiscountByIdQuery(request.Id);
            DiscountDto dto = await _mediator.Send(query);
            return dto.ToModel();
        }
        public override async Task<DiscountDtoModel> CreateDiscount(DiscountModel request, ServerCallContext context)
        {
            var cmd = new CreateDiscountCommand(request.ProductId,request.Name,request.Price);
            DiscountDto dto = await _mediator.Send(cmd);
            return dto.ToModelDto();
        }
    }
}
