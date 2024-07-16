using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformService.DTOs;
using Service.Models.Payload.Requests.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IDiamondService
    {
        Task<PaginatedList<DiamondDTO>> GetAllDiamonds(GetDiamondsRequest request);
    }
}
