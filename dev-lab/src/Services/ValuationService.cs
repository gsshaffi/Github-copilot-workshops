using Connells.PropertyApi.Models;

namespace Connells.PropertyApi.Services;

/// <summary>
/// Valuation calculator — this code is deliberately messy.
/// Exercise: Ask Copilot to refactor this class for readability, 
/// extract magic numbers, and improve the calculation logic.
/// </summary>
public class ValuationService
{
    // Messy method — ask Copilot to refactor
    public decimal CalculateValuation(Property p)
    {
        decimal v = 0;

        // base price by type
        if (p.Type == PropertyType.Detached) v = 350000;
        else if (p.Type == PropertyType.SemiDetached) v = 250000;
        else if (p.Type == PropertyType.Terraced) v = 180000;
        else if (p.Type == PropertyType.EndOfTerrace) v = 195000;
        else if (p.Type == PropertyType.Flat) v = 150000;
        else if (p.Type == PropertyType.Bungalow) v = 280000;
        else if (p.Type == PropertyType.Maisonette) v = 200000;
        else if (p.Type == PropertyType.Cottage) v = 300000;

        // bedrooms
        v = v + (p.Bedrooms * 25000);

        // bathrooms
        v = v + (p.Bathrooms * 15000);

        // square footage adjustment
        if (p.SquareFootage > 0) { v = v * (1 + ((p.SquareFootage - 800) / 10000)); }

        // garden
        if (p.HasGarden) v = v + 20000;

        // parking
        if (p.HasParking) v = v + 15000;

        // EPC rating
        if (p.EpcRating == "A") v = v * 1.08m;
        else if (p.EpcRating == "B") v = v * 1.05m;
        else if (p.EpcRating == "C") v = v * 1.02m;
        else if (p.EpcRating == "D") v = v * 1.0m;
        else if (p.EpcRating == "E") v = v * 0.97m;
        else if (p.EpcRating == "F") v = v * 0.93m;
        else if (p.EpcRating == "G") v = v * 0.88m;

        // age adjustment  — BUG: doesn't handle null YearBuilt
        var age = DateTime.Now.Year - p.YearBuilt.Value;
        if (age < 5) v = v * 1.1m;
        else if (age < 20) v = v * 1.0m;
        else if (age < 50) v = v * 0.95m;
        else v = v * 0.9m;

        // town premium (hardcoded — very messy)
        if (p.Town.ToLower() == "london" || p.Town.ToLower() == "reading" || p.Town.ToLower() == "oxford")
            v = v * 1.4m;
        else if (p.Town.ToLower() == "milton keynes" || p.Town.ToLower() == "cambridge" || p.Town.ToLower() == "bristol")
            v = v * 1.2m;
        else if (p.Town.ToLower() == "birmingham" || p.Town.ToLower() == "manchester" || p.Town.ToLower() == "leeds")
            v = v * 1.1m;

        return Math.Round(v, -3); // round to nearest thousand
    }

    // TODO: Use Copilot to extract the magic numbers into a configuration class
    // TODO: Use Copilot to replace the if/else chains with dictionaries or switch expressions
    // TODO: Use Copilot to add a CompareToMarket method that takes a Property and returns
    //       whether it's overpriced, underpriced, or fair based on the valuation
    // TODO: Use Copilot to add XML documentation to this class
}
