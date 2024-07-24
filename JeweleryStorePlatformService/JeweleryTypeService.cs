using AutoMapper;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;
using Service.Models.Payload.Requests.Member;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class JeweleryTypeService : IJeweleryTypeService
    {
        private readonly IJeweleryTypeRepository _jeweleryTypeRepository;
        private readonly IMapper _mapper;

        public JeweleryTypeService(IJeweleryTypeRepository jeweleryTypeRepository, IMapper mapper)
        {
            _jeweleryTypeRepository = jeweleryTypeRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<JeweleryTypeDTO>> GetAllJeweleryTypes(GetJeweleryTypesRequest request)
        {
            var jeweleryTypes = _jeweleryTypeRepository.GetAllJeweleryTypes().AsQueryable();

            if (request.SearchTerm is not null)
            {
                jeweleryTypes = jeweleryTypes.Where(x => x.TypeName.Contains(request.SearchTerm));
            }

            return await jeweleryTypes
                .ListPaginateWithSortAsync<JeweleryType, JeweleryTypeDTO>(
                    request.Page,
                    request.Size,
                    request.SortBy,
                    request.SortOrder,
                    _mapper.ConfigurationProvider);
        }

        public async Task<JeweleryType> GetJeweleryTypeById(int id)
        {
            return await _jeweleryTypeRepository.GetJeweleryTypeByIdAsync(id);
        }

        public async Task<int> AddNewJeweleryType(JeweleryType jeweleryType)
        {
            await _jeweleryTypeRepository.AddNewJeweleryTypeAsync(jeweleryType);
            return jeweleryType.Id;
        }

        public async Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes)
        {
            await _jeweleryTypeRepository.AddRangeJeweleryTypesAsync(jeweleryTypes);
        }

        public async Task UpdateJeweleryType(JeweleryType jeweleryType)
        {
            await _jeweleryTypeRepository.UpdateJeweleryTypeAsync(jeweleryType);
        }

        public async Task DeleteJeweleryType(int id)
        {
            await _jeweleryTypeRepository.DeleteJeweleryTypeAsync(id);
        }
    }
}
