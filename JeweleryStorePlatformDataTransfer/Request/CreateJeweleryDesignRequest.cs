using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request
{
    public class CreateJeweleryDesignRequest
    {
        [Required]
        public string DesignDescription { get; set; }
        public List<string> ImageUrl { get; set; }
        public string ImageDescription { get; set; }
    }
}
