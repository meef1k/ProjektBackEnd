FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Spedition.csproj", "./"]
RUN dotnet restore "Spedition.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Spedition.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Spedition.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Spedition.dll"]
