using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryTypeRepository
    {
        IQueryable<JeweleryType> GetAllJeweleryTypes();
        Task<JeweleryType> GetJeweleryTypeByIdAsync(int id);
        Task AddNewJeweleryTypeAsync(JeweleryType jeweleryType);
        Task AddRangeJeweleryTypesAsync(List<JeweleryType> jeweleryTypes);
        Task UpdateJeweleryTypeAsync(JeweleryType jeweleryType);
        Task DeleteJeweleryTypeAsync(int id);
    }
}
