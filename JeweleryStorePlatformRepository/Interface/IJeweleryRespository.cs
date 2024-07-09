using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryRepository
    {
        Task<List<JeweleryEntity>> GetAll();
        Task<JeweleryEntity> GetById(int jeweleryId);
        Task Add(JeweleryEntity jewelery);
        Task AddRange(List<JeweleryEntity> jewelery);
        Task<int> Update(JeweleryEntity jewelery);
        Task<int> Delete(int jeweleryId);
    }
}
