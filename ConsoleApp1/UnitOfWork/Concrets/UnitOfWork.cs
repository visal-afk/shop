using ConsoleApp1.Database;
using ConsoleApp1.Service;
using ConsoleApp1.Service.Abstract;
using ConsoleApp1.Services;
using ConsoleApp1.UnitOfWork.Abstract;

namespace ConsoleApp1.UnitOfWork.Concrets;

public class UnitOfWork : IUnitOfWorks
{
    private readonly ShopDb _shopDb;

    public UnitOfWork(ShopDb shopDb)
    {
        _shopDb = shopDb;
    }

    public ICategoryService Categories => throw new NotImplementedException();

    public IProductService Products => throw new NotImplementedException();

    public IOrderService Orders => throw new NotImplementedException();
}
