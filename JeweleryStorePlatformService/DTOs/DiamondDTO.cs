using AutoMapper;
using JeweleryStorePlatformBusinessObject.Diamond;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.DTOs
{
    public class DiamondDTO : IMapFrom<DiamondEntity>
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string CutType { get; set; }
        public string CaratType { get; set; }
        public string ColorType { get; set; }
        public string ClarityType { get; set; }
        public string DiamondOrigin { get; set; }

        public string PreviewImage { get; set; }
        public bool IsMainDiamond { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DiamondEntity, DiamondDTO>();
        }
    }

}
