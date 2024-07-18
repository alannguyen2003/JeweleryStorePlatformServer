using JeweleryStorePlatformBusinessObject.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAllPromotions();
        Task AddNewPromotion(Promotion promotion);
        Task<Promotion> UpdatePromotion(Promotion promotion);
        Task<bool> DeletePromotion(int promotionId);
        Task<Promotion> GetPromotionById(int promotionId);
    }
}