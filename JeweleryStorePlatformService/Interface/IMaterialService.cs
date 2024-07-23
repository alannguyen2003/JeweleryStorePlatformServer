using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IMaterialService
    {
        Task AddRange(List<Material> materials);
        Task<List<Material>> GetAllMaterials();
    }
}
