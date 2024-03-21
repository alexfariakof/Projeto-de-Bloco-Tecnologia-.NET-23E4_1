$projectTestPath = Get-Location
$projectPath =  (Resolve-Path -Path ..).Path
$sourceDirs = "$projectPath\PixCharge.Api;$projectPath\PixCharge.Application;$projectPath\PixCharge.Domain;$projectPath\PixCharge.Repository;"
$reportPath = Join-Path -Path $projectTestPath -ChildPath "TestResults"
$coverageXmlPath = Join-Path -Path (Join-Path -Path $projectTestPath -ChildPath "TestResults") -ChildPath "coveragereport"
$filefilters = "-$projectPath\PixCharge.Infrastructure.Migrations_MsSqlServer\**;-$projectPath\PixCharge.Infrastructure.Migrations_MySqlServer\**;-$projectPath\PixCharge.Integration.Adapter\**;"

# Excuta Teste Unitarios sem restore e build e dera o relatório de cobertura 
dotnet test --results-directory $reportPath /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --collect:"XPlat Code Coverage;Format=opencover" --no-restore --no-build > $null 2>&1
reportgenerator -reports:$projectTestPath\coverage.cobertura.xml -targetdir:$coverageXmlPath -reporttypes:"Html;lcov;" -sourcedirs:$sourceDirs -filefilters:$filefilters


