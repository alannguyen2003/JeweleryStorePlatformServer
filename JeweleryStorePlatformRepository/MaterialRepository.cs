using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class MaterialRepository : IMaterialRepository
    {
        public async Task AddRange(IEnumerable<Material> materials)
        {
            await MaterialDAO.Instance.AddRange(materials);
        }
        public async Task<List<Material>> GetAllMaterials()
        {
            return await MaterialDAO.Instance.GetAllMaterials();
        }
        public async Task<Material?> GetById(int material)
        {
            return await MaterialDAO.Instance.GetById(material);
        }
    }
}
