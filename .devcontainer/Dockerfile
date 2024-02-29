# didn't work with -jammy
FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

# install bluez related packages
RUN apt-get update && apt-get install -y \
    bluez \
    dbus \
    sudo

# setup bluetooth permissions
COPY ./bluezuser.conf /etc/dbus-1/system.d/