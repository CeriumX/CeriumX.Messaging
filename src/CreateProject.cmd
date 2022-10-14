@echo off
@title �Զ����������������������Ŀ

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- ������� ----------

dotnet new sln -n CRS2TBBT4CeriumX.Messaging





@echo.
@echo.
@echo.
@echo\&echo  ---------- ʾ������ & samples 4 ----------

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
@echo\&echo  ---------- �ӿڳ��� �� Abstractions 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Abstractions -o CeriumX.Messaging.Abstractions/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add --in-root CeriumX.Messaging.Abstractions/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- ��Ϣ���з������� �� ServiceBus 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus -o ServiceBus/CeriumX.Messaging.ServiceBus/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus.GenericHost -o ServiceBus/CeriumX.Messaging.ServiceBus.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.ServiceBus.CeriumXHost -o ServiceBus/CeriumX.Messaging.ServiceBus.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s ServiceBus ServiceBus/CeriumX.Messaging.ServiceBus.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- ������Ϣ���� �� LocalMQ 4 ----------

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
@echo\&echo  ---------- MQTT��Ϣ���� �� MQTT 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT -o MQTT/CeriumX.Messaging.MQTT/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT.GenericHost -o MQTT/CeriumX.Messaging.MQTT.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.MQTT.CeriumXHost -o MQTT/CeriumX.Messaging.MQTT.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s MQTT MQTT/CeriumX.Messaging.MQTT.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- RabbitMQ��Ϣ���� �� RabbitMQ 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ -o RabbitMQ/CeriumX.Messaging.RabbitMQ/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ.GenericHost -o RabbitMQ/CeriumX.Messaging.RabbitMQ.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.RabbitMQ.CeriumXHost -o RabbitMQ/CeriumX.Messaging.RabbitMQ.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s RabbitMQ RabbitMQ/CeriumX.Messaging.RabbitMQ.CeriumXHost/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- Kafka��Ϣ���� �� Kafka 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka -o Kafka/CeriumX.Messaging.Kafka/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka.GenericHost -o Kafka/CeriumX.Messaging.Kafka.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.Messaging.Kafka.CeriumXHost -o Kafka/CeriumX.Messaging.Kafka.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add -s Kafka Kafka/CeriumX.Messaging.Kafka.CeriumXHost/src





::@echo\&echo ������Ŀ�Զ����������ѽ�����600 ����Զ��˳����Զ���������
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo ������Ŀ�Զ�������ϣ��밴������˳���
pause>nul 
exit
