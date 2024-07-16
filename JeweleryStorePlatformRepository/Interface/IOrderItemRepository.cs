using JeweleryStorePlatformBusinessObject.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository.Interface
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> GetById(int orderitemId);
        Task Add(OrderItem orderItem);
        Task AddRange(List<OrderItem> orderItems);
        Task<int> Delete(int orderItemId);
    }
}
