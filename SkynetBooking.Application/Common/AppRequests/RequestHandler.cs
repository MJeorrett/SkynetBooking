using FluentValidation;

namespace SkynetBooking.Application.Common.AppRequests;

public abstract class RequestHandler<TRequest, TResult>
{
    public abstract Task<AppResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken);

    public async Task<AppResponse<TResult>> Handle(TRequest request, IValidator<TRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return AppResponse<TResult>.CreateBadRequest(validationResult.ToDictionary());
        }

        return await Handle(request, cancellationToken);
    }
}

public abstract class RequestHandler<TRequest>
{
    public abstract Task<AppResponse> Handle(TRequest request, CancellationToken cancellationToken);

    public async Task<AppResponse> Handle(TRequest request, IValidator<TRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return AppResponse.CreateBadRequest(validationResult.ToDictionary());
        }

        return await Handle(request, cancellationToken);
    }
}
