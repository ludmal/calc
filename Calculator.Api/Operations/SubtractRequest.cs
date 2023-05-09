using MediatR;

namespace Calculator.Api.Operations;

public sealed record SubtractRequest : CalculatorOperationRequest;
public sealed class SubtractRequestHandler : IRequestHandler<SubtractRequest, CalculatorOperationResponse>
{
    private readonly ILogger<SubtractRequestHandler> _logger;

    public SubtractRequestHandler(ILogger<SubtractRequestHandler> logger)
    {
        _logger = logger;
    }

    public Task<CalculatorOperationResponse> Handle(SubtractRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request received for subtract operation {@Request}", request);
        return Task.FromResult(new CalculatorOperationResponse(request.Num1-request.Num2));
    }
}