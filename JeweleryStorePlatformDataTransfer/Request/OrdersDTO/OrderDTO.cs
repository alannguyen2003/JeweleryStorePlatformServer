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
        public int Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishedTime { get; set; }
        public int AccountId { get; set; }
        public string PromotionCode { get; set; }
    }
}
