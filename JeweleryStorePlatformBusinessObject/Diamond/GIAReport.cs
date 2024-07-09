using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Diamond;

[Table("GIAReports")]
public class GIAReport : BaseEntity
{
    public string ReportNumber { get; set; }
    public string ReportUrl { get; set; }
    [ForeignKey("DiamondId")]
    public int DiamondId { get; set; }
    public virtual Diamond Diamond { get; set; }
}