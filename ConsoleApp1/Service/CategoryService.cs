using ConsoleApp1.Database;
using ConsoleApp1.exception;
using ConsoleApp1.Models;
using ConsoleApp1.Service;
namespace ConsoleApp1.Services;

public class CategoryService: BaseService
{
    public CategoryService(ShopDb shopDb) : base(shopDb)
    {
    }

    public void AddCategory(Category category)
    {
        var idCheck = _shopDb.categories.Any(c => c.Id == category.Id);
        if (idCheck)
        {
            throw new Exception("Bu Id artiq movcuddur");
        }
        _shopDb.categories.Add(category);
    }

    public List<Category> GetAllCategories()
    {
        return _shopDb.categories;
    }

    public void RemoveCategory(int categoryId)
    {
        var category = _shopDb.categories.FirstOrDefault(c => c.Id == categoryId);

        if (category != null)
        {
            _shopDb.categories.Remove(category);
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!");
        }
    }

    public Category CategoryUpdate(Category category)
    {
        var existingCategory = _shopDb.categories.FirstOrDefault(c => c.Id == category.Id);

        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            return existingCategory;
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!");
            
        }
    }

    public Category CategoryGetById(int categoryId)
    {
        var category = _shopDb.categories.FirstOrDefault(c => c.Id == categoryId);

        if (category != null)
        {
            return category;
        }
        else
        {
            throw new NotFoundException("Bele category movcud deyil!"); 
        }
    }
}
