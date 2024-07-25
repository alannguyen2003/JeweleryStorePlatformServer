using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class OrderDAO
    {
        private readonly AppDbContext _context;
        private static OrderDAO instance;

        public OrderDAO()
        {
            _context = new AppDbContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders
                .Include(o => o.Address)
                .ToListAsync();
        }
        public async Task<Order> GetById(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }
        public async Task<int> Add(Order order)
        {
            _context.ChangeTracker.Clear();
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task AddRange(List<Order> order)
        {
            await _context.Orders.AddRangeAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return 0;
            }

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<Order> Update(Order order)
        {
            var existingOrder = await _context.Set<Order>().FindAsync(order.Id);
            if (existingOrder == null)
            {
                return null;
            }

            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<List<Order>> GetOrderByAccountId(int accountId)
        {
            return await _context.Orders.Where(o => o.AccountId == accountId).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAndAccountId(int orderId, int accountId)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId && o.AccountId == accountId)
                .FirstOrDefaultAsync();
        }
    }
}
