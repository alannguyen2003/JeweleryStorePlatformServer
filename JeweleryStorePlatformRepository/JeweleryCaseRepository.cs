using JeweleryStorePlatformBusinessObject.Address;
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
    public class JeweleryCaseRepository : IJeweleryCaseRepository
    {
        public async Task<List<JeweleryCase>> GetAll()
        {
            return await JeweleryCaseDAO.Instance.GetAll();
        }

        public async Task<JeweleryCase?> GetById(int jeweleryId)
        {
            return await JeweleryCaseDAO.Instance.GetById(jeweleryId);
        }

        public async Task Add(JeweleryCase jewelery)
        {
            await JeweleryCaseDAO.Instance.Add(jewelery);
        }

        public async Task AddRange(List<JeweleryCase> jewelery)
        {
            await JeweleryCaseDAO.Instance.AddRange(jewelery);
        }

        public async Task<int> Update(JeweleryCase jewelery)
        {
            return await JeweleryCaseDAO.Instance.Update(jewelery); // Ensure it accepts JeweleryEntity
        }

        public async Task<int> Delete(int jeweleryId)
        {
            return await JeweleryCaseDAO.Instance.Delete(jeweleryId);
        }
        public async Task AddRange(IEnumerable<JeweleryCase> jeweleryCases)
        {
            await JeweleryCaseDAO.Instance.AddRange(jeweleryCases);
        }
    }
}
