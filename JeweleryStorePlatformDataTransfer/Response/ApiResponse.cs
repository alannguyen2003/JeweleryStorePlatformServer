using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataTransfer.Response
{
    public class ApiResponse<T>
    {
        public T Results { get; set; }
    }
}
