using MediatR;

namespace Calculator.Api.Operations;

public record CalculatorOperationRequest : IRequest<CalculatorOperationResponse>
{
    public decimal Num1 { get; set; }
    public decimal Num2 { get; set; }
}