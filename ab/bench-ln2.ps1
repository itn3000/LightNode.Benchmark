if(-Not(Test-Path "ln2-results"))
{
    mkdir "ln2-results"
}
for($i=0;$i -lt 5;$i++)
{
    & .\ab.exe -n 100000 -c 10 -k -w http://localhost:10005/Hello/Echo?name=hoge > "ln2-results/result${i}.html" 
    Start-Sleep 1
}
