using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly AppDbContext _context;

        public PromotionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await _context.Promotions.ToListAsync();
        }

        public async Task AddNewPromotion(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task<Promotion> UpdatePromotion(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
            return promotion;
        }

        public async Task<bool> DeletePromotion(int promotionId)
        {
            var promotion = await _context.Promotions.FindAsync(promotionId);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Promotion> GetPromotionById(int promotionId)
        {
            return await _context.Promotions.FindAsync(promotionId);
        }
    }
}
