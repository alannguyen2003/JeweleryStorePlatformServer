using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformBusinessObject.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class PromotionDAO
    {
        private readonly AppDbContext _context;
        private static PromotionDAO _instance;

        private PromotionDAO()
        {
            _context = new AppDbContext();
        }

        public static PromotionDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PromotionDAO();
                }
                return _instance;
            }
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
            var existingPromotion = _context.Promotions.Local.FirstOrDefault(p => p.Id == promotion.Id);
            if (existingPromotion != null)
            {
                _context.Entry(existingPromotion).State = EntityState.Detached;
            }

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
        public async Task AddRange(IEnumerable<Promotion> promotion)
        {
            await _context.Promotions.AddRangeAsync(promotion);
            await _context.SaveChangesAsync();
        }
    }
}
