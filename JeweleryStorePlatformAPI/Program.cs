using JeweleryStorePlatformAPI.Configuration;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformService.Interface;
using JeweleryStorePlatformService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformRepository;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAuthorization();
builder.Services.AddControllers();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddAutoMapper();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSeeding();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCloudinarySetting(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000"));

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<Seeding>();
    await context.MigrationAsync();
    await context.AccountSeeding();
    await context.SeedingJeweleryTypes();
    await context.SeedingRole();
    await context.SeedingAccountRole();
    await context.SeedingDiamond();
    await context.SeedingAddress();
    await context.SeedingMaterial();
    await context.SeedingColor();
    await context.SeedingJeweleryCases();
    await context.SeedingPaymentMethod();
    await context.SeedingPromotion();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error while seeding data"); 
}


app.Run();
