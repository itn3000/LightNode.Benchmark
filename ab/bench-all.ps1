$scriptDir = $(Split-Path -Parent $MyInvocation.MyCommand.Path)
Set-Location $scriptDir

Start-Process dotnet.exe -ArgumentList "restore" -WorkingDirectory ../
Start-Process dotnet.exe -ArgumentList "build **/project.json" -WorkingDirectory ../

$arg = 'run'
$proc = Start-Process dotnet.exe -ArgumentList $arg -WorkingDirectory ../LightNode1.Sample -PassThru
Start-Sleep 10
& ./bench-ln1.ps1
# Stop-Process $proc does not work?
Invoke-WebRequest http://localhost:10003/Hello/Terminate

$proc = Start-Process dotnet.exe -ArgumentList $arg -WorkingDirectory ../LightNode2.Sample -PassThru
Start-Sleep 10
& ./bench-ln2.ps1
Invoke-WebRequest http://localhost:10005/Hello/Terminate

$proc = Start-Process dotnet.exe -ArgumentList $arg -WorkingDirectory ../AspNetCoreMvcSample -PassThru
Start-Sleep 10
& ./bench-mvc.ps1
# if error occured on this Invoke-WebRequest,you should ignore.
Invoke-WebRequest http://localhost:10004/Hello/Terminate
