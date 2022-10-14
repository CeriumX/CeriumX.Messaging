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
@echo\&echo  ---------- 示例程序 & samples 4 ----------

dotnet new console -lang C# -f net6.0 -n CeriumX.Messaging.Bootstrapper -o samples/CeriumX.Messaging.Bootstrapper/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Bootstrapper/src

dotnet new blazorserver -lang C# -f net6.0 -n CeriumX.Messaging.Appx4BlazorServer -o samples/CeriumX.Messaging.Appx4BlazorServer/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Appx4BlazorServer/src

dotnet new blazorwasm -lang C# -f net6.0 -n CeriumX.Messaging.Appx4BlazorWasm -o samples/CeriumX.Messaging.Appx4BlazorWasm/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Appx4BlazorWasm/src

dotnet new wpf -lang "C#" -f net6.0 -n CeriumX.Messaging.Appx4WPF -o samples/CeriumX.Messaging.Appx4WPF/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s samples samples/CeriumX.Messaging.Appx4WPF/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 接口抽象 ﹫ Abstractions 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Abstractions -o CeriumX.Messaging.Abstractions/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add --in-root CeriumX.Messaging.Abstractions/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- 消息队列服务总线 ﹫ ServiceBus 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus -o ServiceBus/CeriumX.Messaging.ServiceBus/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus.GenericHost -o ServiceBus/CeriumX.Messaging.ServiceBus.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus.CeriumXHost -o ServiceBus/CeriumX.Messaging.ServiceBus.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- 本地消息队列 ﹫ LocalMQ 4 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQ -o LocalMQ/CeriumX.Messaging.LocalMQ/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQ/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQ.GenericHost -o LocalMQ/CeriumX.Messaging.LocalMQ.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQ.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQ.CeriumXHost -o LocalMQ/CeriumX.Messaging.LocalMQ.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQ.CeriumXHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.LocalMQPlus -o LocalMQ/CeriumX.Messaging.LocalMQPlus/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s LocalMQ LocalMQ/CeriumX.Messaging.LocalMQPlus/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- MQTT消息队列 ﹫ MQTT 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT -o MQTT/CeriumX.Messaging.MQTT/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT.GenericHost -o MQTT/CeriumX.Messaging.MQTT.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT.CeriumXHost -o MQTT/CeriumX.Messaging.MQTT.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- RabbitMQ消息队列 ﹫ RabbitMQ 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ -o RabbitMQ/CeriumX.Messaging.RabbitMQ/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ.GenericHost -o RabbitMQ/CeriumX.Messaging.RabbitMQ.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ.CeriumXHost -o RabbitMQ/CeriumX.Messaging.RabbitMQ.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- Kafka消息队列 ﹫ Kafka 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka -o Kafka/CeriumX.Messaging.Kafka/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka.GenericHost -o Kafka/CeriumX.Messaging.Kafka.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka.CeriumXHost -o Kafka/CeriumX.Messaging.Kafka.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka.CeriumXHost/src





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
