using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryPreviewImages")]
public class JeweleryPreviewImage : BaseEntity
{
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    [ForeignKey("JeweleryId")]
    public int JeweleryId { get; set; }
    public virtual Jewelery Jewelery { get; set; }
    
}