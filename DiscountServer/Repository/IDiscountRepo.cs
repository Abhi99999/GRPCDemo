using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Protos;

namespace DiscountServer.Repository
{
    public interface IDiscountRepo
    {
        Task<Discount?> GetDiscountAsync(int id);
        Task<DiscountDto> CreateDiscountAsync(Discount discount);
    }
}
