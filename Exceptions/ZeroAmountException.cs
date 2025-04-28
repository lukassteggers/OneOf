namespace OneOfExample.Exceptions;

public class ZeroAmountException : Exception
{
    public ZeroAmountException()
    {
        
    }

    public ZeroAmountException(string message) : base(message)
    {
        
    }

    public ZeroAmountException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}