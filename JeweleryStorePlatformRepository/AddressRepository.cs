using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class AddressRepository : IAddressRepository
    {
        public async Task AddRange(IEnumerable<Address> address)
        {
            await AddressDAO.Instance.AddRange(address);

        }
        public async Task<List<Address>> GetAllAddresses()
        {
            return await AddressDAO.Instance.GetAllAddresses();
        }
        public async Task<Address> GetAddressById(int id)
        {
            return await AddressDAO.Instance.GetAddressById(id);
        }

        public async Task<int> AddNewAddress(Address address)
        {
            return await AddressDAO.Instance.AddNewAddress(address);
        }
    }
}
