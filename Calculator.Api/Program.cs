using System.Net.Http.Headers;
using System.Reflection;
using AutoMapper;
using MediatR;
using Polly;
using Polly.Extensions.Http;
using Calculator.Api.Endpoints.V1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("api/sum", CalculatorEndpoint.Sum);
app.MapGet("api/divide", CalculatorEndpoint.Divide);
app.MapGet("api/subtract", CalculatorEndpoint.Subtract);
app.MapGet("api/multiply", CalculatorEndpoint.Multiply);

app.Run();