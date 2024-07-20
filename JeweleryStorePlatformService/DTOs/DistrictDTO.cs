using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.DTOs
{
    public class DistrictDTO
    {
        public int district_id { get; set; }
        public string district_name { get; set; }
    }
}
