using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class RoleRepository : IRoleRepository
{
    public async Task<List<Role>> GetAllRoles()
    {
        return await RoleDAO.Instance.GetAllRoles();
    }

    public async Task AddNewRole(Role role)
    {
        await RoleDAO.Instance.AddNewRole(role);
    }

    public async Task AddRangeRoles(List<Role> roles)
    {
        await RoleDAO.Instance.AddRangeRole(roles);
    }
}