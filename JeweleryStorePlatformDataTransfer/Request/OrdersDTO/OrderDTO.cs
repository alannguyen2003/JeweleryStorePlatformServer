using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request.OrdersDTO
{
    public class OrderDTO
    {
        public int Price { get; set; }
        public int AddressId { get; set; }
        //public DateTime FinishedTime { get; set; }
        public string PromotionCode { get; set; }
        public int Amount { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
