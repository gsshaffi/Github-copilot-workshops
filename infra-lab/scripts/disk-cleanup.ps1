<#
.SYNOPSIS
    Cleans up old files and temporary data on Windows servers.

.DESCRIPTION
    A working script that deletes temp files older than a specified number of days.
    
    ** EXERCISE: Use Copilot to extend this script with additional features **
    
    Suggested extensions:
    - Add log file cleanup (IIS logs, event logs)
    - Add Windows Update cleanup
    - Add recycling bin cleanup  
    - Add a -WhatIf mode for dry runs
    - Add email notification when cleanup completes
    - Add a summary report with space reclaimed
#>

param(
    [int]$DaysOld = 30,
    [switch]$Force
)

$ErrorActionPreference = "Continue"
$totalFreed = 0

function Remove-OldFiles {
    param(
        [string]$Path,
        [int]$Days,
        [string]$Label
    )
    
    if (-not (Test-Path $Path)) {
        Write-Host "  [$Label] Path not found: $Path" -ForegroundColor Gray
        return 0
    }

    $cutoff = (Get-Date).AddDays(-$Days)
    $files = Get-ChildItem -Path $Path -Recurse -File -ErrorAction SilentlyContinue |
        Where-Object { $_.LastWriteTime -lt $cutoff }
    
    $sizeBytes = ($files | Measure-Object -Property Length -Sum).Sum
    $count = $files.Count

    if ($count -gt 0) {
        $files | Remove-Item -Force -ErrorAction SilentlyContinue
        $sizeMB = [math]::Round($sizeBytes / 1MB, 2)
        Write-Host "  [$Label] Removed $count files ($sizeMB MB)" -ForegroundColor Green
        return $sizeBytes
    } else {
        Write-Host "  [$Label] No files older than $Days days" -ForegroundColor Gray
        return 0
    }
}

# ── Main Execution ──────────────────────────────────────

Write-Host "`n===== Disk Cleanup: Files older than $DaysOld days =====" -ForegroundColor Cyan
Write-Host "Time: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')`n"

# Windows Temp
$totalFreed += Remove-OldFiles -Path "$env:TEMP" -Days $DaysOld -Label "User Temp"
$totalFreed += Remove-OldFiles -Path "C:\Windows\Temp" -Days $DaysOld -Label "System Temp"

# Downloads (be careful — only remove if -Force is set)
if ($Force) {
    $totalFreed += Remove-OldFiles -Path "$env:USERPROFILE\Downloads" -Days $DaysOld -Label "Downloads"
} else {
    Write-Host "  [Downloads] Skipped — use -Force to include" -ForegroundColor Yellow
}

# Summary
$totalMB = [math]::Round($totalFreed / 1MB, 2)
Write-Host "`n===== Total space reclaimed: $totalMB MB =====" -ForegroundColor Cyan

# TODO: Use Copilot to extend this script!
# Open Copilot Chat and try:
# "Add IIS log cleanup, Windows Update cleanup, and a -WhatIf dry run mode to this script"
