using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> GetById(int orderitemId);
        Task<int> Create(OrderItemDTO request);
        Task AddRange(List<OrderItem> orderItems);
        Task<int> Delete(int orderItemId);
    }
}
