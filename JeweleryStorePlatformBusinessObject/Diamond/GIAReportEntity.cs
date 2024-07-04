using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Diamond;

[Table("GIAReports")]
public class GIAReportEntity : BaseEntity
{
    public string ReportNumber { get; set; }
    public string ReportUrl { get; set; }
    [ForeignKey("DiamondId")]
    public int DiamondId { get; set; }
    public virtual DiamondEntity DiamondEntity { get; set; }
}