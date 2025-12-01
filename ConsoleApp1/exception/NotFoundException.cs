namespace ConsoleApp1.exception;

class NotFoundException:Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
