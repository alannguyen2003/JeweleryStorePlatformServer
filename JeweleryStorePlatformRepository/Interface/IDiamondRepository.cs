
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;

namespace JeweleryStorePlatformRepository.Interface;

public interface IDiamondRepository
{
    public IQueryable<Diamond> GetAllDiamonds();
    Task<Diamond> GetDiamondById(int id);
    Task<Diamond> CreateDiamond(Diamond diamond);
    Task<Diamond> UpdateDiamond(Diamond diamond);
    Task<bool> DeleteDiamond(int id);

}