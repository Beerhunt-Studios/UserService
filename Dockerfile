# Starting from MS's dotnet image that has all the SDKs installed,
# build and unit test the app
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

# ENV Variables
ARG SERVICE_NAME
ENV SERVICE_NAME=${SERVICE_NAME}

ARG NUGET_PASSWORD
ENV NUGET_PASSWORD=${NUGET_PASSWORD}

COPY . /

RUN dotnet nuget add source https://nuget.pkg.github.com/Beerhunt-Studios/index.json --name="Docker-Compose" --username "useless" --password ${NUGET_PASSWORD} --store-password-in-clear-text

RUN dotnet restore ${SERVICE_NAME}.sln

# Build
RUN dotnet build --configuration Release --no-restore $SERVICE_NAME.sln

# Create dotnet artifacts
RUN dotnet publish --no-restore -c Release --output /app $SERVICE_NAME.sln

# Build the deployment container. Switch base images from 'sdk' to
# 'runtime', and use Apline Linux, to reduce image size
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime


# ENV Variables
ARG SERVICE_NAME
ENV SERVICE_NAME=${SERVICE_NAME}
ENV \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8

RUN apk add --no-cache \
    icu-data-full \
    icu-libs

# Set up the app to run
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT dotnet $SERVICE_NAME.Api.dll