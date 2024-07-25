using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryTypeRepository
    {
        IQueryable<JeweleryType> GetAllJeweleryTypes();
        Task<JeweleryType> GetJeweleryTypeById(int id);
        Task<JeweleryType> CreateJeweleryType(JeweleryType jeweleryType);
        Task<JeweleryType> UpdateJeweleryType(JeweleryType jeweleryType);
        Task<bool> DeleteJeweleryType(int id);
        Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes);
    }
}
