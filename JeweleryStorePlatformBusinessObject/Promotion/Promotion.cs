using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Promotion;

[Table("Promotions")]
public class Promotion : BaseEntity
{
    public string PromotionName { get; set; }
    public string PromotionContent { get; set; }
    public int Amount { get; set; }
    public int Percentage { get; set; }
}