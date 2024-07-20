using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Diamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface ICityRepository
    {
        Task AddRange(IEnumerable<City> city);
    }
}
