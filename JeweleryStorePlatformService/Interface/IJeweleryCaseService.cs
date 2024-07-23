using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request.JewelerysDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryCaseService
    {
        Task<List<JeweleryCase>> GetAll();
        Task<JeweleryCase> GetById(int jeweleryId);
        Task<int> Create(JeweleryCaseDTO request);
        Task<int> Delete(int jeweleryId);
        Task<int> Update(JeweleryCaseUpdateDTO request);

    }
}
