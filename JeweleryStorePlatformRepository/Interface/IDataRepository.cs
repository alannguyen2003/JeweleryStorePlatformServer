namespace JeweleryStorePlatformRepository.Interface;

public interface IDataRepository
{
    public Task MigrationAsync();
}