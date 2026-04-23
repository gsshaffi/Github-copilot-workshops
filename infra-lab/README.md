# Connells GitHub Copilot Lab — Infrastructure Track

A hands-on lab repo for the **Infrastructure, Platform & DevOps** teams at Connells Group.
Use this repo with the GitHub Copilot workshop lab guide.

## What's Inside

```
infra-lab/
├── terraform/
│   ├── main.tf              # Partial config — complete with Copilot
│   ├── variables.tf          # Some variables defined, some missing
│   ├── outputs.tf            # Empty — generate with Copilot
│   └── modules/
│       └── networking/
│           └── main.tf       # Intentionally incomplete module
├── scripts/
│   ├── healthcheck.ps1       # Has bugs — debug with Copilot
│   ├── disk-cleanup.ps1      # Working script — extend with Copilot
│   ├── deploy.sh             # Bash script — convert to PowerShell
│   └── stale-users.ps1       # Stub — build out with Copilot
├── pipelines/
│   ├── azure-pipelines.yml   # Incomplete — finish with Copilot
│   ├── Dockerfile            # Has issues — fix with Copilot
│   └── docker-compose.yml    # Partial — complete with Copilot
├── docs/
│   └── runbook-template.md   # Stub — generate with Copilot
└── README.md
```

## Prerequisites

- VS Code with GitHub Copilot extension
- GitHub account with Copilot Free activated
- No cloud accounts needed — all exercises are local

## How to Use

1. Clone this repo
2. Open in VS Code
3. Follow the lab guide exercises
4. Use Copilot to complete, fix, and extend the code!
