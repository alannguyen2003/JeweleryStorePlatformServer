using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JeweleryStorePlatformBusinessObject.Account;

[Table("Roles")]
public class Role : IdentityRole<int>
{
    
}