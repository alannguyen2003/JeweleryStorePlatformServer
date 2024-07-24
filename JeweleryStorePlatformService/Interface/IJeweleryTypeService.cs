using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformService.DTOs;
using Service.Models.Payload.Requests.Member;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryTypeService
    {
        Task<PaginatedList<JeweleryTypeDTO>> GetAllJeweleryTypes(GetJeweleryTypesRequest request);
        Task<JeweleryType> GetJeweleryTypeById(int id);
        Task<int> AddNewJeweleryType(JeweleryType jeweleryType);
        Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes);
        Task UpdateJeweleryType(JeweleryType jeweleryType);
        Task DeleteJeweleryType(int id);
    }
}
