using ConsoleApp1.Models;
using ConsoleApp1.Persistence.Concrete;
namespace ConsoleApp1.Database;

 public class ShopDb   
 {
        public List<Product> products = new List<Product>();
        public List<Category> categories = new List<Category>();
        public List<Order> orders=new List<Order>();
    private readonly JsonRepository<Product> _productRepository;
    private readonly JsonRepository<Category> _categoryRepository;
    private readonly JsonRepository<Order> _orderRepository;
    public ShopDb()
    {
        _productRepository = new JsonRepository<Product>("products.json");
        _categoryRepository = new JsonRepository<Category>("categories.json");
        _orderRepository = new JsonRepository<Order>("orders.json");

        products = _productRepository.LoadData();
        categories = _categoryRepository.LoadData();
        orders = _orderRepository.LoadData();
    }
    public void SaveChanges()
    {
        _productRepository.SaveData(products);
        _categoryRepository.SaveData(categories);
        _orderRepository.SaveData(orders);
    }



}

