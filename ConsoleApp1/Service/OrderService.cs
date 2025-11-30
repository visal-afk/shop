using ConsoleApp1.Database;
using ConsoleApp1.Models;
using ConsoleApp1.Service;
namespace ConsoleApp1.Services;

public class OrderService : BaseService
{
    public OrderService(ShopDb shopDb) : base(shopDb)
    {
    }
    public void AddOrder(Order order)
    {
        _shopDb.orders.Add(order);
    }
    public List<Order> GetAllOrders()
    {
        return _shopDb.orders;
    }
    public void RemoveOrder(int orderId)
    {
        var order = _shopDb.orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            _shopDb.orders.Remove(order);
        }
        else
        {
            Console.WriteLine("Bele order movcud deyil!");
        }
    }
    public Order OrderUpdate(Order order)
    {
        var existingOrder = _shopDb.orders.FirstOrDefault(o => o.Id == order.Id);
        if (existingOrder != null)
        {
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.Products = order.Products;
            return existingOrder;
        }
        else
        {
            Console.WriteLine("Bele order movcud deyil!");
            return null;
        }
    }
    public Order OrderGetById(int orderId)
    {
        var order = _shopDb.orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            return order;
        }
        else
        {
            Console.WriteLine("Bele order movcud deyil!");
            return null;
        }
    }
}
