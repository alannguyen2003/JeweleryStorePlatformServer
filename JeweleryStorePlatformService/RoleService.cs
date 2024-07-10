using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public async Task<List<Role>> GetAllRoles()
    {
        return await _roleRepository.GetAllRoles();
    }

    public async Task AddNewRole(Role role)
    {
        await _roleRepository.AddNewRole(role);
    }

    public async Task AddRangeRoles(List<Role> roles)
    {
        await _roleRepository.AddRangeRoles(roles);
    }
}