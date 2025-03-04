
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    // Add behaviors to pipeline
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
// Add validators
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(
    opt => opt.Connection(builder.Configuration.GetConnectionString("Database")!)
).UseLightweightSessions();
var app = builder.Build();
// logic to handle exception in DI (IServiceCollection)
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
// Kích hoạt Carter để xử lý các module
app.MapCarter();
// This exception handling middleware
app.UseExceptionHandler(options => { });
app.Run();
