using AutoMapper;
using JeweleryStorePlatformBusinessObject.Diamond;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.DTOs
{
    public class GIAReportDTO : IMapFrom<GIAReport>
    {
        public int Id { get; set; }
        public string ReportNumber { get; set; }
        public string ReportUrl { get; set; }
        [ForeignKey("DiamondId")]
        public int DiamondId { get; set; }
        public virtual Diamond Diamond { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GIAReport, GIAReportDTO>();
        }
    }
}
