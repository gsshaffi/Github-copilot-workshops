using Connells.PropertyApi.Models;

namespace Connells.PropertyApi.Data;

/// <summary>
/// Sample property data for the Connells Property API.
/// Realistic UK property listings across areas where Connells operates.
/// </summary>
public static class SampleData
{
    public static IEnumerable<Property> GetProperties()
    {
        return new List<Property>
        {
            new()
            {
                Id = 1,
                Address = "42 Riverside Walk",
                Postcode = "MK9 2FQ",
                Town = "Milton Keynes",
                County = "Buckinghamshire",
                Price = 425000,
                Bedrooms = 4,
                Bathrooms = 2,
                Type = PropertyType.Detached,
                Status = PropertyStatus.Available,
                SquareFootage = 1450,
                ListedDate = new DateTime(2024, 11, 15),
                Description = "Stunning modern detached home in the heart of Milton Keynes with open-plan living.",
                HasGarden = true,
                HasParking = true,
                YearBuilt = 2018,
                EpcRating = "B"
            },
            new()
            {
                Id = 2,
                Address = "7 Chapel Lane",
                Postcode = "OX1 3LR",
                Town = "Oxford",
                County = "Oxfordshire",
                Price = 650000,
                Bedrooms = 3,
                Bathrooms = 2,
                Type = PropertyType.SemiDetached,
                Status = PropertyStatus.Available,
                SquareFootage = 1100,
                ListedDate = new DateTime(2024, 12, 1),
                Description = "Character semi-detached property close to Oxford city centre.",
                HasGarden = true,
                HasParking = false,
                YearBuilt = 1935,
                EpcRating = "D"
            },
            new()
            {
                Id = 3,
                Address = "15 Station Road",
                Postcode = "RG1 4QP",
                Town = "Reading",
                County = "Berkshire",
                Price = 285000,
                Bedrooms = 2,
                Bathrooms = 1,
                Type = PropertyType.Flat,
                Status = PropertyStatus.UnderOffer,
                SquareFootage = 680,
                ListedDate = new DateTime(2024, 10, 20),
                Description = "Modern two-bedroom apartment with allocated parking, close to the station.",
                HasGarden = false,
                HasParking = true,
                YearBuilt = 2015,
                EpcRating = "B"
            },
            new()
            {
                Id = 4,
                Address = "3 The Green",
                Postcode = "CB2 1TN",
                Town = "Cambridge",
                County = "Cambridgeshire",
                Price = 550000,
                Bedrooms = 3,
                Bathrooms = 1,
                Type = PropertyType.Terraced,
                Status = PropertyStatus.Available,
                SquareFootage = 950,
                ListedDate = new DateTime(2025, 1, 5),
                Description = "Charming Victorian terrace in desirable Cambridge location.",
                HasGarden = true,
                HasParking = false,
                YearBuilt = 1890,
                EpcRating = "E"
            },
            new()
            {
                Id = 5,
                Address = "28 Oakwood Drive",
                Postcode = "NN3 8PL",
                Town = "Northampton",
                County = "Northamptonshire",
                Price = 310000,
                Bedrooms = 3,
                Bathrooms = 2,
                Type = PropertyType.SemiDetached,
                Status = PropertyStatus.SoldSTC,
                SquareFootage = 1050,
                ListedDate = new DateTime(2024, 9, 10),
                Description = "Well-presented semi in a popular residential area with good schools nearby.",
                HasGarden = true,
                HasParking = true,
                YearBuilt = 2005,
                EpcRating = "C"
            },
            new()
            {
                Id = 6,
                Address = "Flat 12, Harbour View",
                Postcode = "BS1 5QT",
                Town = "Bristol",
                County = "Bristol",
                Price = 375000,
                Bedrooms = 2,
                Bathrooms = 2,
                Type = PropertyType.Flat,
                Status = PropertyStatus.Available,
                SquareFootage = 780,
                ListedDate = new DateTime(2025, 1, 12),
                Description = "Luxury waterfront apartment with balcony and stunning harbour views.",
                HasGarden = false,
                HasParking = true,
                YearBuilt = 2020,
                EpcRating = "A"
            },
            new()
            {
                Id = 7,
                Address = "Rose Cottage, High Street",
                Postcode = "GL7 1AB",
                Town = "Cirencester",
                County = "Gloucestershire",
                Price = 485000,
                Bedrooms = 4,
                Bathrooms = 2,
                Type = PropertyType.Cottage,
                Status = PropertyStatus.Available,
                SquareFootage = 1300,
                ListedDate = new DateTime(2024, 11, 28),
                Description = "Quintessential Cotswold stone cottage with period features throughout.",
                HasGarden = true,
                HasParking = true,
                YearBuilt = 1820,
                EpcRating = "E"
            },
            new()
            {
                Id = 8,
                Address = "19 Willow Close",
                Postcode = "B15 2TT",
                Town = "Birmingham",
                County = "West Midlands",
                Price = 220000,
                Bedrooms = 3,
                Bathrooms = 1,
                Type = PropertyType.EndOfTerrace,
                Status = PropertyStatus.Available,
                SquareFootage = 870,
                ListedDate = new DateTime(2024, 12, 15),
                Description = "Great first-time buyer property with potential to extend (STPP).",
                HasGarden = true,
                HasParking = false,
                YearBuilt = 1960,
                EpcRating = "D"
            },
            new()
            {
                Id = 9,
                Address = "5 Meadow Lane",
                Postcode = "LU2 7HQ",
                Town = "Luton",
                County = "Bedfordshire",
                Price = 195000,
                Bedrooms = 1,
                Bathrooms = 1,
                Type = PropertyType.Maisonette,
                Status = PropertyStatus.ToLet,
                SquareFootage = 520,
                ListedDate = new DateTime(2025, 1, 8),
                Description = "Modern maisonette ideal for professionals, close to Luton Parkway station.",
                HasGarden = false,
                HasParking = true,
                YearBuilt = 2010,
                EpcRating = "C"
            },
            new()
            {
                Id = 10,
                Address = "The Beeches, Abington Park",
                Postcode = "NN1 4PA",
                Town = "Northampton",
                County = "Northamptonshire",
                Price = 575000,
                Bedrooms = 5,
                Bathrooms = 3,
                Type = PropertyType.Detached,
                Status = PropertyStatus.Available,
                SquareFootage = 2100,
                ListedDate = new DateTime(2024, 12, 20),
                Description = "Impressive five-bedroom family home backing onto Abington Park.",
                HasGarden = true,
                HasParking = true,
                YearBuilt = 1990,
                EpcRating = "C"
            }
        };
    }
}
