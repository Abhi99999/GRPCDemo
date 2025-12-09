using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Extension;
using DiscountServer.Query;
using DiscountServer.Repository;
using MediatR;

namespace DiscountServer.Handler
{
    public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto>
    {
        private readonly IDiscountRepo _repo;

        public GetDiscountByIdHandler(IDiscountRepo repo)
        {
            _repo = repo;
        }

        public async Task<DiscountDto> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            Discount? discount = await _repo.GetDiscountAsync(request.Id);
            if (discount == null)
                return new DiscountDto(0, "0", "No Coupon Found", 0);
            return discount.ToDto();
        }
    }
}
