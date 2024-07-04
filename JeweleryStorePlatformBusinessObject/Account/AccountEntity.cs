using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JeweleryStorePlatformBusinessObject.Account;

[Table("Accounts")]
public class AccountEntity : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public int Points { get; set; }
    public string ProfileImage { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
}