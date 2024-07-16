using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class JeweleryTypeService : IJeweleryTypeService
{
    private readonly IJeweleryTypeRepository _jeweleryTypeRepository;

    public JeweleryTypeService(IJeweleryTypeRepository jeweleryTypeRepository)
    {
        _jeweleryTypeRepository = jeweleryTypeRepository;
    }
    
    public async Task<List<JeweleryType>> GetAllJeweleryType()
    {
        return await _jeweleryTypeRepository.GetAllJeweleryType();
    }

    public async Task AddNewJeweleryType(JeweleryType jeweleryType)
    {
        await _jeweleryTypeRepository.AddNewJeweleryType(jeweleryType);
    }

    public async Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes)
    {
        await _jeweleryTypeRepository.AddRangeJeweleryType(jeweleryTypes);
    }
}