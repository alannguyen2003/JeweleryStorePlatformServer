
using JeweleryStorePlatformBusinessObject.Diamond;

namespace JeweleryStorePlatformRepository.Interface;

public interface IDiamondRepository
{
    public IQueryable<Diamond> GetAllDiamonds();
}