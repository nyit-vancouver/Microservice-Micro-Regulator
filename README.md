# Vigilant Guard 🛡️
VigilantGuard is a lightweight security monitoring service that uses Go and eBPF to produce SIGMA rules with a communication module to collect logs in distributed environments. The primary purpose of VigilantGuard is to mitigate microservice architecture risks by collecting standard SIGMA rules. ✅

This repository is based on [VigilantGuard](https://github.com/Arsh1101/VigilantGuard) project. 📌

To set up your server you can change the configuration of gRPC. The default configuration setting is `localhost:50051` located in the communication module.

Whenever you need to use this app use the 'make' command to create the executable file and run it under the **root** privilege.

This application stores logs in the `/var/log/vigilant-guard/` location.

## Features
- Uses eBPF to capture data. 🐝
- Produces SIGMA rules that can be used with various security information and event management (SIEM) systems. ✔️
- Supports communication between multiple instances in a distributed environment to collect logs (using gRPC). 📡
- Lightweight and designed for microservice architectures. ⚡
- Uses Golang to implement the logic. 🐹
