cmd /c npm install -g nswag
cmd /c npm install
cmd /c webpack --config webpack.config.vendor.js 
cmd /c dotnet restore
cmd /c dotnet build
cmd /c dotnet publish
REM cmd /c nswag run