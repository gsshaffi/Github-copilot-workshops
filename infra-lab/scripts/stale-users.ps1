<#
.SYNOPSIS
    Find stale user accounts using Microsoft Graph API.

.DESCRIPTION
    ** THIS IS A STUB ** — use Copilot to build this out!
    
    The script should:
    1. Connect to Microsoft Graph API
    2. Query all users who have not signed in for N days
    3. Export: DisplayName, Email, LastSignIn, Department, JobTitle
    4. Output to CSV
    5. Optionally disable the stale accounts

    In Copilot Chat (Agent Mode), try:
    "Build out this PowerShell script based on the description in 
     the comments. Use Microsoft Graph PowerShell SDK. Add proper
     error handling, a -WhatIf mode, and parameter validation."
#>

param(
    [int]$DaysInactive = 90,
    [string]$OutputFile = "stale-users.csv",
    [switch]$DisableAccounts,
    [switch]$WhatIf
)

# TODO: Use Copilot to implement this script
# Start by typing a comment describing the first step:
# # Connect to Microsoft Graph with the required scopes
