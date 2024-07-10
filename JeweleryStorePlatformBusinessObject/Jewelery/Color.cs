using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Colors")]
public class Color : BaseEntity
{
    public string ColorDescription { get; set; }
}