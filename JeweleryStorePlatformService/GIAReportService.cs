using AutoMapper;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class GIAReportService : IGIAReportService
    {
        private readonly IGIAReportRepository _gIAReportRepository;
        private readonly IMapper _mapper;
        public GIAReportService( IMapper mapper, IGIAReportRepository gIAReportRepository)
        {
            _mapper = mapper;
            _gIAReportRepository = gIAReportRepository;
        }
        public async Task AddRangeGIAReports(List<GIAReport> gIAReports)
        {
            await _gIAReportRepository.AddRangeGIAReports(gIAReports);
        }
    }
}
