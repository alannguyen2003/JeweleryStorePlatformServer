using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryCaseRepository
    {
        Task<List<JeweleryCase>> GetAll();
        Task<JeweleryCase> GetById(int jeweleryId);
        Task Add(JeweleryCase jewelery);
        Task AddRange(List<JeweleryCase> jewelery);
        Task<int> Update(JeweleryCase jewelery);
        Task<int> Delete(int jeweleryId);
        Task AddRange(IEnumerable<JeweleryCase> jeweleryCases);
    }
}
