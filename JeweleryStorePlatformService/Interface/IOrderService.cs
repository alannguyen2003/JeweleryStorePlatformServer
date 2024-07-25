using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrdersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int orderId);
        Task<int> Create(OrderDTO request);
        Task<int> Delete(int orderId);
        Task<int> ChangStatus(int orderId, int status);
        Task<List<Order>> GetOrderByAccountId(int accountId);
        Task<Order> GetOrderByIdAndAccountId(int orderId, int accountId);
    }
}
