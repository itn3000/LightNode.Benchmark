if(-Not(Test-Path "nancy-results"))
{
    mkdir "nancy-results"
}
for($i=0;$i -lt 5;$i++)
{
    & .\ab.exe -n 100000 -c 10 -k -w http://localhost:10006/Hello/Echo?name=hoge > "nancy-results/result${i}.html" 
    Start-Sleep 1
}
