using Connells.PropertyApi.Models;
using Connells.PropertyApi.Services;

namespace Connells.PropertyApi.Controllers;

/// <summary>
/// Property API endpoints.
/// Some endpoints are implemented, some are stubs for Copilot to complete.
/// </summary>
public static class PropertyController
{
    public static void MapPropertyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/properties").WithTags("Properties");

        // GET all properties — working
        group.MapGet("/", (IPropertyService service) =>
        {
            var properties = service.GetAll();
            return Results.Ok(properties);
        });

        // GET property by ID — working but no error handling
        group.MapGet("/{id}", (int id, IPropertyService service) =>
        {
            var property = service.GetById(id);
            return Results.Ok(property);  // BUG: Returns 200 even if null — should return 404
        });

        // POST create property
        // TODO: Use Copilot to implement this endpoint
        // Should validate the property, add it via the service, and return 201 Created

        // PUT update property
        // TODO: Use Copilot to implement this endpoint
        // Should return 404 if not found, 200 with updated property if successful

        // DELETE property
        // TODO: Use Copilot to implement this endpoint
        // Should return 404 if not found, 204 No Content if successful

        // GET search — e.g. /api/properties/search?town=Reading&minPrice=200000&minBeds=3
        // TODO: Use Copilot to implement this endpoint with query parameters

        // GET statistics — /api/properties/stats
        // TODO: Use Copilot to implement this endpoint
    }
}
