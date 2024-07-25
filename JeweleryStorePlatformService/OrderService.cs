using AutoMapper;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformBusinessObject.Transaction;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Constant;

namespace JeweleryStorePlatformService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(IOrderRepository orderRepository,
            ITransactionRepository transactionRepository, IAddressRepository addressRepository,
            IHttpContextAccessor httpContextAccessor, IMapper mapper,
            IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
            _addressRepository = addressRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
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
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var accountId = Int32.Parse(identity.FindFirst("AccountId").Value);
                Address address = new Address()
                {
                    DistrictId = request.DistrictId,
                    AddressString = request.Address
                };
                var addressId = await _addressRepository.AddNewAddress(address);
                Order order = new Order()
                {
                    Status = (int)OrderStatusConstant.PENDING,
                    AddressId = addressId,
                    StartDateTime = DateTime.Now,
                    Price = request.Price,
                    AccountId = accountId
                };
                var orderId = await _orderRepository.Add(order);
                var orderItems = new List<OrderItem>();
                foreach (var item in request.OrderItems)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        DiamondId = item.DiamondId,
                        Size = item.Size,
                        JeweleryCaseId = item.CaseId,
                        OrderId = orderId
                    };
                    orderItems.Add(orderItem);
                }
                await _orderItemRepository.AddRange(orderItems);
                return orderId;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the order", ex);
            }
        }
        public async Task<int> Delete(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} does not exist.");
            }
            if (order.Status != 1)
            {
                throw new InvalidOperationException("Order cannot be deleted unless its status is Pending.");
            }
            order.Status = 5;//5 là Cancelled đã hủy đơn 
             await _orderRepository.Update(order);
            return order.Id;
        }
        public async Task<int> ChangStatus(int orderId, int status)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} does not exist.");
            }
            if(status == order.Status)
            {
                throw new InvalidOperationException($"Status is terminal");
            }    
            if(status == 2)
            {
                order.FinishedTime = DateTime.Now;
            }    
            order.Status = status;
            await _orderRepository.Update(order);
            return order.Id;
        }
    }
}
