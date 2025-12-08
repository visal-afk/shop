namespace ConsoleApp1.Services.Abstract;

public interface IService<T>
{
    public void Add(T item);
    public void Delete(int id);
    public T Update(T item);
    public List<T> GetAll();
    public T GetById(int id);

}
