using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Districts")]
public class District : BaseEntity
{
    public string DistrictName { get; set; }
    [ForeignKey("CityId")]
    public int CityId { get; set; }
    public virtual City City { get; set; }
}