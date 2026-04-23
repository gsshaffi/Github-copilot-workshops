# GitHub Copilot Hands-On Workshop

Welcome! This repo contains everything you need for the **GitHub Copilot Hands-On Workshop**. It's designed to give you real, practical experience using GitHub Copilot across both **developer** and **infrastructure** scenarios.

---

## What's in This Repo

```
github-copilot-labs/
├── README.md                       ← You are here
├── copilot-github-labs.html        ← Lab guide (step-by-step exercises)
├── copilot-github-workshop.html    ← Interactive workshop guide
│
├── dev-lab/                        ← Developer Track
│   ├── src/                        # .NET 8 Property API (incomplete — finish with Copilot)
│   │   ├── Program.cs              # Minimal API setup with TODOs
│   │   ├── Controllers/            # API controller with missing endpoints
│   │   ├── Models/                 # Property model needing validation
│   │   ├── Services/               # Services with bugs to find and fix
│   │   └── Data/                   # Sample property data
│   ├── tests/                      # Empty test file — generate tests with Copilot
│   ├── legacy/                     # Legacy code to convert (JavaScript + VB.NET → C#)
│   ├── sql/                        # Database schema + stub queries
│   ├── docs/                       # API spec stub — generate docs with Copilot
│   └── README.md                   # Dev track details
│
└── infra-lab/                      ← Infrastructure Track
    ├── terraform/                  # Partial Terraform config — complete with Copilot
    │   ├── main.tf                 # Resource group, VNet, NSGs (has TODOs)
    │   ├── variables.tf            # Some variables missing
    │   ├── outputs.tf              # Empty — generate with Copilot
    │   └── modules/networking/     # Intentionally incomplete module
    ├── scripts/                    # PowerShell & Bash scripts to fix/extend
    │   ├── healthcheck.ps1         # Has bugs — debug with Copilot
    │   ├── disk-cleanup.ps1        # Working script — extend it
    │   ├── deploy.sh               # Bash → convert to PowerShell
    │   └── stale-users.ps1         # Stub — build out with Copilot
    ├── pipelines/                  # CI/CD configs to complete
    │   ├── azure-pipelines.yml     # Incomplete pipeline
    │   ├── Dockerfile              # Has issues — fix with Copilot
    │   └── docker-compose.yml      # Partial config
    ├── docs/                       # Runbook template stub
    └── README.md                   # Infra track details
```

---

## Getting Started

### Prerequisites

| Requirement | Details |
|---|---|
| **VS Code** | [Download](https://code.visualstudio.com/) |
| **GitHub Copilot Extension** | Install from the VS Code Extensions marketplace |
| **GitHub Account** | With Copilot Free (or higher) activated |
| **.NET 8 SDK** *(Dev Track only)* | [Download](https://dotnet.microsoft.com/download) — optional, exercises work without running code |

### Setup

1. **Clone this repo**
   ```bash
   git clone https://github.com/gsshaffi/Github-copilot-workshops.git
   cd Github-copilot-workshops
   ```

2. **Open in VS Code**
   ```bash
   code .
   ```

3. **Verify Copilot is active** — look for the Copilot icon in the bottom status bar

4. **Open the lab guide** — start with `copilot-github-labs.html` in your browser for step-by-step exercises

---

## Choose Your Track

### 🛠️ Developer Track (`dev-lab/`)

For **software engineers and developers**. You'll work with a .NET 8 Property API and use Copilot to:

- **Complete code** — fill in missing endpoints and API registrations
- **Fix bugs** — find and fix issues in the PropertyService
- **Refactor** — clean up messy code in ValuationService
- **Generate tests** — create a full unit test suite from an empty file
- **Convert legacy code** — transform JavaScript and VB.NET into modern C#
- **Write SQL** — generate queries from a database schema
- **Generate docs** — create API documentation from code

### 🏗️ Infrastructure Track (`infra-lab/`)

For **infrastructure, platform, and DevOps engineers**. You'll use Copilot to:

- **Complete Terraform** — finish a partial Azure infrastructure config
- **Debug scripts** — find and fix bugs in PowerShell scripts
- **Extend scripts** — add features to working automation scripts
- **Convert scripts** — translate Bash to PowerShell
- **Build CI/CD** — complete Azure Pipelines, Dockerfile, and docker-compose configs
- **Write runbooks** — generate operational documentation

---

## Tips for the Workshop

- **Let Copilot lead** — start typing a comment describing what you want, then let Copilot suggest the code
- **Use Copilot Chat** — press `Ctrl+I` (inline) or open the Chat panel to ask questions about the code
- **Try `/tests`** — in Copilot Chat, use `/tests` to auto-generate unit tests
- **Select code + ask** — highlight code and ask Copilot Chat to explain, refactor, or fix it
- **Experiment!** — there's no wrong answer; the goal is to explore what Copilot can do

---

## Need Help?

- Check the individual track READMEs in `dev-lab/README.md` and `infra-lab/README.md` for detailed file descriptions
- Open `copilot-github-labs.html` in your browser for the full guided lab exercises
- Ask your workshop facilitator for support
