#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV InterviewApiDbDocker="Data Source=10.0.0.86,1433;Initial Catalog = InterviewApiDb;Persist Security Info=True;User ID=sa;Password=Admin@1234; TrustServerCertificate=True;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Interview.APILayer/Interview.APILayer.csproj", "Interview.APILayer/"]
COPY ["Interview.Infrastruction/Interview.Infrastruction.csproj", "Interview.Infrastruction/"]
COPY ["Interview.ApplicationCore/Interview.ApplicationCore.csproj", "Interview.ApplicationCore/"]
RUN dotnet restore "Interview.APILayer/Interview.APILayer.csproj"
COPY . .
WORKDIR "/src/Interview.APILayer"
RUN dotnet build "Interview.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.APILayer.dll"]