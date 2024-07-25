using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformBusinessObject.Transaction;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class PromotionRepository : IPromotionRepository
    {
        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await PromotionDAO.Instance.GetAllPromotions();
        }

        public async Task AddNewPromotion(Promotion promotion)
        {
            await PromotionDAO.Instance.AddNewPromotion(promotion);
        }

        public async Task<Promotion> UpdatePromotion(Promotion promotion)
        {
            return await PromotionDAO.Instance.UpdatePromotion(promotion);
        }

        public async Task<bool> DeletePromotion(int promotionId)
        {
            return await PromotionDAO.Instance.DeletePromotion(promotionId);
        }

        public async Task<Promotion> GetPromotionById(int promotionId)
        {
            return await PromotionDAO.Instance.GetPromotionById(promotionId);
        }
        public async Task AddRange(IEnumerable<Promotion> promotions)
        {
            await PromotionDAO.Instance.AddRange(promotions);

        }
    }
}
