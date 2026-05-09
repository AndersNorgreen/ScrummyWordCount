
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS dev

WORKDIR /

COPY Source/ScrummyWordCountApi.sln .
COPY Source/ScrummyWordCountApi/ScrummyWordCountApi.csproj ScrummyWordCountApi/

COPY Source/ScrummyWordCountApiTests/ScrummyWordCountApiTests.csproj ScrummyWordCountApiTests/

RUN dotnet restore ScrummyWordCountApi.sln

RUN dotnet tool install --global dotnet-watch
ENV PATH="$PATH:/root/.dotnet/tools"

EXPOSE 5012

CMD ["dotnet", "watch", "run", "--project", "Source/ScrummyWordCountApi/ScrummyWordCountApi.csproj", "--urls", "http://0.0.0.0:5012"]
