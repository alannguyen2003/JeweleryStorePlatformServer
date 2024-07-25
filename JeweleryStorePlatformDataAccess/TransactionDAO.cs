using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class TransactionDAO
    {
        private readonly AppDbContext _context;
        private static TransactionDAO instance;

        public TransactionDAO()
        {
            _context = new AppDbContext();
        }

        public static TransactionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransactionDAO();
                }
                return instance;
            }
        }
        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            _context.ChangeTracker.Clear();
            _context.Set<Transaction>().Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
