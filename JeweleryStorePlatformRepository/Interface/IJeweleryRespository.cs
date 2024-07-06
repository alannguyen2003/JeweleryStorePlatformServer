using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryRepository
    {
        Task<List<JeweleryEntity>> GetAll();
        Task<JeweleryEntity> GetById(int jewelryId);
        Task Add(JeweleryEntity jewelry);
        Task AddRange(List<JeweleryEntity> jewelry);
        Task Update(JeweleryEntity jewelry);
        Task Delete(int jewelryId);
    }
}
