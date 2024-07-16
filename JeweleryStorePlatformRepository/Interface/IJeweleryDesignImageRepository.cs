
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IJeweleryDesignImageRepository
    {
        public Task<JeweleryDesignImage> AddNewJeweleryDesignImage(JeweleryDesignImage jeweleryDesignimg);
    }
}
