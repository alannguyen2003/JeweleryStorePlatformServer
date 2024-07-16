using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class JeweleryService : IJeweleryService
    {
        private readonly IJeweleryRepository _jeweleryRepository;
        private readonly AppDbContext _context;

        public async Task<List<Jewelery>> GetAll()
        {
            return await _jeweleryRepository.GetAll();
        }

        public async Task<Jewelery> GetById(int jeweleryId)
        {
            return await _jeweleryRepository.GetById(jeweleryId);
        }
        public JeweleryService(AppDbContext context, IJeweleryRepository jeweleryRepository)
        {
            _context = context;
            _jeweleryRepository = jeweleryRepository;
        }

        public async Task<int> Create(JeweleryCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                // Kiểm tra xem JeweleryType có tồn tại không
                var jeweleryType = await _context.JeweleryTypes.FindAsync(request.TypeId);
                if (jeweleryType == null)
                {
                    throw new ArgumentException($"JeweleryType with ID {request.TypeId} does not exist.");
                }

                // Tạo mới đối tượng Jewelery
                var jewelery = new Jewelery
                {
                    JeweleryName = request.JeweleryName,
                    JeweleryTypeId = request.TypeId,
                    JeweleryType = jeweleryType // Gán thể hiện của JeweleryType từ DB
                };

                // Thêm Jewelery vào context và lưu vào cơ sở dữ liệu
                _context.Jeweleries.Add(jewelery);
                await _context.SaveChangesAsync();

                // Trả về id của Jewelery vừa được tạo
                return jewelery.Id;
            }
            catch (Exception ex)
            {
                // Xử lý và ném lại ngoại lệ nếu có lỗi xảy ra
                throw new Exception("An error occurred while creating the jewelery", ex);
            }
        }

        public async Task<int> Delete(int jeweleryId)
        {
            return await _jeweleryRepository.Delete(jeweleryId);
        }

        public async Task<int> Update(JeweleryUpdateRequest request)
        {
            var existingJewelery = await _jeweleryRepository.GetById(request.Id);
            if (existingJewelery == null)
            {
                throw new KeyNotFoundException($"Jewelery with ID {request.Id} not found.");
            }

            // Update properties
            existingJewelery.JeweleryName = request.JeweleryName;
            existingJewelery.JeweleryTypeId = request.TypeId;
            // Update other properties as needed

            return await _jeweleryRepository.Update(existingJewelery);
        }
    }
}
