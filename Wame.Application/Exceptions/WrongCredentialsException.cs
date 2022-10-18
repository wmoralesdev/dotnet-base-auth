namespace Wame.Application.Exceptions;

public class WrongCredentialsException : Exception
{
    public WrongCredentialsException() : base("Wrong credentials")
    {
    }
}