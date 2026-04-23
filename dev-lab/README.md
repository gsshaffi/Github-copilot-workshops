# Connells GitHub Copilot Lab — Developer Track

A hands-on lab repo for **Software Developers & Product Engineering** teams at Connells Group.
Use this repo with the GitHub Copilot workshop lab guide.

## What's Inside

```
dev-lab/
├── src/
│   ├── Models/
│   │   └── Property.cs           # Model with missing validation
│   ├── Services/
│   │   ├── PropertyService.cs    # Has bugs and needs refactoring
│   │   ├── ValuationService.cs   # Messy code — refactor with Copilot
│   │   └── IPropertyService.cs   # Interface stub
│   ├── Controllers/
│   │   └── PropertyController.cs # Incomplete API controller
│   ├── Data/
│   │   └── SampleData.cs         # Sample property data
│   └── Program.cs                # Minimal API setup
├── tests/
│   └── PropertyServiceTests.cs   # Empty — generate with Copilot
├── legacy/
│   ├── old-calculator.js         # Legacy JS — convert to C#/TS
│   └── data-export.vb            # VB.NET — convert to C#
├── sql/
│   ├── schema.sql                # Database schema
│   └── queries.sql               # Stub queries — write with Copilot
├── docs/
│   └── api-spec.md               # Stub — generate with Copilot
├── Connells.PropertyApi.csproj   # Project file
└── README.md
```

## Prerequisites

- VS Code with GitHub Copilot extension
- GitHub account with Copilot Free activated
- .NET 8 SDK (optional — you can still do the exercises without running the code)

## How to Use

1. Clone this repo
2. Open in VS Code
3. Follow the lab guide exercises
4. Use Copilot to complete, fix, test, and document the code!
