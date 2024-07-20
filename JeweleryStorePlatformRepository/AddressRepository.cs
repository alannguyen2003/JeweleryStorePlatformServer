using JeweleryStorePlatformBusinessObject.Address;
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
    }
}
