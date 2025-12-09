using DiscountServer.Dto;
using MediatR;

namespace DiscountServer.Command
{
    public record CreateDiscountCommand(string ProductId, string Name, double Price) : IRequest<DiscountDto>;
}
