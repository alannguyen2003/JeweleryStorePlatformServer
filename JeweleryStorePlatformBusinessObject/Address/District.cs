using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Address;

[Table("Districts")]
public class District
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string DistrictName { get; set; }
    [ForeignKey("CityId")]
    public int CityId { get; set; }
    public virtual City City { get; set; }
}