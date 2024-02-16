using Microsoft.OpenApi.Models;
using WebApi;
using WebApi.Interfaces;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>();
builder.Services.AddTransient<ExchangeRateService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Currency API", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Currency API V1");
});

app.MapGet("/", () => "Hello World!");

app.Run();

// TODO: Create service for reaching endpoint

// TODO: Make Controller

// TODO:Use awesome keywords to make the API user friendly with Swagger UI