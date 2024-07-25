using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await _promotionRepository.GetAllPromotions();
        }

        public async Task AddNewPromotion(Promotion promotion)
        {
            await _promotionRepository.AddNewPromotion(promotion);
        }

        public async Task<Promotion> UpdatePromotion(Promotion promotion)
        {
            return await _promotionRepository.UpdatePromotion(promotion);
        }

        public async Task<bool> DeletePromotion(int promotionId)
        {
            return await _promotionRepository.DeletePromotion(promotionId);
        }

        public async Task<Promotion> GetPromotionById(int promotionId)
        {
            return await _promotionRepository.GetPromotionById(promotionId);
        }
        public async Task AddRange(List<Promotion> promotions)
        {
            await _promotionRepository.AddRange(promotions);
        }
    }
}
