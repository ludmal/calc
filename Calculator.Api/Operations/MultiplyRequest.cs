using MediatR;

namespace Calculator.Api.Operations;

public sealed record MultiplyRequest : CalculatorOperationRequest;

public sealed class MultiplyRequestHandler : IRequestHandler<MultiplyRequest, CalculatorOperationResponse>
{
    private readonly ILogger<MultiplyRequestHandler> _logger;

    public MultiplyRequestHandler(ILogger<MultiplyRequestHandler> logger)
    {
        _logger = logger;
    }

    public Task<CalculatorOperationResponse> Handle(MultiplyRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request received for multiply operation {@Request}", request);
        return Task.FromResult(new CalculatorOperationResponse(request.Num1*request.Num2));
    }
}