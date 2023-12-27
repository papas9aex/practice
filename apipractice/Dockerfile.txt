FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PracticeApi/PracticeApi.csproj", "PracticeApi/"]
RUN dotnet restore "PracticeApi/PracticeApi.csproj"
COPY . .
WORKDIR "/src/PracticeApi"
RUN dotnet build "PracticeApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

COPY ["TestProject1/TestProject1.csproj", "TestProject1/"]
RUN dotnet restore "TestProject1/TestProject1.csproj"
COPY . .
WORKDIR "/src/TestProject1"
RUN dotnet build "TestProject1.csproj" -c $BUILD_CONFIGURATION -o /app/tests

RUN dotnet test --logger "xunit;LogFilePath=testresults.trx" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/ /p:Threshold=80 /p:ThresholdType=line

RUN allure generate ./TestResults/ -o /app/allure-results

FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
COPY --from=build /app/allure-results /app/allure-results
ENTRYPOINT ["dotnet", "PracticeApi.dll"]
