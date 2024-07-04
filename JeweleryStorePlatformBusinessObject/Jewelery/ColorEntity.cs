using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Colors")]
public class ColorEntity : BaseEntity
{
    public string ColorDescription { get; set; }
}