using JeweleryStorePlatformBusinessObject.Transaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class PaymentMethodDAO
    {
        private readonly AppDbContext _context;
        private static PaymentMethodDAO instance;

        public PaymentMethodDAO()
        {
            _context = new AppDbContext();
        }

        public static PaymentMethodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentMethodDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<PaymentMethod> PaymentMethodes)
        {
            await _context.PaymentMethods.AddRangeAsync(PaymentMethodes);
            await _context.SaveChangesAsync();
        }
        public async Task<List<PaymentMethod>> GetAllPaymentMethodes()
        {
            return await _context.PaymentMethods.ToListAsync();
        }
        public async Task<PaymentMethod> GetPaymentMethodById(int id)
        {
            return await _context.Set<PaymentMethod>().FindAsync(id);

        }
    }
}
