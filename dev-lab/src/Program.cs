// Connells Property API — Minimal API setup
// TODO: Use Copilot to add the missing endpoint registrations

using Connells.PropertyApi.Services;
using Connells.PropertyApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPropertyService, PropertyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Health check
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

// TODO: Use Copilot to register endpoints from PropertyController
// Hint: Map GET /api/properties, GET /api/properties/{id}, POST, PUT, DELETE

app.Run();
