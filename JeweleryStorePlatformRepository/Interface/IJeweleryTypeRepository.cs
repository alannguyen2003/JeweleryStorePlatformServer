using JeweleryStorePlatformBusinessObject.Jewelery;

namespace JeweleryStorePlatformRepository.Interface;

public interface IJeweleryTypeRepository
{
    public Task<List<JeweleryType>> GetAllJeweleryType();
    public Task AddNewJeweleryType(JeweleryType jeweleryType);
    public Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes);
} 