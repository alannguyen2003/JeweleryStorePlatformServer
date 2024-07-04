using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Diamond;

[Table("Diamonds")]
public class DiamondEntity : BaseEntity
{
    public int Price { get; set; }
    public string CutType { get; set; }
    public string CaratType { get; set; }
    public string ColorType { get; set; }
    public string ClarityType { get; set; }
    public string DiamondOrigin { get; set; }
    
    public string PreviewImage { get; set; }
    public bool IsMainDiamond { get; set; }
}