using System.Net;

namespace ToDoList.Exceptions;

public class ApiException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message;
}