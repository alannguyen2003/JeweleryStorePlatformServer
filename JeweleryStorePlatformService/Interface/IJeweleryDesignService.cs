using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request;

namespace JeweleryStorePlatformService.Interface;

public interface IJeweleryDesignService
{
    public Task<List<JeweleryDesign>> GetAllJeweleryDesign();
    public Task<JeweleryDesign> AddNewJeweleryDesign(CreateJeweleryDesignRequest jeweleryDesign);
}