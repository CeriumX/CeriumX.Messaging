@echo off
@title 自动创建解决方案及各隶属项目

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- 解决方案 ----------

dotnet new sln -n CRS2TBBT4CeriumX.Messaging





@echo.
@echo.
@echo.
@echo\&echo  ---------- 示例程序 & samples 3 ----------

dotnet new console -lang C# -f net6.0 -n CeriumX.Messaging.Bootstrapper -o samples/CeriumX.Messaging.Bootstrapper/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Bootstrapper/src

dotnet new blazorserver -lang C# -f net6.0 -n CeriumX.Messaging.Appx4BlazorServer -o samples/CeriumX.Messaging.Appx4BlazorServer/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Appx4BlazorServer/src

dotnet new blazorwasm -lang C# -f net6.0 -n CeriumX.Messaging.Appx4BlazorWasm -o samples/CeriumX.Messaging.Appx4BlazorWasm/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Appx4BlazorWasm/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 接口抽象 ﹫ Abstractions 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Abstractions -o CeriumX.Messaging.Abstractions/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add --in-root CeriumX.Messaging.Abstractions/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- 消息队列服务总线 ﹫ ServiceBus 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus -o ServiceBus/CeriumX.Messaging.ServiceBus/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- 本地消息队列 ﹫ LocalMQ 2 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQ -o LocalMQ/CeriumX.Messaging.LocalMQ/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQ/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQPlus -o LocalMQ/CeriumX.Messaging.LocalMQPlus/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQPlus/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- MQTT消息队列 ﹫ MQTT 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT -o MQTT/CeriumX.Messaging.MQTT/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- RabbitMQ消息队列 ﹫ RabbitMQ 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ -o RabbitMQ/CeriumX.Messaging.RabbitMQ/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- Kafka消息队列 ﹫ Kafka 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka -o Kafka/CeriumX.Messaging.Kafka/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka/src





::@echo\&echo 所有项目自动创建工作已结束，600 秒后将自动退出本自动创建程序。
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo 所有项目自动创建完毕，请按任意键退出。
pause>nul 
exit
