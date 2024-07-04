using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryTypes")]
public class JeweleryTypeEntity : BaseEntity
{
    public string TypeName { get; set; }
}