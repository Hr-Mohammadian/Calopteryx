using System.Net;

namespace Calopteryx.BuildingBlocks.Infrastructures.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message)
        : base(message, null, HttpStatusCode.NotFound)
    {
    }
}