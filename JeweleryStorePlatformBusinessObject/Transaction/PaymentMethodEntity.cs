using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Transaction;

[Table("PaymentMethods")]
public class PaymentMethodEntity : BaseEntity
{
    public string PaymentMethodName { get; set; }
}