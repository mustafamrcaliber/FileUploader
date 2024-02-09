#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 82b8a672-746b-48ed-a8e2-edbf65db267d -t
    fi
    cd ../
fi

docker-compose up -d
