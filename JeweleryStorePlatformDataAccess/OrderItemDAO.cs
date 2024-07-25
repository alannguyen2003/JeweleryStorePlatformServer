using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformBusinessObject.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class OrderItemDAO
    {
        private readonly AppDbContext _context;
        private static OrderItemDAO instance;

        public OrderItemDAO()
        {
            _context = new AppDbContext();
        }

        public static OrderItemDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderItemDAO();
                }
                return instance;
            }
        }

        public async Task<List<OrderItem>> GetAllOrderItem()
        {
            return await _context.OrderItems
                .Include(o => o.JeweleryCase)
                .Include(o => o.Order)
                .Include(o => o.JeweleryDesign)
                .Include(o => o.Jewelery)
                .Include(o => o.Diamond)
                .ToListAsync();
        }

        public async Task<OrderItem> GetById(int orderitemId)
        {
            return await _context.OrderItems.FindAsync(orderitemId);
        }

        public async Task Add(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<OrderItem> orderItem)
        {
            await _context.OrderItems.AddRangeAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem == null)
            {
                return 0; // Or throw an exception if preferred
            }

            _context.OrderItems.Remove(orderItem);
            return await _context.SaveChangesAsync(); // This will return the number of affected rows
        }
        public async Task<OrderItem> Update(OrderItem orderitem)
        {
            var existingOrderitem = await _context.Set<OrderItem>().FindAsync(orderitem.Id);
            if (existingOrderitem == null)
            {
                return null;
            }

            _context.Entry(existingOrderitem).CurrentValues.SetValues(orderitem);
            await _context.SaveChangesAsync();
            return existingOrderitem;
        }
    }
}
