set CLIENT=../client/Assets

dotnet ./Luban/Luban.dll ^
    -t all ^
    -c cs-bin ^
    -d bin  ^
    -d json ^
    --conf ./luban.conf ^
    -x bin.outputDataDir=%CLIENT%/StreamingAssets/tables ^
    -x json.outputDataDir=./json-output ^
    -x outputCodeDir=%CLIENT%/Scripts/Tables/CodeGen
pause