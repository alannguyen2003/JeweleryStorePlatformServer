using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryTypeService
    {
        Task<PaginatedList<JeweleryTypeDTO>> GetAllJeweleryTypes(GetJeweleryTypesRequest request);
        Task<JeweleryTypeDTO> GetJeweleryTypeById(int id);
        Task<JeweleryTypeDTO> CreateJeweleryType(JeweleryType jeweleryType);
        Task<JeweleryTypeDTO> UpdateJeweleryType(int id, JeweleryTypeUpdateRequest request);
        Task<bool> DeleteJeweleryType(int id);
        Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes);
    }
}
