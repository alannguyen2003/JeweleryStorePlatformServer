using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Jeweleries")]
public class Jewelery : BaseEntity
{
    //public int Id { get; set; }
    public string JeweleryName { get; set; }

    [ForeignKey("JeweleryTypeId")]
    public int JeweleryTypeId { get; set; }
    public virtual JeweleryType? JeweleryType { get; set; }
}