using AutoMapper;
using Calculator.Api.Operations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using Shouldly;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Tests;

public class HandlerTests
{
    private ILogger<SumRequestHandler> _SumRequestHandlerLogger;
    private ILogger<DivideRequestHandler> _DivideRequestHandlerLogger;
    private ILogger<MultiplyRequestHandler> _MultiplyRequestHandlerLogger;
    private ILogger<SubtractRequestHandler> _SubtractRequestHandlerLogger;
    private SumRequestHandler _SumRequestHandler;
    private DivideRequestHandler _DivideRequestHandler;
    private MultiplyRequestHandler _MultiplyRequestHandler;
    private SubtractRequestHandler _SubtractRequestHandler;

    [SetUp]
    public void Setup()
    {
        _SumRequestHandlerLogger = Substitute.For<ILogger<SumRequestHandler>>();
        _DivideRequestHandlerLogger = Substitute.For<ILogger<DivideRequestHandler>>();
        _MultiplyRequestHandlerLogger = Substitute.For<ILogger<MultiplyRequestHandler>>();
        _SubtractRequestHandlerLogger = Substitute.For<ILogger<SubtractRequestHandler>>();
        _SumRequestHandler = new SumRequestHandler(_SumRequestHandlerLogger);
        _DivideRequestHandler = new DivideRequestHandler(_DivideRequestHandlerLogger);
        _MultiplyRequestHandler = new MultiplyRequestHandler(_MultiplyRequestHandlerLogger);
        _SubtractRequestHandler = new SubtractRequestHandler(_SubtractRequestHandlerLogger);
    }

    [Test]
    public async Task SumRequest_WithValidValues_ValidResponse()
    {
        // Arrange
        var request = new SumRequest { Num1 = 2, Num2 = 3 };

        // Act
        var response = await _SumRequestHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.That(response.Value, Is.EqualTo(5));
    }

    [Test]
    public async Task DivideRequest_WithValidValues_ValidResponse()
    {
        // Arrange
        var request = new DivideRequest { Num1 = 4, Num2 = 2 };

        // Act
        var response = await _DivideRequestHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.That(response.Value, Is.EqualTo(2));
    }
    
    [Test]
    public async Task DivideRequest_WithZero_ShouldThrowZeroDivideException()
    {
        // Arrange
        var request = new DivideRequest { Num1 = 4, Num2 = 0 };

        // Act and Assert
        Assert.ThrowsAsync<DivideByZeroException>(() => _DivideRequestHandler.Handle(request, CancellationToken.None));

    }
    
    [Test]
    public async Task SubtractRequest_WithValidValues_ValidResponse()
    {
        // Arrange
        var request = new SubtractRequest { Num1 = 3, Num2 = 2 };

        // Act
        var response = await _SubtractRequestHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.That(response.Value, Is.EqualTo(1));
    }
    
    [Test]
    public async Task MultiplyRequest_WithValidValues_ValidResponse()
    {
        // Arrange
        var request = new MultiplyRequest { Num1 = 2, Num2 = 3 };

        // Act
        var response = await _MultiplyRequestHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.That(response.Value, Is.EqualTo(6));
    }
    
}