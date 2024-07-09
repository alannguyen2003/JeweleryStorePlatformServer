using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Design;

[Table("JeweleryDesigns")]
public class JeweleryDesign : BaseEntity
{
    public string DesignDescription { get; set; }
}