using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;

namespace JeweleryStorePlatformDataTransfer.Request.OrdersDTO
{
    public class OrderDTO
    {
        public int DistrictId { get; set; }
        public string Address { get; set; }
        //public DateTime FinishedTime { get; set; }
        public string PromotionCode { get; set; }
        public int Price { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }
}
