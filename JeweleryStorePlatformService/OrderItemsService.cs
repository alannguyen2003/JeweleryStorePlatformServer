using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class OrderItemsService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IJeweleryCaseRepository _jeweleryCaseRepository;
        private readonly IJeweleryRepository  _jeweleryRepository;
        private readonly IJeweleryDesignRepository _jeweleryDesignRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiamondRepository _diamondRepository;

        public OrderItemsService(IOrderItemRepository orderItemRepository, IJeweleryCaseRepository jeweleryCaseRepository, IJeweleryRepository jeweleryRepository, IJeweleryDesignRepository jeweleryDesignRepository,
            IOrderRepository orderRepository, IDiamondRepository diamondRepository)
        {
            _orderItemRepository = orderItemRepository;
            _jeweleryCaseRepository = jeweleryCaseRepository;
            _jeweleryRepository = jeweleryRepository;
            _orderRepository = orderRepository;
            _diamondRepository = diamondRepository;
            _jeweleryDesignRepository = jeweleryDesignRepository;
            
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _orderItemRepository.GetAll();
        }

        public async Task<OrderItem> GetById(int orderitemId)
        {
            return await _orderItemRepository.GetById(orderitemId);
        }
        public async Task<int> Create(OrderItemDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                var jeweleryCase = await _jeweleryCaseRepository.GetById(request.JeweleryCaseId);
                if (jeweleryCase == null)
                {
                    throw new InvalidOperationException($"JeweleryCase with ID {request.JeweleryCaseId} does not exist.");
                }

                var jewelery = await _jeweleryRepository.GetById(request.JeweleryId);
                if (jewelery == null)
                {
                    throw new InvalidOperationException($"Jewelery with ID {request.JeweleryId} does not exist.");
                }

                var order = await _orderRepository.GetById(request.OrderId);
                if (order == null)
                {
                    throw new InvalidOperationException($"Order with ID {request.OrderId} does not exist.");
                }

                var diamond = await _diamondRepository.GetDiamondById(request.DiamondId);
                if (diamond == null)
                {
                    throw new InvalidOperationException($"Diamond with ID {request.DiamondId} does not exist.");
                }

                var jeweleryDesign = await _jeweleryDesignRepository.GetById(request.JeweleryDesignId);
                if (jeweleryDesign == null)
                {
                    throw new InvalidOperationException($"JeweleryDesign with ID {request.JeweleryDesignId} does not exist.");
                }

                var orderItem = new OrderItem
                {
                    JeweleryCaseId = request.JeweleryCaseId,
                    JeweleryId = request.JeweleryId,
                    OrderId = request.OrderId,
                    DiamondId = request.DiamondId,
                    JeweleryDesignId = request.JeweleryDesignId,
                    DesignFee = request.DesignFee,
                };

                await _orderItemRepository.Add(orderItem);
                return orderItem.Id;
                
            }
            catch (Exception ex)
            {
                // Log the exception here if a logging framework is in place
                throw new Exception("An error occurred while creating the order item", ex.InnerException);
            }
        }

        public async Task AddRange(List<OrderItem> orderItems)
        {
            await _orderItemRepository.AddRange(orderItems);
        }
        public async Task<int> Delete(int orderItemId)
        {
            return await _orderItemRepository.Delete(orderItemId);
        }
        public async Task<int> SetDesignFee(int orderItemId, int designfee)
        {
            var orderitem = await _orderItemRepository.GetById(orderItemId);
            if (orderitem == null)
            {
                throw new InvalidOperationException($"Order with ID {orderItemId} does not exist.");
            }
            orderitem.DesignFee = designfee;
            await _orderItemRepository.Update(orderitem);
            return orderitem.Id;
        }
    }
}
