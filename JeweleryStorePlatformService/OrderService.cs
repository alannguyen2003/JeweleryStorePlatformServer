using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly AppDbContext _context;
        public OrderService(IOrderRepository orderRepository, AppDbContext context)
        {
            _context = context;
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }
        public async Task<Order> GetById(int orderId)
        {
            return await _orderRepository.GetById(orderId);
        }
        public async Task<int> Create(OrderDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                var address = await _context.Addresses.FindAsync(request.AddressId);
                if (address == null)
                {
                    throw new InvalidOperationException($"Address with ID {request.AddressId} does not exist.");
                }

                var account = await _context.Addresses.FindAsync(request.AddressId);
                if (account == null)
                {
                    throw new InvalidOperationException($"Address with ID  {request.AddressId} does not exist.");
                }

                var order = new Order
                {
                    Price = request.Price,
                    AddressId = request.AddressId,
                    Status = request.Status,
                    StartDateTime = DateTime.UtcNow,
                    FinishedTime = request.FinishedTime,
                    AccountId = request.AccountId,
                    PromotionCode = request.PromotionCode,
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return order.Id;

            }
            catch (Exception ex)
            {
                // Log the exception here if a logging framework is in place
                throw new Exception("An error occurred while creating the order", ex);
            }
        }
        public async Task<int> Delete(int orderId)
        {
            return await _orderRepository.Delete(orderId);
        }
    }
}
