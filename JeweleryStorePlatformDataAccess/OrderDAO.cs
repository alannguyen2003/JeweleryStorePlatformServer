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
                .Include(o => o.Account)
                .Include(o => o.Address)
                .ToListAsync();
        }
        public async Task<Order> GetById(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }
        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
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
    }
}
