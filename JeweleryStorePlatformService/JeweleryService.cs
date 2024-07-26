using JeweleryStorePlatformBusinessObject.Jewelery;
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

        public JeweleryService(IJeweleryRepository jeweleryRepository)
        {
            _jeweleryRepository = jeweleryRepository;
        }

        public async Task<List<Jewelery>> GetAll()
        {
            return await _jeweleryRepository.GetAll();
        }

        public async Task<Jewelery> GetById(int jeweleryId)
        {
            return await _jeweleryRepository.GetById(jeweleryId);
        }

        public async Task<int> Create(JeweleryCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                // Ensure JeweleryType exists
                var jeweleryType = await _jeweleryRepository.GetJeweleryTypeById(request.TypeId);
                if (jeweleryType == null)
                {
                    throw new ArgumentException($"JeweleryType with ID {request.TypeId} does not exist.");
                }

                // Create new Jewelery entity
                var jewelery = new Jewelery
                {
                    JeweleryName = request.JeweleryName,
                    JeweleryTypeId = request.TypeId,
                    JeweleryType = jeweleryType // Set the JeweleryType from DB
                };

                // Add the new Jewelery entity
                await _jeweleryRepository.Add(jewelery);

                // Return the id of the newly created Jewelery
                return jewelery.Id;
            }
            catch (Exception ex)
            {
                // Handle and rethrow the exception if an error occurs
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
