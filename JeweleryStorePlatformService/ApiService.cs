using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformDataTransfer.Response;
using JeweleryStorePlatformService.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class ApiService
    {
        private readonly HttpClientHelper _httpClientHelper;

        public ApiService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        public async Task<List<ProvinceDTO>> GetProvincesAsync()
        {
            var response = await _httpClientHelper.GetAsync<ApiResponse<List<ProvinceDTO>>>("/api/province");
            return response.Results;
        }

        public async Task<List<DistrictDTO>> GetDistrictsAsync(int provinceId)
        {
            var response = await _httpClientHelper.GetAsync<ApiResponse<List<DistrictDTO>>>($"/api/province/district/{provinceId}");
            return response.Results;
        }

        public async Task<List<WardDTO>> GetWardsAsync(int districtId)
        {
            var response = await _httpClientHelper.GetAsync<ApiResponse<List<WardDTO>>>($"/api/province/ward/{districtId}");
            return response.Results;
        }
    }

}
