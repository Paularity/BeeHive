# BeeHive Management Web App

This repository contains a demo skeleton for the BeeHive management application using Angular and .NET microservices.

## Structure

- `client` – Angular application with Auth0 integration.
- `server/HiveService` – .NET 9 service exposing hive APIs.
- `server/Gateway` – YARP gateway securing all API calls.
- `docker` – Docker compose configuration.

## Auth0 Configuration

Set the following environment variables before running the services:

- `AUTH0_DOMAIN`
- `AUTH0_AUDIENCE`
- `AUTH0_CLIENT_ID` (for the frontend)

These variables are consumed by the Angular app and the microservices to validate tokens.

## Docker

Run the stack using Docker Compose:

```bash
docker compose -f docker/docker-compose.yml up
```

This will start the gateway and hive service on the internal `kaiju-net` network.
