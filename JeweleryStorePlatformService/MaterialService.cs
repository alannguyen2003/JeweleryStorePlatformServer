using AutoMapper;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<List<Material>> GetAllMaterials()
        {
            return await _materialRepository.GetAllMaterials();
        }
        public async Task AddRange(List<Material> materials)
        {
            await _materialRepository.AddRange(materials);
        }
    }
}
