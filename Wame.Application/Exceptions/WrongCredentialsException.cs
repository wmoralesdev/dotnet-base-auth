namespace Wame.Application.Exceptions;

public class WrongCredentialsException : HttpException
{
    public WrongCredentialsException() : base("Wrong credentials", 401)
    {
    }
}