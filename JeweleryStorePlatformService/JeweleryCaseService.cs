using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.JewelerysDTO;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class JeweleryCaseService : IJeweleryCaseService
    {
        private readonly IJeweleryCaseRepository _jewelerycaseRepository;
        private readonly AppDbContext _context;

        public async Task<List<JeweleryCase>> GetAll()
        {
            return await _jewelerycaseRepository.GetAll();
        }

        public async Task<JeweleryCase> GetById(int jeweleryId)
        {
            return await _jewelerycaseRepository.GetById(jeweleryId);
        }
        public JeweleryCaseService(AppDbContext context, IJeweleryCaseRepository jewelerycaseRepository)
        {
            _context = context;
            _jewelerycaseRepository = jewelerycaseRepository;
        }

        public async Task<int> Create(JeweleryCaseDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                // Kiểm tra xem JeweleryType có tồn tại không
                var color = await _context.Colors.FindAsync(request.ColorId);
                if (color == null)
                {
                    throw new ArgumentException($"Color with ID {request.ColorId} does not exist.");
                }
                var material = await _context.Materials.FindAsync(request.MaterialId);
                if (material == null)
                {
                    throw new ArgumentException($"Material with ID {request.MaterialId} does not exist.");
                }

                // Tạo mới đối tượng Jewelery
                var jewelery = new JeweleryCase
                {
                    CaseName = request.CaseName,
                    ColorId = request.ColorId,
                    MaterialId = request.MaterialId // Gán thể hiện của JeweleryType từ DB
                };

                // Thêm Jewelery vào context và lưu vào cơ sở dữ liệu
                _context.JeweleryCases.Add(jewelery);
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
            return await _jewelerycaseRepository.Delete(jeweleryId);
        }

        public async Task<int> Update(JeweleryCaseUpdateDTO request)
        {
            var existingJewelery = await _jewelerycaseRepository.GetById(request.Id);
            if (existingJewelery == null)
            {
                throw new KeyNotFoundException($"JeweleryCase with ID {request.Id} not found.");
            }

            // Update properties
            existingJewelery.CaseName = request.CaseName;
            existingJewelery.ColorId = request.ColorId;
            existingJewelery.MaterialId = request.MaterialId;
            // Update other properties as needed

            return await _jewelerycaseRepository.Update(existingJewelery);
        }
        public async Task AddRange(List<JeweleryCase> jeweleryCases)
        {
            await _jewelerycaseRepository.AddRange(jeweleryCases);
        }
    }
}
