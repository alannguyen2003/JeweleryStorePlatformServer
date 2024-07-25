using System.ComponentModel.DataAnnotations.Schema;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformBusinessObject.Order;

[Table("OrderItems")]
public class OrderItem : BaseEntity
{   
    [ForeignKey("JeweleryCaseId")]
    public int JeweleryCaseId { get; set; }
    public virtual JeweleryCase JeweleryCase { get; set; }
    
    [ForeignKey("JeweleryId")]
    public int JeweleryId { get; set; }
    public virtual Jewelery.Jewelery Jewelery { get; set; }

    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    
    [ForeignKey("DiamondId")]
    public int DiamondId { get; set; }
    public virtual Diamond.Diamond Diamond { get; set; }
    
    [ForeignKey("JeweleryDesignId")]
    public int JeweleryDesignId { get; set; }
    public virtual JeweleryDesign JeweleryDesign { get; set; }
    
    public int DesignFee { get; set; }
    public int Size { get; set; }
}