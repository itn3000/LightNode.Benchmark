if(-Not(Test-Path "ln1-results"))
{
    mkdir "ln1-results"
}
for($i=0;$i -lt 5;$i++)
{
    & .\ab.exe -n 100000 -c 10 -k -w http://localhost:10003/Hello/Echo?name=hoge > "ln1-results/result${i}.html" 
    Start-Sleep 1
}
