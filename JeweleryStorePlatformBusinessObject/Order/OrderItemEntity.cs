using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformBusinessObject.Order;

[Table("OrderItems")]
public class OrderItemEntity : BaseEntity
{   
    [ForeignKey("JeweleryCaseId")]
    public int JeweleryCaseId { get; set; }
    public virtual JeweleryCaseEntity JeweleryCaseEntity { get; set; }
    
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public virtual OrderEntity OrderEntity { get; set; }
    
}