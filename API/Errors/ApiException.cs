namespace API.Errors;

public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string message = null,string deatails=null) : base(statusCode, message)
    {
        Details = deatails;
    }

    public string Details { get; set; }
}