using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeweleryStorePlatformBusinessObject.Constant;

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
        public async Task<int> Add(Order order)
        {
            return await OrderDAO.Instance.Add(order);
        }

        public async Task AddRange(List<Order> order)
        {
            await OrderDAO.Instance.AddRange(order);
        }

        public async Task<Order> Update(Order order)
        {
            return await OrderDAO.Instance.Update(order);

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

        public async Task AcceptOrder(int orderId)
        {
            var order = await OrderDAO.Instance.GetById(orderId);
            order.Status = (int)OrderStatusConstant.ACCEPTED;
            await OrderDAO.Instance.Update(order);
        }

        public async Task RejectOrder(int orderId)
        {
            var order = await OrderDAO.Instance.GetById(orderId);
            order.Status = (int)OrderStatusConstant.REJECTED;
            await OrderDAO.Instance.Update(order);
        }

        public async Task ChangeToShipOrder(int orderId)
        {
            var order = await OrderDAO.Instance.GetById(orderId);
            order.Status = (int)OrderStatusConstant.ON_SHIPPING;
            await OrderDAO.Instance.Update(order);
        }

        public async Task ChangeToPaid(int orderId)
        {
            var order = await OrderDAO.Instance.GetById(orderId);
            order.Status = (int)OrderStatusConstant.PAID;
            await OrderDAO.Instance.Update(order);
        }

        public async Task FinishOrder(int orderId)
        {
            var order = await OrderDAO.Instance.GetById(orderId);
            order.Status = (int)OrderStatusConstant.FINISHED;
            await OrderDAO.Instance.Update(order);
        }
    }
}
