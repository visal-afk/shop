using ConsoleApp1.Service.Abstract;
namespace ConsoleApp1.UnitOfWork.Abstract;

public interface IUnitOfWorks
{
    ICategoryService Categories { get; }
    IProductService Products { get; }
    IOrderService Orders { get; }
    }
