using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class DiamondRepository : IDiamondRepository
{
    public IQueryable<DiamondEntity> GetAllDiamonds()
    {
        return DiamondDAO.Instance.GetAllDiamonds();
    }

}