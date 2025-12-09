using DiscountServer.Command;
using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Protos;
using System.Runtime.CompilerServices;

namespace DiscountServer.Extension
{
    public static class DiscountMapper
    {
        public static DiscountDto ToDto(this Discount discount)
        {
            return new DiscountDto(discount.Id,discount.ProductId!,discount.Name!,discount.Price);
        }
        public static Discount ToEntity(this CreateDiscountCommand cmd)
        {
            return new Discount
            {
                ProductId = cmd.ProductId,
                Name = cmd.Name, 
                Price = cmd.Price
            };
        }
        public static DiscountModel ToModel(this DiscountDto dto)
        {
            return new DiscountModel
            {
                Id = dto.id,
                Name = dto.name,
                ProductId = dto.productId,
                Price = dto.price
            };
        }
        public static DiscountDtoModel ToModelDto(this DiscountDto dto)
        {
            return new DiscountDtoModel
            {
                Name = dto.name,
                ProductId = dto.productId,
                Price = dto.price
            };
        }
    }
}
