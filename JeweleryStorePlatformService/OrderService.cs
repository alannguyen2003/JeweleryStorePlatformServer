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
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, ITransactionRepository transactionRepository, IAddressRepository addressRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
            _addressRepository = addressRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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
                var address = await _addressRepository.GetAddressById(request.AddressId);
                if (address == null)
                {
                    throw new InvalidOperationException($"Address with ID {request.AddressId} does not exist.");
                }

                var user = _httpContextAccessor.HttpContext.User;
                var accountIdClaim = user.FindFirst("AccountId");

                if (accountIdClaim == null)
                {
                    throw new InvalidOperationException("User is not authenticated or AccountId claim is missing.");
                }

                var accountId = int.Parse(accountIdClaim.Value);

                var order = new Order
                {
                    Price = request.Price,
                    AddressId = request.AddressId,
                    Status = 1,
                    StartDateTime = DateTime.UtcNow,
                    FinishedTime = DateTime.UtcNow,
                    AccountId = accountId,
                    PromotionCode = request.PromotionCode,
                };

                await _orderRepository.Add(order);

                if (request.Amount > 0 && request.PaymentMethodId > 0)
                {
                    var transaction = new Transaction
                    {
                        TransactionStatus = 1, 
                        Amount = request.Amount,
                        OrderId = order.Id,
                        AccountId = accountId,
                        PaymentMethodId = request.PaymentMethodId
                    };

                    await _transactionRepository.CreateTransaction(transaction);
                }

                return order.Id;
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
