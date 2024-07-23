using JeweleryStorePlatformBusinessObject.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IProvinceService
    {
        Task FetchAndStoreDataAsync();
        Task<List<City>> GetAllCities();
        Task<List<District>> GetAllDistricts();
        Task<List<Address>> GetAllAddresses();
    }
}
