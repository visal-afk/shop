namespace ConsoleApp1.Service;
using ConsoleApp1.Database;
using ConsoleApp1.Models;
public class ProductService: BaseService
{

    public ProductService(ShopDb shopDb) : base(shopDb)
    {
        
    }
    public void AddProduct(Product product)
    {
        _shopDb.products.Add(product);
    }
    public List<Product> GetAllProducts()
    {
        return _shopDb.products;
    }
    public void RemoveProduct(int productId)
    {
        var product = _shopDb.products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            _shopDb.products.Remove(product);
        }
        else
        {
            Console.WriteLine("Bele product movcud deyil!");
        }
    }
    public Product ProductUpdate(Product product)
    {
        var existingProduct = _shopDb.products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            return existingProduct;
        }
        else
        {
            Console.WriteLine("Bele product movcud deyil!");
            return null;
        }
    }
    public Product ProductGetById(int productId)
    {
        var product = _shopDb.products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            return product;
        }
        else
        {
            Console.WriteLine("Bele product movcud deyil!");
            return null;
        }
    }


}
