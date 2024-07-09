using System.ComponentModel.DataAnnotations.Schema;

namespace JeweleryStorePlatformBusinessObject.Jewelery
{
    [Table("Jeweleries")]
    public class JeweleryEntity : BaseEntity
    {
        public string JeweleryName { get; set; }

        // Foreign key property
        [ForeignKey("TypeId")]
        public int TypeId { get; set; }

        // Navigation property to JeweleryTypeEntity
        //public virtual JeweleryTypeEntity? JeweleryTypeEntity { get; set; }
    }
}
