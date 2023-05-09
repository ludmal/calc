using MediatR;

namespace Calculator.Api.Operations;

public sealed record DivideRequest : CalculatorOperationRequest;

public sealed class DivideRequestHandler : IRequestHandler<DivideRequest, CalculatorOperationResponse>
{
    private readonly ILogger<DivideRequestHandler> _logger;

    public DivideRequestHandler(ILogger<DivideRequestHandler> logger)
    {
        _logger = logger;
    }

    public Task<CalculatorOperationResponse> Handle(DivideRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request received for divide operation {@Request}", request);

        return request.Num2 > 0
            ? Task.FromResult(new CalculatorOperationResponse(request.Num1 / request.Num2))
            : throw new DivideByZeroException();
    }
}