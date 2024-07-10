using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryCases")]
public class JeweleryCase : BaseEntity
{
    public string CaseName { get; set; }
    
    [ForeignKey("ColorId")]
    public int ColorId { get; set; }
    public virtual Color Color { get; set; }

    [ForeignKey("MaterialId")] 
    public int MaterialId { get; set; }
    public virtual Material Material { get; set; }
}