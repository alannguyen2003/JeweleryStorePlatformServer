using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Order;

namespace JeweleryStorePlatformBusinessObject.Transaction;

[Table("Transactions")]
public class Transaction : BaseEntity
{
    public int TransactionStatus { get; set; }
    public int Amount { get; set; }
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public virtual Order.Order Order { get; set; }
    
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account.Account Account { get; set; }
    
    [ForeignKey("PaymentMethodId")]
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
}