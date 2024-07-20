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
    public class DistrictRepository : IDistrictRepository
    {
        public async Task AddRange(IEnumerable<District> district)
        {
            await DistrictDAO.Instance.AddRange(district);
        }
    }
}
