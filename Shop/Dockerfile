FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2 AS build
WORKDIR /src
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
COPY ["EntityLayer/EntityLayer.csproj", "EntityLayer/"]
RUN dotnet restore "Shop/Shop.csproj"
COPY . .
WORKDIR "/src/Shop"
RUN dotnet build "Shop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop.dll"]
