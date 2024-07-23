using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request.JewelerysDTO
{
    public class JeweleryCaseDTO
    {
        public string CaseName { get; set; }

        public int ColorId { get; set; }

        public int MaterialId { get; set; }
    }
}
