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
    public async Task<Diamond> GetDiamondById(int id)
    {
        return await DiamondDAO.Instance.GetDiamondById(id);
    }

    public async Task<Diamond> CreateDiamond(Diamond diamond)
    {
        return await DiamondDAO.Instance.CreateDiamond(diamond);
    }

    public async Task<Diamond> UpdateDiamond(Diamond diamond)
    {
        return await DiamondDAO.Instance.UpdateDiamond(diamond);
    }

    public async Task<bool> DeleteDiamond(int id)
    {
        return await DiamondDAO.Instance.DeleteDiamond(id);
    }
}