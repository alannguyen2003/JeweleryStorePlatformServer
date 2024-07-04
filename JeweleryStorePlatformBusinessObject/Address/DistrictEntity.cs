using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Districts")]
public class DistrictEntity : BaseEntity
{
    public string DistrictName { get; set; }
    [ForeignKey("CityId")]
    public int CityId { get; set; }
    public virtual CityEntity CityEntity { get; set; }
}