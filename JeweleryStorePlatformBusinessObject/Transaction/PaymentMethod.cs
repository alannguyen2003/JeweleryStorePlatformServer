using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Transaction;

[Table("PaymentMethods")]
public class PaymentMethod : BaseEntity
{
    public string PaymentMethodName { get; set; }
}