using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce_API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);
// Add Core Layer
builder.Services.AddCore();


// Add Controllers with JSON options to handle enum as string in JSON
// Example:  "Gender":"Male" and receive it in GenderOptions enum
builder.Services.AddControllers().AddJsonOptions(
    (idx) => {
        idx.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


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

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
