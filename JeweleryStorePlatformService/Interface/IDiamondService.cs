using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataTransfer.Request.Diamond;
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
        Task<PaginatedList<GIAReportDTO>> GetAllDiamondswithGIAReport(GetDiamondsRequest request);
        Task<PaginatedList<DiamondDTO>> GetAllDiamonds(GetDiamondsRequest request);
        Task<DiamondDTO> GetDiamondById(int id);
        Task<DiamondDTO> CreateDiamond(CreateDiamondRequest request);
        Task<DiamondDTO> UpdateDiamond(int id, UpdateDiamondRequest request);
        Task<bool> DeleteDiamond(int id);
        Task AddRangeDiamonds(List<Diamond> diamonds);
    }
}
