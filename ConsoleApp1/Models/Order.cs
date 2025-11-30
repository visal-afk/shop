namespace ConsoleApp1.Models;

public class Order:BaseModel
{
    private Product product;

    public Order(int id, Product product)
    {
        Id = id;
        this.product = product;
    }

    public List<Product> Products{get; set;}
    public decimal TotalAmount { get; set; }
    public object Product { get; internal set; }
}
