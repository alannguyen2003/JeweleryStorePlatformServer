using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class JeweleryTypeRepository : IJeweleryTypeRepository
    {
        public IQueryable<JeweleryType> GetAllJeweleryTypes()
        {
            return JeweleryTypeDAO.Instance.GetAllJeweleryTypes();
        }

        public async Task<JeweleryType> GetJeweleryTypeById(int id)
        {
            return await JeweleryTypeDAO.Instance.GetJeweleryTypeById(id);
        }

        public async Task<JeweleryType> CreateJeweleryType(JeweleryType jeweleryType)
        {
            return await JeweleryTypeDAO.Instance.CreateJeweleryType(jeweleryType);
        }

        public async Task<JeweleryType> UpdateJeweleryType(JeweleryType jeweleryType)
        {
            return await JeweleryTypeDAO.Instance.UpdateJeweleryType(jeweleryType);
        }

        public async Task<bool> DeleteJeweleryType(int id)
        {
            return await JeweleryTypeDAO.Instance.DeleteJeweleryType(id);
        }

        public async Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes)
        {
            await JeweleryTypeDAO.Instance.AddRangeJeweleryTypes(jeweleryTypes);
        }
    }
}
