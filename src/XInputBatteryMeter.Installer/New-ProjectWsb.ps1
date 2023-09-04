[CmdletBinding()]
param(
  [Parameter(HelpMessage = 'Start the Add/Remove Programs control panel')]
  [switch]$StartAddRemovePrograms,
  [Parameter(HelpMessage = 'Start the Services.msc snap-in')]
  [switch]$StartServices,
  [Parameter(HelpMessage = 'Start Windows Explorer in the project folder')]
  [switch]$StartExplorerInProject,
  [Parameter(HelpMessage = 'Start Windows Explorer in the "Program Files" folder')]
  [switch]$StartExplorerInProgramFiles,
  [Parameter(HelpMessage = 'Start Windows Explorer in the "Program Files (x86)" folder')]
  [switch]$StartExplorerInProgramFilesX86,
  [Parameter(HelpMessage = 'Start the Registry Editor')]
  [switch]$StartRegedit
)

$SOLUTION_NAME = 'XInputBatteryMeter.sln'
$PROJECT_NAME = [IO.Path]::GetFileNameWithoutExtension($SOLUTION_NAME)
$SANDBOX_FOLDER = "C:\$PROJECT_NAME"


if ($MyInvocation.BoundParameters.Keys.Count -eq 0) {
  Write-Host -ForegroundColor Yellow 'By default, will start Add/Remove Programs, Windows Explorer in the project folder, and Windows Explorer in the "Program Files" folder.'
  $StartAddRemovePrograms = $true
  $StartServices = $false
  $StartExplorerInProject = $true
  $StartExplorerInProgramFiles = $true
  $StartExplorerInProgramFilesX86 = $false
  $StartRegedit = $false
}

function Get-RepoRoot {
  if (!(Get-Command git.exe -ErrorAction SilentlyContinue)) {
    Write-Error 'Git command not found. Please install Git for Windows.'
    return
  }

  if (!(git rev-parse --is-inside-work-tree)) {
    Write-Error 'Please run this script from within the repository.'
    return
  }

  return [IO.Path]::GetFullPath((git rev-parse --show-toplevel))
}

function Get-DirName {
  [CmdletBinding()]
  param(
    [Parameter(Mandatory = $true, HelpMessage = 'The path to a file or directory', ValueFromPipeline = $true)]
    [string]$Path
  )

  return [IO.Path]::GetFullPath($Path) | Split-Path -Leaf
}

function New-ProjectWsb {
  $RepoPath = Get-RepoRoot

  if (![IO.Path]::Exists([IO.Path]::Combine($RepoPath, 'XInputBatteryMeter.sln'))) {
    Write-Error 'Please run this script from the XInputBatteryMeter repository.'
    return
  }

  $ProjectPath = [IO.Path]::GetFullPath($PSScriptRoot)
  $ProjectRelPath = [IO.Path]::GetRelativePath($RepoPath, $ProjectPath)

  $OutputFilename = "$($ProjectRelPath | Get-DirName).wsb"
  $OutputFullname = [IO.Path]::Combine($ProjectPath, $OutputFilename)

  $LogonScriptFilename = "$OutputFilename.start.cmd"
  $LogonScriptRelPath = [IO.Path]::Combine($ProjectRelPath, $LogonScriptFilename)
  $LogonScriptFullname = [IO.Path]::Combine($ProjectPath, $LogonScriptFilename)

  @"
<Configuration>
  <MappedFolders>
    <MappedFolder>
      <HostFolder>$RepoPath</HostFolder>
      <SandboxFolder>$SANDBOX_FOLDER</SandboxFolder>
    </MappedFolder>
  </MappedFolders>
  <LogonCommand>
    <Command>$SANDBOX_FOLDER\$LogonScriptRelPath</Command>
  </LogonCommand>
</Configuration>
"@ | Out-File -FilePath $OutputFullname -Encoding UTF8

  Write-Host -ForegroundColor Green "$OutputFullname created."

  $LogonCommand = ''
  if ($StartAddRemovePrograms) {
    $LogonCommand += "start appwiz.cpl`n"
  }
  if ($StartServices) {
    $LogonCommand += "start services.msc`n"
  }
  if ($StartExplorerInProject) {
    $SandboxProjectPath = [IO.Path]::GetFullPath([IO.Path]::Combine($SANDBOX_FOLDER, $ProjectRelPath))
    $LogonCommand += "start `"`" `"$SandboxProjectPath`" `n"
  }
  if ($StartExplorerInProgramFiles) {
    $LogonCommand += "start `"`" `"%ProgramFiles%`"`n"
  }
  if ($StartExplorerInProgramFilesX86) {
    $LogonCommand += "start `"`" `"%ProgramFiles(x86)%`"`n"
  }
  if ($StartRegedit) {
    $LogonCommand += "start regedit`n"
  }

  $LogonCommand | Out-File -FilePath $LogonScriptFullname -Encoding UTF8

  Write-Host -ForegroundColor Green "$LogonScriptFullname created."
}

New-ProjectWsb