using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class DataRepository : IDataRepository
{
    public async Task MigrationAsync()
    {
        await DataDAO.Instance.MigrationAsync();
    }
}