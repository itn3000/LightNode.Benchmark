if(-Not(Test-Path "mvc-results"))
{
    mkdir "mvc-results"
}
for($i=0;$i -lt 5;$i++)
{
    & .\ab.exe -n 100000 -c 10 -k -w http://localhost:10004/Hello/Echo?name=hoge > "mvc-results/result${i}.html" 
    Start-Sleep 1
}
