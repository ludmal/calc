using Calculator.Api.Operations;
using MediatR;

namespace Calculator.Api.Endpoints.V1;

public static class CalculatorEndpoint
{
    public static async Task<IResult> Sum(HttpContext context, IMediator mediator, 
        [AsParameters] SumRequest request) =>
        Results.Ok(await mediator.Send(request));

    public static async Task<IResult> Divide(HttpContext context, IMediator mediator,
        [AsParameters] DivideRequest request) =>
        Results.Ok(await mediator.Send(request));

    public static async Task<IResult> Subtract(HttpContext context, IMediator mediator,
        [AsParameters] SubtractRequest request) =>
        Results.Ok(await mediator.Send(request));

    public static async Task<IResult> Multiply(HttpContext context, IMediator mediator,
        [AsParameters] MultiplyRequest request) =>
        Results.Ok(await mediator.Send(request));
}