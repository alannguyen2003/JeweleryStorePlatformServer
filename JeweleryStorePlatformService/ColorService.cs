using AutoMapper;
using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        public ColorService( IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<List<Color>> GetAllColors()
        {
            return await _colorRepository.GetAllColors();
        }
        public async Task AddRange(List<Color> colors)
        {
            await _colorRepository.AddRange(colors);
        }
    }
}
