cls

# Pasta onde o relat�rio ser� gerado
$baseDirectory = Join-Path -Path (Get-Location) -ChildPath ""
$projectTestPath = Join-Path -Path (Get-Location) -ChildPath "PixCharge.Test"
$sourceDirs = "$baseDirectory\PixCharge.Domain;$baseDirectory\PixCharge.Infrastructure;$baseDirectory\PixCharge.Repository;$baseDirectory\PixCharge.SPA"
$reportPath = Join-Path -Path (Get-Location) -ChildPath "PixCharge.Test\TestResults"
$coverageXmlPath = Join-Path -Path (Join-Path -Path $projectTestPath -ChildPath "TestResults") -ChildPath "coveragereport"
$filefilters = "$projectPath\PixCharge.Infrastructure.Migrations_MsSqlServer\**;$projectPath\PixCharge.Infrastructure.Migrations_MySqlServer\**;"
# Fun��o para matar processos com base no nome do processo que estajam em execu��o 
function Stop-ProcessesByName {
    $processes = Get-Process | Where-Object { $_.ProcessName -like 'dotnet*' } | Where-Object { $_.MainWindowTitle -eq '' }
    if ($processes.Count -gt 0) {
        $processes | ForEach-Object { Stop-Process -Id $_.Id -Force }
    }
}


function Remove-TestResults {    
    if (Test-Path $reportPath) {
        Remove-Item -Recurse -Force $reportPath
    }
}

 function Wait-TestResults {
    $REPEAT_WHILE = 0
    while (-not (Test-Path $reportPath)) {
        echo "Agaurdando TestResults..."
        Start-Sleep -Seconds 5        
        if ($REPEAT_WHILE -eq 10) { break }
        $REPEAT_WHILE = $REPEAT_WHILE + 1
    }

    $REPEAT_WHILE = 0
    while (-not (Test-Path $coverageXmlPath)) {
        echo "Agaurdando Coverage Report..."
        Start-Sleep -Seconds 5        
        if ($REPEAT_WHILE -eq 5) { break }
        $REPEAT_WHILE = $REPEAT_WHILE + 1
    }   

 } 

Stop-ProcessesByName
Remove-TestResults
dotnet clean slnPixCharge.sln > $null 2>&1
$watchProcess = Start-Process "dotnet" -ArgumentList "watch", "test", "--project ./PixCharge.Test/PixCharge.Test.csproj", "--collect:""XPlat Code Coverage;Format=opencover""", "/p:CollectCoverage=true", "/p:CoverletOutputFormat=cobertura" -PassThru
 Wait-TestResults
 Invoke-Item $coverageXmlPath\index.html
$watchProcess.WaitForExit()
Stop-ProcessesByName; 
Exit 