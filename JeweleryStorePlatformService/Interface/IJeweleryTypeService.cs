using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformService.Interface;

public interface IJeweleryTypeService
{
    public Task<List<JeweleryType>> GetAllJeweleryType();
    public Task AddNewJeweleryType(JeweleryType jeweleryType);
    public Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes);
}