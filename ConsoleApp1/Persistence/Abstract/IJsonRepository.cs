namespace ConsoleApp1.Persistence.Abstract;

public interface IJsonRepository<T>
{
    void SaveData(List<T> items);
    List<T> LoadData();
}