using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryTypes")]
public class JeweleryType : BaseEntity
{
    public string TypeName { get; set; }
}