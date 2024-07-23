using JeweleryStorePlatformBusinessObject.Diamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IGIAReportService
    {
        Task AddRangeGIAReports(List<GIAReport> gIAReports);
    }
}
