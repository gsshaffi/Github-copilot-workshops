namespace Connells.PropertyApi.Models;

/// <summary>
/// Represents a property listing in the Connells system.
/// TODO: Use Copilot to add data annotations / validation attributes
/// </summary>
public class Property
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public PropertyType Type { get; set; }
    public PropertyStatus Status { get; set; }
    public double SquareFootage { get; set; }
    public DateTime ListedDate { get; set; }
    public string? Description { get; set; }
    public string? AgentNotes { get; set; }
    public bool HasGarden { get; set; }
    public bool HasParking { get; set; }
    public int? YearBuilt { get; set; }
    public string? EpcRating { get; set; }  // A, B, C, D, E, F, G

    // TODO: Use Copilot to add a method that calculates price per square foot

    // TODO: Use Copilot to add a method that returns a formatted listing summary
}

public enum PropertyType
{
    Detached,
    SemiDetached,
    Terraced,
    Flat,
    Bungalow,
    Maisonette,
    Cottage,
    EndOfTerrace
}

public enum PropertyStatus
{
    Available,
    UnderOffer,
    SoldSTC,
    Sold,
    Withdrawn,
    LetAgreed,
    ToLet
}

// TODO: Use Copilot to create a Valuation model with:
//   - PropertyId, ValuationDate, EstimatedValue, ValuerId, Notes, Confidence (Low/Medium/High)

// TODO: Use Copilot to create a Viewing model with:
//   - PropertyId, ViewingDate, ClientName, ClientEmail, AgentName, Feedback, Status (Scheduled/Completed/Cancelled)
