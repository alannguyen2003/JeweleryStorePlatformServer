using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformBusinessObject.Transaction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JeweleryStorePlatformDataAccess;

public class AppDbContext : IdentityDbContext<Account, 
    Role, 
    int,
    IdentityUserClaim<int>,
    IdentityUserRole<int>,
    IdentityUserLogin<int>,
    IdentityRoleClaim<int>,
    IdentityUserToken<int>
>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Jewelery> Jeweleries { get; set; }
    public DbSet<JeweleryCase> JeweleryCases { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<JeweleryDesign> JeweleryDesigns { get; set; }
    public DbSet<JeweleryDesignImage> JeweleryDesignImages { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<GIAReport> Reports { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<AccountPromotion> AccountPromotions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        return configuration.GetConnectionString("DefaultConnectionString") ?? string.Empty;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AccountPromotion>()
            .HasKey(item => new { item.AccountId, item.PromotionId });
        builder.Entity<AccountRole>()
            .HasKey(item => new { item.AccountId, item.RoleId });
        builder.Entity<Account>(entity =>
        {
            entity.ToTable(name: "Accounts");
        });
        builder.Entity<Role>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
    }
}