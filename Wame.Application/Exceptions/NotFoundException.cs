namespace Wame.Application.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string? message) : base(message, 404)
    {
    }
}