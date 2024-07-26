using JeweleryStorePlatformBusinessObject.Jewelery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryRepository
    {
        Task<List<Jewelery>> GetAll();
        Task<Jewelery> GetById(int jeweleryId);
        Task Add(Jewelery jewelery);
        Task AddRange(List<Jewelery> jewelery);
        Task<int> Update(Jewelery jewelery);
        Task<int> Delete(int jeweleryId);
        Task<JeweleryType> GetJeweleryTypeById(int typeId);
    }
}
