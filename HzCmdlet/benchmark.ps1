param(
    [string] $clientVersion = $(throw "-clientVersion is required."),
    [int] $count = 100000,
    [String] $address = "127.0.0.1:5701"
)

Import-Module ./$clientVersion/HzCmdlet.dll -Force

$client = New-HazelcastClient -address $address

$clearTime = Get-HzMap -Client $client -mapName default -Operation CLEAR

Write-Host "Results ............................."
$fillTime = Get-HzMap -Client $client -mapName default -Operation FILL -Count $count
Write-Host "FILL            :${fillTime}"
$size , $sizeTime = Get-HzMap -Client $client -mapName default -Operation SIZE
Write-Host "SIZE            :${size}"
$getAllTime = Get-HzMap -Client $client -mapName default -Operation GETALL -Count $count
Write-Host "GETALL          :${getAllTime}"
$getAllThreadTime = Get-HzMap -Client $client -mapName default -Operation GETALL-WITH-THREADS -Count $count -ThreadCount 25
Write-Host "GETALL-THREAD   :${getAllThreadTime}"
$queryTime = Get-HzMap -Client $client -mapName default -Operation QUERY
Write-Host "QUERY           :${queryTime}"

$client.Shutdown()

#Remove-Module ./$clientVersion/HzCmdlet.dll -Force
