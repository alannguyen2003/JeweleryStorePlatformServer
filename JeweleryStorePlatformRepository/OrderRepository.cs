using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetAll()
        {
            return await OrderDAO.Instance.GetAllOrder();
        }
        public async Task<Order> GetById(int orderId)
        {
            return await OrderDAO.Instance.GetById(orderId);
        }
        public async Task Add(Order order)
        {
            await OrderDAO.Instance.Add(order);
        }

        public async Task AddRange(List<Order> order)
        {
            await OrderDAO.Instance.AddRange(order);
        }

        public async Task<int> Delete(int orderId)
        {
            return await OrderDAO.Instance.Delete(orderId);
        }

        public async Task<List<Order>> GetOrderByAccountId(int accountId)
        {
            return await OrderDAO.Instance.GetOrderByAccountId(accountId);
        }

        public async Task<Order> GetOrderByIdAndAccountId(int orderId, int accountId)
        {
            return await OrderDAO.Instance.GetOrderByIdAndAccountId(orderId, accountId);
        }
    }
}
