using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Address;

namespace JeweleryStorePlatformBusinessObject.Order;

[Table("Orders")]
public class OrderEntity : BaseEntity
{
    public int Price { get; set; }
    [ForeignKey("AddressId")] 
    public int AddressId { get; set; }
    public virtual AddressEntity AddressEntity { get; set; }
    public int Status { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime FinishedTime { get; set; }
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual AccountEntity AccountEntity { get; set; }
    
}