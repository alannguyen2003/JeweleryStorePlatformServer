using AutoMapper;
using JeweleryStorePlatformBusinessObject.Jewelery;
using Service.Common.Mapping;

namespace JeweleryStorePlatformService.DTOs
{
    public class JeweleryTypeDTO : IMapFrom<JeweleryType>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JeweleryType, JeweleryTypeDTO>();
        }
    }
}
