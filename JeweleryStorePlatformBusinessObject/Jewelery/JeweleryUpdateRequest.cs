using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformBusinessObject.Jewelery
{
    public class JeweleryUpdateRequest
    {
        public int Id { get; set; }

        public string JeweleryName { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }

        //public virtual JeweleryTypeEntity JeweleryTypeEntity { get; set; }
    }
}
