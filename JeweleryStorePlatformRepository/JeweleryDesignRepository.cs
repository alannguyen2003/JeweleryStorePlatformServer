using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class JeweleryDesignRepository : IJeweleryDesignRepository
{
    public async Task<List<JeweleryDesign>> GetAllJeweleryDesign()
    {
        return await JeweleryDesignDAO.Instance.GetAllJeweleryDesign();
    }

    public async Task<JeweleryDesign> AddNewJeweleryDesign(JeweleryDesign jeweleryDesign)
    {
        await JeweleryDesignDAO.Instance.AddNewJeweleryDesign(jeweleryDesign);
        return jeweleryDesign;
    }
    public async Task<JeweleryDesign?> GetById(int jeweleryId)
    {
        return await JeweleryDesignDAO.Instance.GetById(jeweleryId);
    }

}