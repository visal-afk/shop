using ConsoleApp1.Database;

namespace ConsoleApp1.Service;

public abstract class BaseService
{
    protected static ShopDb _shopDb;
    public BaseService(ShopDb shopDb)
    {
        _shopDb = shopDb;
    }
}
