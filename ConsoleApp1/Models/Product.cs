namespace ConsoleApp1.Models;

public class Product: BaseModel
{
    public Product(int id, string? name, decimal price, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}
