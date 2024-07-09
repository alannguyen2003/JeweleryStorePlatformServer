using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Addresses")]
public class Address : BaseEntity
{
    public string AddressString { get; set; }
    [ForeignKey("DistrictId")]
    public int DistrictId { get; set; }
    public virtual District District { get; set; }
}