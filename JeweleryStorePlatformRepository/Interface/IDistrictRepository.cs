using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IDistrictRepository
    {
        Task AddRange(IEnumerable<District> district);
        Task<List<District>> GetAllDistricts();
    }
}
