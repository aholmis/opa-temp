$ErrorActionPreference = "Stop"

.\build\opa.exe test .\rules -v --format=pretty

if($LASTEXITCODE -ne 0)
{
    ##teamcity[buildStatus status='FAILURE' text='{build.status.text}: Test(s) failed.']
    write-error "Test failure detected."
}