using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformBusinessObject.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetAllPromotions();
        Task AddNewPromotion(Promotion promotion);
        Task<Promotion> UpdatePromotion(Promotion promotion);
        Task<bool> DeletePromotion(int promotionId);
        Task<Promotion> GetPromotionById(int promotionId);
        Task AddRange(IEnumerable<Promotion> promotions);
    }
}
