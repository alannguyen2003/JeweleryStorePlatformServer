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
    public class ColorRepository : IColorRepository
    {
        public async Task AddRange(IEnumerable<Color> colors)
        {
            await ColorDAO.Instance.AddRange(colors);
        }
        public async Task<List<Color>> GetAllColors()
        {
            return await ColorDAO.Instance.GetAllColors();
        }
        public async Task<Color?> GetById(int color)
        {
            return await ColorDAO.Instance.GetById(color);
        }
    }
}
