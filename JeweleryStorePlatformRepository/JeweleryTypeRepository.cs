using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class JeweleryTypeRepository : IJeweleryTypeRepository
{
    public async Task<List<JeweleryType>> GetAllJeweleryType()
    {
        return await JeweleryTypeDAO.Instance.GetAllJeweleryType();
    }

    public async Task AddNewJeweleryType(JeweleryType jeweleryType)
    {
        await JeweleryTypeDAO.Instance.AddNewJeweleryType(jeweleryType);
    }

    public async Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes)
    {
        await JeweleryTypeDAO.Instance.AddRangeJeweleryType(jeweleryTypes);
    }
}