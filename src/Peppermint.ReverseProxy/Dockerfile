#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Peppermint.ReverseProxy/Peppermint.ReverseProxy.csproj", "src/Peppermint.ReverseProxy/"]
RUN dotnet restore "src/Peppermint.ReverseProxy/Peppermint.ReverseProxy.csproj"
COPY . .
WORKDIR "/src/src/Peppermint.ReverseProxy"
RUN dotnet build "Peppermint.ReverseProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Peppermint.ReverseProxy.csproj" -c Release --runtime linux-x64 --self-contained true -p:PublishReadyToRun=true -o /app/publish

FROM alpine:latest as alp
WORKDIR /app

FROM alp AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Peppermint.ReverseProxy.dll"]