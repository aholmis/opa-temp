$ErrorActionPreference = "Stop"

.\build\opa.exe test .\rules -v

if($LASTEXITCODE -ne 0)
{
    write-error "Test failure detected."
}