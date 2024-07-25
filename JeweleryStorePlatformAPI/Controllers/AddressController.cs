using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformDataTransfer.Responses;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IProvinceService _provinceService;

    public AddressController(IProvinceService provinceService)
    {
        _provinceService = provinceService;
    }

    [HttpGet("get-all-provinces")]
    public async Task<IActionResult> GetAllProvinces()
    {
        var provinces = await _provinceService.GetAllCities();
        if (!provinces.Any())
        {
            return NotFound("No provinces in DB");
        }

        return Ok(new Result<List<City>>()
        {
            Succeeded = true,
            Data = provinces
        });
    }

    [HttpGet("get-districts-by-province")]
    public async Task<IActionResult> GetAllDistrictsByProvinceId(int provinceId)
    {
        var districts = await _provinceService.GetAllDistrictsByProvinceId(provinceId);
        if (!districts.Any())
        {
            return NotFound("No districts in DB");
        }
        return Ok(new Result<List<District>>()
        {
            Succeeded = true,
            Data = districts
        });
    }
}