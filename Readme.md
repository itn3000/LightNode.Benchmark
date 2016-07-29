# LightNode.Benchmark

this solution contains the benchmarking projects for [LightNode](https://github.com/neuecc/LightNode)

# Requirements

* Windows 8.1 or later(64bit) 
* [VC11 Redistributable package for ab.exe(Apatch Bench)](https://www.microsoft.com/en-us/download/details.aspx?id=30679)
* [dotnet commandline utility(dotnet-cli)](https://www.microsoft.com/net)
* Powershell 3.0 or later

# Usage

1. change directory to ab
2. execute `powershell.exe bench-all.ps1`
3. see results in the following directories
    * ln1-results: LightNode-1.6.3+WebListener benchmarking results(html)
    * ln2-results: LightNode-2.0.1-beta+Kestrel benchmarking results(html)
    * mvc-results: ASP.NET MVC Core-1.0.0+Kestrel benchmarking results(html)

# Warning

this benchmarking use the 10003-10005/tcp ports for serving http server,
so you must not use these ports by other programs.

# Customizing programs

if you want to cusomize benchmarking,open LightNode.Benchmark.sln with VS2015 Update3 or later.