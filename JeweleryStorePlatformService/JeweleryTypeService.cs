using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using JeweleryStorePlatformService.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Service.Extensions;

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
            var jeweleryTypes = _jeweleryTypeRepository.GetAllJeweleryTypes();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                jeweleryTypes = jeweleryTypes.Where(x => x.TypeName.Contains(request.SearchTerm));
            }

            // Ensure that the sortBy parameter is valid
            var sortBy = string.IsNullOrEmpty(request.SortBy) ? nameof(JeweleryType.Id) : request.SortBy;

            return await jeweleryTypes
                .ListPaginateWithSortAsync<JeweleryType, JeweleryTypeDTO>(
                    request.Page,
                    request.Size,
                    sortBy,
                    request.SortOrder,
                    _mapper.ConfigurationProvider);
        }

        public async Task<JeweleryTypeDTO> GetJeweleryTypeById(int id)
        {
            var jeweleryType = await _jeweleryTypeRepository.GetJeweleryTypeById(id);
            return _mapper.Map<JeweleryTypeDTO>(jeweleryType);
        }

        public async Task<JeweleryTypeDTO> CreateJeweleryType(JeweleryType request)
        {
            var jeweleryType = _mapper.Map<JeweleryType>(request);
            var createdJeweleryType = await _jeweleryTypeRepository.CreateJeweleryType(jeweleryType);
            return _mapper.Map<JeweleryTypeDTO>(createdJeweleryType);
        }

        public async Task<JeweleryTypeDTO> UpdateJeweleryType(int id, JeweleryTypeUpdateRequest request)
        {
            var jeweleryType = await _jeweleryTypeRepository.GetJeweleryTypeById(id);
            if (jeweleryType == null)
            {
                return null; // Hoặc ném một ngoại lệ tùy theo cách xử lý của bạn
            }

            // Cập nhật các thuộc tính của jeweleryType từ request
            jeweleryType.TypeName = request.TypeName;
            // Cập nhật các thuộc tính khác nếu cần

            await _jeweleryTypeRepository.UpdateJeweleryType(jeweleryType);

            return _mapper.Map<JeweleryTypeDTO>(jeweleryType);
        }

        public async Task<bool> DeleteJeweleryType(int id)
        {
            return await _jeweleryTypeRepository.DeleteJeweleryType(id);
        }

        public async Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes)
        {
            await _jeweleryTypeRepository.AddRangeJeweleryTypes(jeweleryTypes);
        }
    }
}
