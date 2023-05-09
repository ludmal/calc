using Calculator.Api.Operations;
using FluentValidation;

namespace Calculator.Api.Validators;

public class OperationRequestValidator : AbstractValidator<CalculatorOperationRequest>
{
    public OperationRequestValidator()
    {
        RuleFor(a => a.Num1).Must(x => x > 0)
            .WithMessage("Invalid Number.");
        
        RuleFor(a => a.Num2).Must(x => x > 0)
            .WithMessage("Invalid Number.");
    }
}