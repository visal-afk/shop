using ConsoleApp1.Database;
using ConsoleApp1.exception;
using ConsoleApp1.Models;
using ConsoleApp1.Service;
using ConsoleApp1.Service.Abstract;
using ConsoleApp1.Services.Abstract;

namespace ConsoleApp1.Services;

public class OrderService : BaseService, IOrderService
{
    public OrderService(ShopDb shopDb) : base(shopDb)
    {
    }

    public void Add(Order item)
    {
        var idCheck = _shopDb.orders.Any(o => o.Id == item.Id);
        if (idCheck)
        {
            throw new IdCheckException("Bu Id artiq movcuddur");
        }
        _shopDb.orders.Add(item);

    }

    public void Delete(int id)
    {
        
        var order = _shopDb.orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _shopDb.orders.Remove(order);
        }
        else
        {
            throw new NotFoundException("Bele order movcud deyil!");
        }

    }

    public List<Order> GetAll()
    {
        return _shopDb.orders;
    }

    public Order GetById(int id)
    {

        var order = _shopDb.orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            return order;
        }
        else
        {
            throw new NotFoundException("Bele order movcud deyil!");
        }

    }

    public Order Update(Order item)
    {
        
        var existingOrder = _shopDb.orders.FirstOrDefault(o => o.Id == item.Id);
        if (existingOrder != null)
        {
            existingOrder.TotalAmount = item.TotalAmount;
            existingOrder.Products = item.Products;
            return existingOrder;
        }
        else
        {
            throw new NotFoundException("Bele order movcud deyil!");
        }
    }

    

}
