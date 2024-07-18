using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.DTOs
{
    public class PromotionDTO
    {
        public string PromotionName { get; set; }
        public string PromotionContent { get; set; }
        public int Amount { get; set; }
        public int Percentage { get; set; }
    }
}
