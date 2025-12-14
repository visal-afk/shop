using ConsoleApp1.Database;
using ConsoleApp1.exception;
using ConsoleApp1.Models;
using ConsoleApp1.Service;
using ConsoleApp1.Service.Abstract;

namespace ConsoleApp1.Services;

public class CategoryService : BaseService, ICategoryService
{
    public CategoryService(ShopDb shopDb) : base(shopDb)
    {
    }
    public void Add(Category item)
    {
        var idCheck = _shopDb.categories.Any(c => c.Id == item.Id);
        if (idCheck)
        {
            throw new Exception("Bu Id artiq movcuddur");
        }
        _shopDb.categories.Add(item);
        _shopDb.SaveChanges();
    }

    public void Delete(int id)
    {
        
        var category = _shopDb.categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            _shopDb.categories.Remove(category);
            _shopDb.SaveChanges();
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!");
        }
    }

    public List<Category> GetAll()
    {
        return _shopDb.categories;
    }

    public Category GetById(int id)
    {
        
        var category = _shopDb.categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            return category;
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!");
        }

    }

    public Category Update(Category item)
    {
        
        var existingCategory = _shopDb.categories.FirstOrDefault(c => c.Id == item.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = item.Name;
            existingCategory.Description = item.Description;
            _shopDb.SaveChanges();
            return existingCategory;
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!");
        }
    }
}
