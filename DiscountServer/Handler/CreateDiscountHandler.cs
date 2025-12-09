using DiscountServer.Command;
using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Extension;
using DiscountServer.Repository;
using MediatR;

namespace DiscountServer.Handler
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, DiscountDto>
    {
        private readonly IDiscountRepo _repo;

        public CreateDiscountHandler(IDiscountRepo repo)
        {
            _repo = repo;
        }
        public async Task<DiscountDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount discount = request.ToEntity();
            return await _repo.CreateDiscountAsync(discount);
        }
    }
}
