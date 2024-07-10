using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Materials")]
public class Material : BaseEntity
{
    public string MaterialDescription { get; set; }
}