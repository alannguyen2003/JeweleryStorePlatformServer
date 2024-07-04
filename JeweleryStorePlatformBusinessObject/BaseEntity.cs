using System.ComponentModel.DataAnnotations;

namespace JeweleryStorePlatformBusinessObject;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}