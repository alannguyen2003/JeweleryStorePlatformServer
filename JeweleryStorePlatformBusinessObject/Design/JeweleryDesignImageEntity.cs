using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Design;

[Table("JeweleryDesignImages")]
public class JeweleryDesignImageEntity : BaseEntity 
{
    public string ImageUrl { get; set; }
    public string ImageDescription { get; set; }
    [ForeignKey("DesignId")]
    public int DesignId { get; set; }
    public virtual JeweleryDesignEntity JeweleryDesignEntity { get; set; }
}