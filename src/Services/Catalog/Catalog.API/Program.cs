﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(
    opt => opt.Connection(builder.Configuration.GetConnectionString("Database")!)
).UseLightweightSessions();
var app = builder.Build();

// Kích hoạt Carter để xử lý các module
app.MapCarter();
app.Run();
