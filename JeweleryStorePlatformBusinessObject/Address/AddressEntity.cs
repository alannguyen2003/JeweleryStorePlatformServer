using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Addresses")]
public class AddressEntity : BaseEntity
{
    public string Address { get; set; }
    [ForeignKey("DistrictId")]
    public int DistrictId { get; set; }
    public virtual DistrictEntity DistrictEntity { get; set; }
}