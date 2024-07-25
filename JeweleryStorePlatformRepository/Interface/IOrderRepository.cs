using JeweleryStorePlatformBusinessObject.Diamond;
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
        Task<int> Add(Order order);
        Task AddRange(List<Order> order);
        Task<int> Delete(int orderId);
        Task<Order> Update(Order order);
    }
}
