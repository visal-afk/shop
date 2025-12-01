using ConsoleApp1.Database;
using ConsoleApp1.exception;
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
        var idCheck = _shopDb.categories.Any(c => c.Id == order.Id);
        if (idCheck)
        {
            throw new IdCheckException("Bu Id artiq movcuddur");
        }
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
            throw new NotFoundException("Bele order movcud deyil!");
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
            throw new NotFoundException("Bele order movcud deyil!");
        }
    }
}
