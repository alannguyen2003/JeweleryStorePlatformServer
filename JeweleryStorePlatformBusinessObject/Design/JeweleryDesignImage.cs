using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Design;

[Table("JeweleryDesignImages")]
public class JeweleryDesignImage : BaseEntity 
{
    public string ImageUrl { get; set; }
    public string ImageDescription { get; set; }
    [ForeignKey("JeweleryDesignId")]
    public int JeweleryDesignId { get; set; }
    public virtual JeweleryDesign JeweleryDesign { get; set; }
}