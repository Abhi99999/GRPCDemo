using DiscountServer.Dto;
using MediatR;

namespace DiscountServer.Query
{
    public record GetDiscountByIdQuery(int Id) : IRequest<DiscountDto>;
}
