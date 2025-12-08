namespace ConsoleApp1.Service;
using ConsoleApp1.Database;
using ConsoleApp1.exception;
using ConsoleApp1.Models;
using ConsoleApp1.Service.Abstract;
using System.Collections.Generic;

public class ProductService : BaseService, IProductService
{

    public ProductService(ShopDb shopDb) : base(shopDb)
    {
        
    }

    public void Add(Product item)
    {
        var idCheck = _shopDb.products.Any(p => p.Id == item.Id);
        if (idCheck)
        {
            throw new IdCheckException("Bu Id artiq movcuddur");
        }
        _shopDb.products.Add(item);
    }

    public void Delete(int id)
    {
        
        var product = _shopDb.products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _shopDb.products.Remove(product);
        }
        else
        {
            throw new NotFoundException("Bele product movcud deyil!");
        }
    }

    public List<Product> GetAll()
    {
        
        return _shopDb.products;
    }

    public Product GetById(int id)
    {
        
        var product = _shopDb.products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            return product;
        }
        else
        {
            throw new NotFoundException("Bele product movcud deyil!");
        }

    }

    public Product Update(Product item)
    {
        
        var existingProduct = _shopDb.products.FirstOrDefault(p => p.Id == item.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = item.Name;
            existingProduct.Price = item.Price;
            existingProduct.Category = item.Category;
            return existingProduct;
        }
        else
        {
            throw new NotFoundException("Bele product movcud deyil!");
        }
    }
  


}
