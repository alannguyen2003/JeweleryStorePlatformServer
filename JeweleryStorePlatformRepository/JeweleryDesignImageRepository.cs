using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class JeweleryDesignImageRepository : IJeweleryDesignImageRepository
{

    public async Task<JeweleryDesignImage> AddNewJeweleryDesignImage(JeweleryDesignImage jeweleryDesignimg)
    {
        await JeweleryDesignImageDAO.Instance.AddNewJeweleryDesignImage(jeweleryDesignimg);
        return jeweleryDesignimg;
    }


}