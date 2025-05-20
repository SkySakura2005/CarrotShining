set LUBAN_DLL=Luban\Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t all ^
    -c cs-simple-json ^
    -d json ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=Assets\Scripts\GameDatabase ^
    -x outputDataDir=Assets\StreamingAssets\JsonData

pause