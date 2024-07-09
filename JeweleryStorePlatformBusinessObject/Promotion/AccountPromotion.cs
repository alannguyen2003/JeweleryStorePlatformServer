using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Account;
namespace JeweleryStorePlatformBusinessObject.Promotion;

public class AccountPromotion
{
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account.Account Account { get; set; }
    
    [ForeignKey("PromotionId")]
    public int PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; }
    
    public string PromotionCode { get; set; }
    public DateTime ExpiredDate { get; set; }
}