param(
  [string]$Project = "ProyectoCronoVianda.Web",
  [string]$StartupProject = "ProyectoCronoVianda.Web",
  [string]$Context = "ApplicationDbContext"
)

$ErrorActionPreference = "Stop"

function Assert-CommandExists {
  param([string]$Command)
  $cmd = Get-Command $Command -ErrorAction SilentlyContinue
  if (-not $cmd) {
    throw "No se encontró el comando '$Command'. Instalá el .NET SDK y asegurate de tenerlo en PATH."
  }
}

function Assert-LocalDbInstalled {
  $localDbCmd = Get-Command "sqllocaldb" -ErrorAction SilentlyContinue
  if (-not $localDbCmd) {
    throw "No se encontró 'sqllocaldb'. Falta SQL Server Express LocalDB. Instalalo y volvé a ejecutar este script."
  }
}

Assert-CommandExists "dotnet"

Assert-LocalDbInstalled

Write-Host "Restaurando dependencias..."
dotnet restore

Write-Host "Aplicando migraciones (crea/actualiza la BD según appsettings.json)..."
dotnet ef database update --project $Project --startup-project $StartupProject --context $Context

Write-Host "OK. Base de datos creada/actualizada."
