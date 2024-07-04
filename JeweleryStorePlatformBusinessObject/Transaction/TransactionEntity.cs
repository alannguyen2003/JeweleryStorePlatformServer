using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Order;

namespace JeweleryStorePlatformBusinessObject.Transaction;

[Table("Transactions")]
public class TransactionEntity : BaseEntity
{
    public int TransactionStatus { get; set; }
    public int Amount { get; set; }
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public virtual OrderEntity OrderEntity { get; set; }
    
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual AccountEntity AccountEntity { get; set; }
}