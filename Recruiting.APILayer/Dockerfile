#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV RecruitingApiDbDocker="Data Source=192.168.1.179,1433;Initial Catalog = RecruitingApiDb;Persist Security Info=True;User ID=sa;Password=Admin@1234; TrustServerCertificate=True;"
ENV RecruitingApiAzure="Server=tcp:recruitingdbysun.database.windows.net,1433;Initial Catalog=RecruitingDB;Persist Security Info=False;User ID=ysun;Password=Admin@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Recruiting.APILayer/Recruiting.APILayer.csproj", "Recruiting.APILayer/"]
COPY ["Recruiting.Infrastruction/Recruiting.Infrastruction.csproj", "Recruiting.Infrastruction/"]
COPY ["Recruiting.ApplicationCore/Recruiting.ApplicationCore.csproj", "Recruiting.ApplicationCore/"]
RUN dotnet restore "Recruiting.APILayer/Recruiting.APILayer.csproj"
COPY . .
WORKDIR "/src/Recruiting.APILayer"
RUN dotnet build "Recruiting.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recruiting.APILayer.dll"]