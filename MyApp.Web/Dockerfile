FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyApp.Web/MyApp.Web.csproj", "MyApp.Web/"]
COPY ["MyApp.Services/MyApp.Services.csproj", "MyApp.Services/"]
COPY ["MyApp.Data/MyApp.Data.csproj", "MyApp.Data/"]
COPY ["MyApp.Contracts/MyApp.Contracts.csproj", "MyApp.Contracts/"]
COPY ["MyApp.Tests/MyApp.Tests.csproj", "MyApp.Tests/"]
RUN dotnet restore "MyApp.Web/MyApp.Web.csproj"
COPY . .
WORKDIR "/src/MyApp.Web"
RUN dotnet build "MyApp.Web.csproj" -c Release -o /app

RUN dotnet test "../MyApp.Tests/MyApp.Tests.csproj" -c Release --logger:trx

FROM build AS publish
RUN dotnet publish "MyApp.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyApp.Web.dll"]