using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformBusinessObject.Promotion;

public class AccountPromotionEntity
{
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual AccountEntity AccountEntity { get; set; }
    
    [ForeignKey("PromotionId")]
    public int PromotionId { get; set; }
    public virtual PromotionEntity PromotionEntity { get; set; }
    
    public string PromotionCode { get; set; }
    public DateTime ExpiredDate { get; set; }
}