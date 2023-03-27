#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV OnboardingApiDbDocker="Data Source=192.168.1.179,1433,1433;Initial Catalog = OnboardingApiDb;Persist Security Info=True;User ID=sa;Password=Admin@1234; TrustServerCertificate=True;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Onboarding.APILayer/Onboarding.APILayer.csproj", "Onboarding.APILayer/"]
COPY ["Onboarding.Infrastruction/Onboarding.Infrastruction.csproj", "Onboarding.Infrastruction/"]
COPY ["Onboarding.AppliactionCore/Onboarding.AppliactionCore.csproj", "Onboarding.AppliactionCore/"]
RUN dotnet restore "Onboarding.APILayer/Onboarding.APILayer.csproj"
COPY . .
WORKDIR "/src/Onboarding.APILayer"
RUN dotnet build "Onboarding.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding.APILayer.dll"]