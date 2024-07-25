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
        public async Task<List<District>> GetAllDistricts()
        {
            return await DistrictDAO.Instance.GetAllDistricts();
        }

        public async Task<List<District>> GetAllDistrictsByProvinceId(int provinceId)
        {
            return await DistrictDAO.Instance.GetAllDistrictsByProvinceId(provinceId);
        }
    }
}
