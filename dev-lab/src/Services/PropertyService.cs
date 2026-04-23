using Connells.PropertyApi.Models;
using Connells.PropertyApi.Data;

namespace Connells.PropertyApi.Services;

public class PropertyService : IPropertyService
{
    private readonly List<Property> _properties;

    public PropertyService()
    {
        _properties = SampleData.GetProperties().ToList();
    }

    public IEnumerable<Property> GetAll()
    {
        return _properties;
    }

    // BUG: This method doesn't handle negative IDs and will throw on empty list
    public Property? GetById(int id)
    {
        return _properties.First(p => p.Id == id);  // BUG: Should be FirstOrDefault
    }

    public Property Add(Property property)
    {
        // BUG: This doesn't generate a unique ID properly
        property.Id = _properties.Count + 1;  // BUG: What if items were deleted?
        property.ListedDate = DateTime.Now;     // BUG: Should use UtcNow
        _properties.Add(property);
        return property;
    }

    public Property? Update(int id, Property property)
    {
        var existing = GetById(id);
        if (existing == null) return null;

        // This works but is very verbose — ask Copilot to refactor
        existing.Address = property.Address;
        existing.Postcode = property.Postcode;
        existing.Town = property.Town;
        existing.County = property.County;
        existing.Price = property.Price;
        existing.Bedrooms = property.Bedrooms;
        existing.Bathrooms = property.Bathrooms;
        existing.Type = property.Type;
        existing.Status = property.Status;
        existing.SquareFootage = property.SquareFootage;
        existing.Description = property.Description;
        existing.AgentNotes = property.AgentNotes;
        existing.HasGarden = property.HasGarden;
        existing.HasParking = property.HasParking;
        existing.YearBuilt = property.YearBuilt;
        existing.EpcRating = property.EpcRating;

        return existing;
    }

    public bool Delete(int id)
    {
        var property = GetById(id);
        if (property == null) return false;
        return _properties.Remove(property);
    }

    // TODO: Implement Search method — use Copilot to write the LINQ query
    // Should support filtering by town, price range, min bedrooms, property type
    // All parameters are optional (filter only when provided)

    // TODO: Implement GetStatistics method
    // Return: TotalListings, AveragePrice, MedianPrice, PriceByType, CountByStatus, MostExpensiveTown

    // TODO: Implement GetByPostcodeArea — e.g. "MK" returns all Milton Keynes properties
}
