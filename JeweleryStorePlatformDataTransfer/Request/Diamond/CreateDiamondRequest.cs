using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Request.Diamond
{
    public class CreateDiamondRequest
    {
        [Required]
        public int Price { get; set; }
        [Required]
        public string CutType { get; set; }

        [Required]
        public float CaratType { get; set; }

        [Required]
        public string ColorType { get; set; }

        [Required]
        public string ClarityType { get; set; }

        [Required]
        public string DiamondOrigin { get; set; }

        public string PreviewImage { get; set; }
        public string ReportNumber { get; set; }
        public string ReportUrl { get; set; }

    }
}
