using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Cities")]
public class City : BaseEntity
{
    [Required]
    public string CityName { get; set; }
}