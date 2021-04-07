.\build\opa.exe test .\rules --format=pretty -c --threshold 100

if($LASTEXITCODE -ne 0)
{
    "##teamcity[buildStatus status='FAILURE' text='{build.status.text}: Test(s) failed, or test coverage too low.']"
}