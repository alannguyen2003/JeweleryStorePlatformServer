using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class DiamondRepository : IDiamondRepository
{
    public IQueryable<Diamond> GetAllDiamonds()
    {
        return DiamondDAO.Instance.GetAllDiamonds();
    }

}