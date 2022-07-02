FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS publish
WORKDIR /src
COPY ["Service/Service.csproj", "Service/"]
RUN dotnet restore "Service/Service.csproj" --runtime alpine-x64
COPY . .
WORKDIR "/src/Service"

RUN dotnet publish "Service.csproj" -c Release -o /app/publish \
    -- runtime alpine-x64 \
    -- self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine AS final

RUN adduser --disabled-password \
    --home /app \
    --gecos '' dotnetuser && chown -R dotnetuser /app 

USER dotnetuser
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .

ENTRYPOINT ["./Service"]
