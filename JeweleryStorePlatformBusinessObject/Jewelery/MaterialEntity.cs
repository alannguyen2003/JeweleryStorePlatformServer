using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Materials")]
public class MaterialEntity : BaseEntity
{
    public string MaterialDescription { get; set; }
}