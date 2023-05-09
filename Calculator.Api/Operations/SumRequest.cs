using MediatR;

namespace Calculator.Api.Operations;

public sealed record SumRequest : CalculatorOperationRequest;

public sealed class SumRequestHandler : IRequestHandler<SumRequest, CalculatorOperationResponse>
{
    private readonly ILogger<SumRequestHandler> _logger;

    public SumRequestHandler(ILogger<SumRequestHandler> logger)
    {
        _logger = logger;
    }

    public Task<CalculatorOperationResponse> Handle(SumRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request received for sum operation {@Request}", request);
        return Task.FromResult(new CalculatorOperationResponse(request.Num1+request.Num2));
    }
}