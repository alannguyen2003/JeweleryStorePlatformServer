using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformBusinessObject.Jewelery
{
    public class JeweleryCreateRequest
    {
        public string JeweleryName { get; set; }

        public int TypeId { get; set; }

        public JeweleryTypeEntity JeweleryTypeEntity { get; set; }
    }
}
