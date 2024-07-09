using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class JeweleryRepository : IJeweleryRepository
    {
        public async Task<List<JeweleryEntity>> GetAll()
        {
            return await JeweleryDAO.Instance.GetAllJewelery();
        }

        public async Task<JeweleryEntity> GetById(int jeweleryId)
        {
            return await JeweleryDAO.Instance.GetById(jeweleryId);
        }

        public async Task Add(JeweleryEntity jewelery)
        {
            await JeweleryDAO.Instance.Add(jewelery);
        }

        public async Task AddRange(List<JeweleryEntity> jewelery)
        {
            await JeweleryDAO.Instance.AddRange(jewelery);
        }

        public async Task<int> Update(JeweleryEntity jewelery)
        {
            return await JeweleryDAO.Instance.Update(jewelery); // Ensure it accepts JeweleryEntity
        }

        public async Task<int> Delete(int jeweleryId)
        {
            return await JeweleryDAO.Instance.Delete(jeweleryId);
        }
    }
}
