using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce_API.Middlewares;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

// Add Core Layer
builder.Services.AddCore();

// Add CORS Support
builder.Services.AddCors(idx => { 
    idx.AddDefaultPolicy(policy => 
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});

// Api Explorer
builder.Services.AddEndpointsApiExplorer();

// Add Swagger
builder.Services.AddSwaggerGen();

// Add Controllers with JSON options to handle enum as string in JSON
// Example:  "Gender":"Male" and receive it in GenderOptions enum
builder.Services.AddControllers().AddJsonOptions(
    (idx) => {
        idx.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Custom Exception Handling Middleware
app.UseExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwaggerUI(); // Interface to explore the API endpoints 

// CORS
app.UseCors(policy =>
{
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
