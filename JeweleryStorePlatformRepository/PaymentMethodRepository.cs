using JeweleryStorePlatformBusinessObject.Transaction;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        public async Task AddRange(IEnumerable<PaymentMethod> PaymentMethod)
        {
            await PaymentMethodDAO.Instance.AddRange(PaymentMethod);

        }
        public async Task<List<PaymentMethod>> GetAllPaymentMethods()
        {
            return await PaymentMethodDAO.Instance.GetAllPaymentMethodes();
        }
        public async Task<PaymentMethod> GetPaymentMethodById(int id)
        {
            return await PaymentMethodDAO.Instance.GetPaymentMethodById(id);
        }
    }
}
