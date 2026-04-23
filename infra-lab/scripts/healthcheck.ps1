<#
.SYNOPSIS
    Server health check script for Connells infrastructure.
    
.DESCRIPTION
    Checks CPU, memory, disk space, and top processes.
    ** THIS SCRIPT HAS BUGS ** — use GitHub Copilot to find and fix them!

.NOTES
    There are at least 4 bugs in this script. Can you find them all?
#>

param(
    [string]$ComputerName = $env:COMPUTERNAME,
    [int]$CpuThreshold = 80,
    [int]$MemoryThreshold = 85,
    [int]$DiskThreshold = 10,
    [string]$OutputPath = ""
)

function Get-CpuUsage {
    # BUG 1: This returns a string, not a number — comparison will fail
    $cpu = Get-CimInstance -ClassName Win32_Processor | 
        Select-Object -ExpandProperty LoadPercentage |
        Measure-Object -Average |
        Select-Object -ExpandProperty Average
    return "$cpu%"
}

function Get-MemoryUsage {
    $os = Get-CimInstance -ClassName Win32_OperatingSystem
    $total = $os.TotalVisibleMemorySize
    $free = $os.FreePhysicalMemory
    # BUG 2: Division is the wrong way round — gives free percentage, not used
    $used = [math]::Round(($free / $total) * 100, 2)
    return $used
}

function Get-DiskSpace {
    # BUG 3: The Where-Object filter uses the wrong property name
    $disks = Get-CimInstance -ClassName Win32_LogicalDisk |
        Where-Object { $_.Type -eq 3 } |
        Select-Object DeviceID, 
            @{Name="SizeGB"; Expression={[math]::Round($_.Size / 1GB, 2)}},
            @{Name="FreeGB"; Expression={[math]::Round($_.FreeSpace / 1GB, 2)}},
            @{Name="FreePercent"; Expression={[math]::Round(($_.FreeSpace / $_.Size) * 100, 2)}}
    return $disks
}

function Get-TopProcesses {
    param([int]$Count = 5)
    # BUG 4: Sorting by WorkingSet but displaying WS — property name mismatch in output
    $procs = Get-Process | 
        Sort-Object -Property WorkingSet -Descending |
        Select-Object -First $Count -Property Name, Id, 
            @{Name="MemoryMB"; Expression={[math]::Round($_.WS64 / 1MB, 2)}},
            @{Name="CPU_Seconds"; Expression={[math]::Round($_.CPU, 2)}}
    return $procs
}

# ── Main Execution ──────────────────────────────────────

Write-Host "`n===== Server Health Check: $ComputerName =====" -ForegroundColor Cyan
Write-Host "Time: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')`n"

# CPU Check
$cpuUsage = Get-CpuUsage
Write-Host "CPU Usage: $cpuUsage"
if ($cpuUsage -gt $CpuThreshold) {
    Write-Host "  ⚠ WARNING: CPU usage exceeds $CpuThreshold% threshold!" -ForegroundColor Yellow
}

# Memory Check
$memUsage = Get-MemoryUsage
Write-Host "Memory Usage: $memUsage%"
if ($memUsage -gt $MemoryThreshold) {
    Write-Host "  ⚠ WARNING: Memory usage exceeds $MemoryThreshold% threshold!" -ForegroundColor Yellow
}

# Disk Check
Write-Host "`nDisk Space:"
$disks = Get-DiskSpace
$disks | Format-Table -AutoSize
foreach ($disk in $disks) {
    if ($disk.FreePercent -lt $DiskThreshold) {
        Write-Host "  ⚠ WARNING: $($disk.DeviceID) has less than $DiskThreshold% free space!" -ForegroundColor Yellow
    }
}

# Top Processes
Write-Host "Top 5 Processes by Memory:"
Get-TopProcesses | Format-Table -AutoSize

# Export if path specified
if ($OutputPath -ne "") {
    $results = @{
        Timestamp   = Get-Date -Format 'yyyy-MM-dd HH:mm:ss'
        Computer    = $ComputerName
        CpuUsage    = $cpuUsage
        MemoryUsage = $memUsage
        Disks       = $disks
    }
    $results | ConvertTo-Json | Out-File -FilePath $OutputPath
    Write-Host "`nResults exported to $OutputPath" -ForegroundColor Green
}
