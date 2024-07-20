using JeweleryStorePlatformBusinessObject.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class AddressDAO
    {
        private readonly AppDbContext _context;
        private static AddressDAO instance;

        public AddressDAO()
        {
            _context = new AppDbContext();
        }

        public static AddressDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddressDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<Address> addresses)
        {
            await _context.Addresses.AddRangeAsync(addresses);
            await _context.SaveChangesAsync();
        }
    }
}
