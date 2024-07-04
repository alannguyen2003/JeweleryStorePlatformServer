using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("JeweleryPreviewImages")]
public class JeweleryPreviewImageEntity : BaseEntity
{
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    [ForeignKey("JeweleryId")]
    public int JeweleryId { get; set; }
    public virtual JeweleryEntity JeweleryEntity { get; set; }
    
}