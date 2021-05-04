# PVE Auto Connect VM

## Command Info

```bash
pveAutoConnectVM 1.0.1
Copyright (C) 2021 Weiting

  -h, --host        Required. Server Url

  --port            Server Port [443]

  -u, --username    Required. Your account

  -p, --password    Required. Your password

  --help            Display this help screen.

  --version         Display version information.
```

## How to use

### dotnet

```bash
dotnet tool install --global pveAutoConnectVM

pveAutoConnectVM -h pve.local -u username -p password
```

### docker

```bash
docker run --rm a26007565/pveAutoConnectVM -h pve.local -u username -p password
```
