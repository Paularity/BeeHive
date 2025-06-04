FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app

COPY . .

ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "HiveService.API.dll"]
