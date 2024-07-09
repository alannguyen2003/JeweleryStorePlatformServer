using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class JeweleryService : IJeweleryService
    {
        private readonly IJeweleryRepository _jeweleryRepository;
        private readonly AppDbContext _context;

        public async Task<List<JeweleryEntity>> GetAll()
        {
            return await _jeweleryRepository.GetAll();
        }

        public async Task<JeweleryEntity> GetById(int jewelryId)
        {
            return await _jeweleryRepository.GetById(jewelryId);
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
                // Initialize JeweleryTypeEntity to null
                JeweleryTypeEntity jeweleryTypeEntity = null;

                // Check if JeweleryTypeEntity is provided
                //if (request.JeweleryTypeEntity != null)
                //{
                //    jeweleryTypeEntity = new JeweleryTypeEntity
                //    {
                //        TypeName = request.JeweleryTypeEntity.TypeName
                //    };

                //    // Add and save JeweleryTypeEntity first to get its generated Id
                //    _context.JeweleryTypes.Add(jeweleryTypeEntity);
                //    await _context.SaveChangesAsync();

                //    // Assign the generated Id to the request's TypeId
                //    request.TypeId = jeweleryTypeEntity.Id;
                //}

                // Create JeweleryEntity
                var jeweleryEntity = new JeweleryEntity
                {
                    JeweleryName = request.JeweleryName,
                    TypeId = request.TypeId,
                    //JeweleryTypeEntity = jeweleryTypeEntity
                };

                // Add and save JeweleryEntity
                _context.Jeweleries.Add(jeweleryEntity);
                await _context.SaveChangesAsync();

                return jeweleryEntity.Id;
            }
            catch (Exception ex)
            {
                // Log and handle the exception as needed
                throw new Exception("An error occurred while creating the jewelry", ex);
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
            existingJewelery.TypeId = request.TypeId;
            // Update other properties as needed

            return await _jeweleryRepository.Update(existingJewelery);
        }
    }
}
