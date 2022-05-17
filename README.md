# PVE Auto Connect VM

## Command Info

```bash
pveAutoConnectVM 1.1.2
Copyright (C) 2021 Weiting

  -h, --host        Required. Server Url.

  --port            Server Port. like 443

  -u, --username    Required. Your account.

  -p, --password    Required. Your password.

  -d, --debugger    Show detail message.

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
