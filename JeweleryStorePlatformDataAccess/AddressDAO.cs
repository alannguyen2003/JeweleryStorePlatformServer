using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddNewAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address.Id;
        }
        public async Task AddRange(IEnumerable<Address> addresses)
        {
            await _context.Addresses.AddRangeAsync(addresses);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Address>> GetAllAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }
        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Set<Address>().FindAsync(id);

        }
    }
}
