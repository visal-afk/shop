namespace ConsoleApp1.Models;

public class Category:BaseModel
{
    public Category(int id, string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
}
