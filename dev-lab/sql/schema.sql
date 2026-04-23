-- Connells Property Database Schema
-- Exercise: Use Copilot to review, optimise, and extend this schema

CREATE TABLE Properties (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Address NVARCHAR(200) NOT NULL,
    Postcode VARCHAR(10) NOT NULL,
    Town NVARCHAR(100) NOT NULL,
    County NVARCHAR(100),
    Price DECIMAL(12,2) NOT NULL,
    Bedrooms INT NOT NULL,
    Bathrooms INT NOT NULL,
    PropertyType VARCHAR(20) NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Available',
    SquareFootage FLOAT,
    ListedDate DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    Description NVARCHAR(MAX),
    AgentNotes NVARCHAR(MAX),
    HasGarden BIT NOT NULL DEFAULT 0,
    HasParking BIT NOT NULL DEFAULT 0,
    YearBuilt INT,
    EpcRating CHAR(1),
    -- TODO: Use Copilot to add proper indexes for common query patterns
    -- TODO: Use Copilot to add CHECK constraints for valid values
    -- TODO: Use Copilot to add CreatedAt, UpdatedAt, CreatedBy audit columns
);

-- TODO: Use Copilot to create a Valuations table
-- Should reference Properties, include ValuationDate, EstimatedValue, ValuerId, Notes

-- TODO: Use Copilot to create a Viewings table
-- Should reference Properties, include ViewingDate, ClientName, ClientEmail, AgentName, Status

-- TODO: Use Copilot to create an Agents table
-- Should include AgentId, Name, Email, Phone, Branch, HireDate

-- TODO: Use Copilot to add foreign key relationships between tables
