using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request.JewelerysDTO
{
    public class JeweleryCaseUpdateDTO
    {
        public int Id { get; set; }
        public string CaseName { get; set; }

        public int ColorId { get; set; }

        public int MaterialId { get; set; }
    }
}
