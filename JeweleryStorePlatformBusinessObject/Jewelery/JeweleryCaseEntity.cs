using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryCases")]
public class JeweleryCaseEntity : BaseEntity
{
    public string CaseName { get; set; }
    
    [ForeignKey("ColorId")]
    public int ColorId { get; set; }
    public virtual ColorEntity ColorEntity { get; set; }

    [ForeignKey("MaterialId")] 
    public int MaterialId { get; set; }
    public virtual MaterialEntity MaterialEntity { get; set; }
}