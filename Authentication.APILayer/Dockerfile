#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV AuthenticationApiDbDocker="Data Source=192.168.1.179,1433,1433;Initial Catalog = AuthenticationAPI;Persist Security Info=True;User ID=sa;Password=Admin@1234; TrustServerCertificate=True;"                                                           
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Authentication.APILayer/Authentication.APILayer.csproj", "Authentication.APILayer/"]
COPY ["JwtAuthenticationManager/JwtAuthenticationManager.csproj", "JwtAuthenticationManager/"]
RUN dotnet restore "Authentication.APILayer/Authentication.APILayer.csproj"
COPY . .
WORKDIR "/src/Authentication.APILayer"
RUN dotnet build "Authentication.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.APILayer.dll"]