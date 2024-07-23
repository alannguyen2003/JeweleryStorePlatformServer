using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class ProvinceService : IProvinceService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ApiService _apiService;

        public ProvinceService(ICityRepository cityRepository, ApiService apiService, IAddressRepository addressRepository, IDistrictRepository districtRepository)
        {
            _apiService = apiService;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _districtRepository = districtRepository;
        }
        public async Task FetchAndStoreDataAsync()
        {
            var provinces = await _apiService.GetProvincesAsync();
            var cities = new List<City>();
            foreach (var province in provinces)
            {
                cities.Add(new City
                {
                    Id = province.province_id,
                    CityName = province.province_name
                });
            }
            await _cityRepository.AddRange(cities);

            foreach (var province in provinces)
            {
                var districts = await _apiService.GetDistrictsAsync(province.province_id);
                var districtEntities = new List<District>();
                foreach (var district in districts)
                {
                    districtEntities.Add(new District
                    {
                        Id = district.district_id,
                        DistrictName = district.district_name,
                        CityId = province.province_id
                    });
                }
                await _districtRepository.AddRange(districtEntities);

                foreach (var district in districts)
                {
                    var wards = await _apiService.GetWardsAsync(district.district_id);
                    var wardDTOs = new List<Address>();
                    foreach (var ward in wards)
                    {
                        wardDTOs.Add(new Address
                        {
                            Id = ward.ward_id,
                            AddressString = ward.ward_name,
                            DistrictId = district.district_id
                        });
                    }
                    await _addressRepository.AddRange(wardDTOs);
                }
            }
        }
        public async Task<List<City>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }
        public async Task<List<District>> GetAllDistricts()
        {
            return await _districtRepository.GetAllDistricts();
        }
        public async Task<List<Address>> GetAllAddresses()
        {
            return await _addressRepository.GetAllAddresses();
        }
    }
}
