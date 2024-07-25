using JeweleryStorePlatformBusinessObject.Diamond;
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
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            return await TransactionDAO.Instance.CreateTransaction(transaction);
        }
    }
}
