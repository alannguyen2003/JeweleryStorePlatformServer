using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IColorRepository
    {
        Task AddRange(IEnumerable<Color> colors);
        Task<List<Color>> GetAllColors();
    }
}
