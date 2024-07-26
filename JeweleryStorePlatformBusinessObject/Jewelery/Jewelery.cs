using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeweleryStorePlatformBusinessObject.Jewelery;

[Table("Jeweleries")]
public class Jewelery : BaseEntity
{
    //public int Id { get; set; }
    public string JeweleryName { get; set; }

    [ForeignKey("JeweleryTypeId")]
    public int JeweleryTypeId { get; set; }
    [JsonIgnore]
    public virtual JeweleryType? JeweleryType { get; set; }
}