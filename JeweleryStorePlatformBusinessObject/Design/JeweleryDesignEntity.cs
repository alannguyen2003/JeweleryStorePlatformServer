using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Design;

[Table("JeweleryDesigns")]
public class JeweleryDesignEntity : BaseEntity
{
    public string DesignDescription { get; set; }
}