using DiscountServer.Context;
using DiscountServer.Dto;
using DiscountServer.Entity;
using DiscountServer.Extension;
using DiscountServer.Protos;
using Microsoft.EntityFrameworkCore;

namespace DiscountServer.Repository
{
    public class DiscountRepo : IDiscountRepo
    {
        private readonly AppDbContext _context;
        public DiscountRepo(AppDbContext Context)
        {
            _context = Context;
        }

        public async Task<DiscountDto> CreateDiscountAsync(Discount discount)
        {
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discount.ToDto();
        }

        public async Task<Discount?> GetDiscountAsync(int id)
        {
            return await _context.Discounts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
