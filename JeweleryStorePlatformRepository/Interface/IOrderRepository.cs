using JeweleryStorePlatformBusinessObject.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int orderId);
        Task Add(Order order);
        Task AddRange(List<Order> order);
        Task<int> Delete(int orderId);
        Task<List<Order>> GetOrderByAccountId(int accountId);
        Task<Order> GetOrderByIdAndAccountId(int orderId, int accountId);
    }
}
