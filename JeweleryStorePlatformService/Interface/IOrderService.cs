using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JeweleryStorePlatformService.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int orderId);
        Task<int> Create(ClaimsPrincipal claims, OrderDTO request);
        Task<int> Delete(int orderId);
        Task<int> ChangStatus(int orderId, int status);
        Task<List<Order>> GetOrderByAccountId(int accountId);
        Task<Order> GetOrderByIdAndAccountId(int orderId, int accountId);
        public Task AcceptedOrder(int orderId);
        public Task RejectOrder(int orderId);
        public Task ChangeToShipOrder(int orderId);
        public Task ChangeToPaid(int orderId);
        public Task FinishOrder(int orderId);
    }
}
