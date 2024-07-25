using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IPaymentMethodRepository
    {
        Task AddRange(IEnumerable<PaymentMethod> paymentMethods);
        Task<List<PaymentMethod>> GetAllPaymentMethods();
        Task<PaymentMethod> GetPaymentMethodById(int id);
    }
}
