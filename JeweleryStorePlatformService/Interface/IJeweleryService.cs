using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryService
    {
        Task<List<Jewelery>> GetAll();
        Task<Jewelery> GetById(int jeweleryId);
        Task<int> Create(JeweleryCreateRequest request);
        Task<int> Update(JeweleryUpdateRequest jewelery);
        Task<int> Delete(int jeweleryId);
    }
}
