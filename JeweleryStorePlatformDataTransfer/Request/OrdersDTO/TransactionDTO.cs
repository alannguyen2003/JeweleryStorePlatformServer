using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.DTOs
{
    public class TransactionDTO
    {
        public int Amount { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
