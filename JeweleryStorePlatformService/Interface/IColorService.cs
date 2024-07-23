using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IColorService
    {
        Task AddRange(List<Color> colors);
        Task<List<Color>> GetAllColors();
    }
}
