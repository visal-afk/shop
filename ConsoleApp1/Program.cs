using ConsoleApp1.Service;
using ConsoleApp1.Database;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

ShopDb shopDb = new ShopDb();
ProductService productService = new ProductService(shopDb);
CategoryService categoryService = new CategoryService(shopDb);
OrderService orderService = new OrderService(shopDb);
while (true)
{
    Console.WriteLine("1.Add Category \n2.Get All Categories\n3.Update Category\n4.Delete category \n5.Get category by id\n6.Add Product\n" +
        "7.Get all products\n8. Update product\n9.Delete product\n10.get product by id\n11.Add oreder \n12.Get All orders\n13.Update order\n14.Delete order \n15.Get order by id");
    int choice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter your choice:");
    Console.WriteLine("-----------------------");
    if (choice == 1)
    {
        Console.WriteLine("Enter category id:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter category name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter category description:");
        string description = Console.ReadLine();
        Category category = new Category(id, name, description);
        categoryService.AddCategory(category);
        Console.WriteLine("Category added ");
    }
    else if (choice == 2)
    {
        var categories = categoryService.GetAllCategories();
        foreach (var category in categories)
        {
            Console.WriteLine($"Id: {category.Id}, Name: {category.Name}, Description: {category.Description}");
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine("Enter category id to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter new category name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter new category description:");
        string description = Console.ReadLine();
        Category category = new Category(id, name, description);
        var updatedCategory = categoryService.CategoryUpdate(category);
        if (updatedCategory != null)
        {
            Console.WriteLine("Category updated");
        }
    }
    else if (choice == 4)
    {
        Console.WriteLine("Enter category id to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        categoryService.RemoveCategory(id);
        Console.WriteLine("Category deleted ");
    }
    else if (choice == 5)
    {
        Console.WriteLine("Enter category id to get:");
        int id = Convert.ToInt32(Console.ReadLine());
        var category = categoryService.CategoryGetById(id);
        if (category != null)
        {
            Console.WriteLine($"Id: {category.Id}, Name: {category.Name}, Description: {category.Description}");
        }
    }
    else if (choice == 6)
    {
        Console.WriteLine("Enter product id:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter product price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter product category id:");
        int categoryId = Convert.ToInt32(Console.ReadLine());
        var category = categoryService.CategoryGetById(categoryId);
        if (category != null)
        {
            Product product = new Product(id, name, price, category);
            productService.AddProduct(product);
            Console.WriteLine("Product added ");
        }
        else
        {
            Console.WriteLine("Category not found. Cannot add product.");
        }
    }
    else if (choice == 7)
    {
        var products = productService.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category.Name}");
        }
    }
    else if (choice == 8)
    {
        Console.WriteLine("Enter product id to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter new product name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter new product price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter new product category id:");
        int categoryId = Convert.ToInt32(Console.ReadLine());
        var category = categoryService.CategoryGetById(categoryId);
        if (category != null)
        {
            Product product = new Product(id, name, price, category);
            var updatedProduct = productService.ProductUpdate(product);
            if (updatedProduct != null)
            {
                Console.WriteLine("Product updated");
            }
        }
        else
        {
            Console.WriteLine("Category not found. Cannot update product.");
        }
    }
    else if (choice == 9)
    {
        Console.WriteLine("Enter product id to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        productService.RemoveProduct(id);
        Console.WriteLine("product deleted ");
    }
    else if (choice == 10)
    {
        Console.WriteLine("Enter product id to get:");
        int id = Convert.ToInt32(Console.ReadLine());
        var product = productService.ProductGetById(id);
        if (product != null)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category.Name}");
        }
    }
    else if (choice == 11)
    {
        Console.WriteLine("Enter order id:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter product id for the order:");
        int productId = Convert.ToInt32(Console.ReadLine());
        var product = productService.ProductGetById(productId);
        if (product != null)
        {
            Order order = new Order(id, product);
            orderService.AddOrder(order);
            Console.WriteLine("Order added ");
        }
        else
        {
            Console.WriteLine("Product not found. Cannot add order.");
        }
    }
    else if (choice == 12)
    {
        var orders = orderService.GetAllOrders();
        foreach (var order in orders)
        {
            Console.WriteLine($"Id: {order.Id}, Product: {order.Product}, Total amount{order.TotalAmount}");
        }
    }
    else if (choice == 13) 
    { 
        Console.WriteLine("Enter order id to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter new product id for the order:");
        int productId = Convert.ToInt32(Console.ReadLine());
        var product = productService.ProductGetById(productId);
        if (product != null)
        {
            Order order = new Order(id, product);
            var updatedOrder = orderService.OrderUpdate(order);
            if (updatedOrder != null)
            {
                Console.WriteLine("Order updated");
            }
        }
        else
        {
            Console.WriteLine("Product not found. Cannot update order.");
        }
    }
    else if (choice == 14)
    {
        Console.WriteLine("Enter order id to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        orderService.RemoveOrder(id);
        Console.WriteLine("order deleted ");
    }
    else if (choice == 15)
    {
        Console.WriteLine("Enter order id to get:");
        int id = Convert.ToInt32(Console.ReadLine());
        var order = orderService.OrderGetById(id);
        if (order != null)
        {
            Console.WriteLine($"Id: {order.Id}, Product: {order.Product}, Total amount{order.TotalAmount}");
        }
    }
    
}

