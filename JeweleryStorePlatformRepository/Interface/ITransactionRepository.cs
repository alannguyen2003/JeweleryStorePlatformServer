using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JeweleryStorePlatformRepository.Interface
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransaction(Transaction transaction);
        public Task<Transaction?> GetLatestTransactionOfUser(int userId, int orderId);
    }
}
