FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o Peppermint.ReverseProxy

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/Peppermint.ReverseProxy .
ENTRYPOINT ["dotnet", "Peppmermint.ReverseProxy.dll"]