using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery
{
    [Table("Jeweleries")]
    public class JeweleryEntity : BaseEntity
    {
        public string JeweleryName { get; set; }

        // Foreign key property
        public int TypeId { get; set; }

        // Navigation property to JeweleryTypeEntity
        [ForeignKey("TypeId")]
        public virtual JeweleryTypeEntity? JeweleryTypeEntity { get; set; }
    }
}
