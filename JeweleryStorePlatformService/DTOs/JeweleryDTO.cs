using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformService.DTOs
{
    public class JeweleryDTO
    {
        public int Id { get; set; }
        public string JeweleryName { get; set; }
        public int TypeId { get; set; }
        public virtual JeweleryType JeweleryType { get; set; }
    }
}
