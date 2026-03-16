using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SkynetBooking.Application.Common.AppRequests;

public record AppResponse
{
    [JsonIgnore]
    public int StatusCode { get; init; }

    public string Message { get; init; }

    public IDictionary<string, string[]> Errors { get; init; } = new Dictionary<string, string[]>();

    public AppResponse(int statusCode, string message = "")
    {
        StatusCode = statusCode;
        Message = message;
    }

    public static AppResponse CreateBadRequest(IDictionary<string, string[]> errors)
    {
        return new(statusCode: 400)
        {
            Errors = errors
        };
    }
}

public record AppResponse<T> : AppResponse
{
    public T? Content { get; init; }

    public AppResponse(int statusCode, T? content = default, string message = "") :
        base(statusCode, message)
    {
        Content = content;
    }

    public new static AppResponse<T> CreateBadRequest(IDictionary<string, string[]> errors)
    {
        return new(statusCode: 400)
        {
            Errors = errors
        };
    }
}
