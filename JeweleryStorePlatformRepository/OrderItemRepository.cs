using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.OrderItemsDTO;
using JeweleryStorePlatformRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public async Task<List<OrderItem>> GetAll()
        {
            return await OrderItemDAO.Instance.GetAllOrderItem();
        }

        public async Task<OrderItem> GetById(int orderitemId)
        {
            return await OrderItemDAO.Instance.GetById(orderitemId);
        }

        public async Task Add(OrderItem orderItem)
        {
            await OrderItemDAO.Instance.Add(orderItem);
        }

        public async Task AddRange(List<OrderItem> orderItems)
        {
            await OrderItemDAO.Instance.AddRange(orderItems);
        }

        public async Task<int> Delete(int orderItemId)
        {
            return await OrderItemDAO.Instance.Delete(orderItemId);
        }
    }
}
