using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Jeweleries")]
public class JeweleryEntity : BaseEntity
{
    public string JeweleryName { get; set; }
    [ForeignKey("TypeId")]
    public int TypeId { get; set; }
    public virtual JeweleryTypeEntity JeweleryTypeEntity { get; set; }
}