using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class JeweleryRepository : IJeweleryRepository
    {
        private readonly JeweleryDAO _jeweleryDAO;

        public async Task<List<Jewelery>> GetAll()
        {
            return await _jeweleryDAO.GetAllJewelery();
        }

        public async Task<Jewelery> GetById(int jeweleryId)
        {
            return await _jeweleryDAO.GetById(jeweleryId);
        }

        public async Task Add(Jewelery jewelery)
        {
            await _jeweleryDAO.Add(jewelery);
        }

        public async Task AddRange(List<Jewelery> jewelery)
        {
            await _jeweleryDAO.AddRange(jewelery);
        }

        public async Task<int> Update(Jewelery jewelery)
        {
            return await _jeweleryDAO.Update(jewelery);
        }

        public async Task<int> Delete(int jeweleryId)
        {
            return await _jeweleryDAO.Delete(jeweleryId);
        }

        public async Task<JeweleryType> GetJeweleryTypeById(int typeId)
        {
            return await _jeweleryDAO.GetJeweleryTypeById(typeId);
        }
    }
}
