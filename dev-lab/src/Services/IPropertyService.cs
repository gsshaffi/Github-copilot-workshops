using Connells.PropertyApi.Models;

namespace Connells.PropertyApi.Services;

public interface IPropertyService
{
    IEnumerable<Property> GetAll();
    Property? GetById(int id);
    Property Add(Property property);
    Property? Update(int id, Property property);
    bool Delete(int id);

    // TODO: Use Copilot to add method signatures for:
    //   - Search(string? town, decimal? minPrice, decimal? maxPrice, int? minBeds, PropertyType? type)
    //   - GetStatistics() — returns average price, total listings, price by type, etc.
    //   - GetByPostcodeArea(string postcodePrefix)
}
