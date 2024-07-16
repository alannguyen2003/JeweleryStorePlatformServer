
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryDesignRepository
    {
        public Task<List<JeweleryDesign>> GetAllJeweleryDesign();
        public Task<JeweleryDesign> AddNewJeweleryDesign(JeweleryDesign jeweleryDesign);
    }
}
