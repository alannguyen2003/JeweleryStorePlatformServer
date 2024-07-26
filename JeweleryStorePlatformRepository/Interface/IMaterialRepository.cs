using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IMaterialRepository
    {
        Task AddRange(IEnumerable<Material> materials);
        Task<List<Material>> GetAllMaterials();
        Task<Material?> GetById(int material);
    }
}
