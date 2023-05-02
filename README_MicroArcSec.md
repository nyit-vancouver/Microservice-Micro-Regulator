# MicroArcSech

## ✔️Output
https://microarcsecportal.azurewebsites.net/


## ✔️ Features
- This dashboat can read logs that Uses eBPF to capture data. 🐝
- This dashboard can deserialize yaml file to the model and save it in your local server.
- visualise SIGMA rules that can be used with various security information and event management (SIEM) system with diagram and charts.
-This Dashboard use visual aids such as charts, graphs, and tables to make it easier to understand and interpret the log with yalm format.

## ✔️ Technologies
- ASP.Net Core 6
- Blazor Server
- Grpc
- Sigma Rule
- SignalR
- Blazor Radzan
- Azure

The final purpose of this project is to find a best solution for small and medium size projects to manage the security and maintenance issues with microservices.
At the first phase we are going to implement a prototype with monitoring and setting security policies for host machine features. 
- Real-Time Data: display real-time data on Dashboard, allowing users to monitor performance and track logs over time.
- User-Friendly Design: Dashboards is  designed with a clear layout that makes . easy to navigate and understand the data.
- Mobile-Friendly: Dashboard is optimized for mobile devices.

## ✔️ How to use
This application could receive SigmaRule log files through gRPC. we have sampple applicatio that send log file to the portal application via this protocol that you can download it at this repository nyit-vancouver/SendFileRep.

It is open source. So feel free to download and use this code. we will be happy to get feedcback from you to improve our product.

## ✔️ TODO
- Alerting and notifications: The dashboard should provide alerts and notifications when certain eBPF metrics exceed defined thresholds, helping users quickly identify and address issues.
- adding DrillDown reports


