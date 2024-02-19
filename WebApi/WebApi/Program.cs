using WebApi.Interfaces;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>();

// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Currency API", Version = "v1" });
// });

builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// app.MapGet("/", () => "Hello World!");

app.Run();

// TODO: Make swagger work :')

// TODO: Create service for reaching endpoint

// TODO: Make Controller

// TODO:Use awesome keywords to make the API user friendly with Swagger UI
