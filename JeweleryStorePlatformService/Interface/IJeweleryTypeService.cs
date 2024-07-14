using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryTypeService
    {
        Task<List<JeweleryType>> GetAllJeweleryType();
        Task<JeweleryType> GetJeweleryTypeById(int id);
        Task<int> AddNewJeweleryType(JeweleryType jeweleryType);
        Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes);
        Task UpdateJeweleryType(JeweleryType jeweleryType);
        Task DeleteJeweleryType(int id);
    }
}
