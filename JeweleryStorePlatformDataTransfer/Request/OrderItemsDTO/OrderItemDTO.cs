using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO
{
    public class OrderItemDTO
    {
        public int JeweleryCaseId { get; set; }
        public int JeweleryId { get; set; }
        public int OrderId { get; set; }
        public int DiamondId { get; set; }
        public int JeweleryDesignId { get; set; }
        public int DesignFee { get; set; }
    }
}
