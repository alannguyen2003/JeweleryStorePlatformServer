using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class CityRepository : ICityRepository
    {
        public async Task AddRange(IEnumerable<City> city)
        {
            await CityDAO.Instance.AddRange(city);
        }
        public async Task<List<City>> GetAllCities()
        {
            return await CityDAO.Instance.GetAllCities();
        }
    }
}
