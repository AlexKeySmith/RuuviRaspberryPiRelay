# didn't work with -jammy
FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

#avoids when doing sudo dmesg | grep -i bluetooth
# [27316.755372] Bluetooth: hci0: BCM: firmware Patch file not found, tried:
# [27316.755380] Bluetooth: hci0: BCM: 'brcm/BCM20702A1-0a5c-21e8.hcd'
COPY ./sources.list /etc/apt/sources.list

# install bluez related packages
RUN apt-get update && apt-get install -y \
    bluez-firmware \
    bluez \
    dbus \
    sudo



# setup bluetooth permissions
COPY ./bluezuser.conf /etc/dbus-1/system.d/