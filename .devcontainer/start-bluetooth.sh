#Inspired by https://medium.com/omi-uulm/how-to-run-containerized-bluetooth-applications-with-bluez-dced9ab767f6


#!/bin/bash
# start services
sudo service dbus start
sudo service bluetooth start

# wait for startup of services
msg="Waiting for services to start..."
time=0
echo -n $msg
while [[ "$(pidof bluetoothd)" != "" ]]; do
    sleep 1
    time=$((time + 1))
    echo -en "\r$msg $time s"
done
echo -e "\r$msg done! (in $time s)"

# reset bluetooth adapter by restarting it
# sudo hciconfig hci0 down
# sudo hciconfig hci0 up

#bluetoothctl only works after taking out and putting back in bluetooth adaptor.



#btmgmt and btmon works?!