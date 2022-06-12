@echo off
@title 自动创建解决方案及各隶属项目

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- 解决方案 ----------

dotnet new sln -n  CRS2TBBT4CeriumX.Messaging





@echo.
@echo.
@echo.
@echo\&echo  ---------- 引导程序 & Bootloader 1 ----------
dotnet new classlib -lang "C#" -f net5.0 -n CeriumX.Framework.Bootloader -o CeriumX.Framework.Bootloader\src
dotnet sln CRS2TBBT4CeriumX.Messaging.sln add --in-root CeriumX.Framework.Bootloader\src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 项目类别 ﹫ ProjectCategory 10 ----------

dotnet new web -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new blazorserver -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new blazorwasm -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new mvc -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new webapi -lang "C#" -f net6.0 --exclude-launch-settings --no-https -n LibrayName -o LibrayName/src
dotnet sln SolutionName.sln add --in-root LibrayName/src

dotnet new winforms -lang "C#" -f net6.0 -n LibrayName -o samples/LibrayName/src
dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

dotnet new wpf -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new console -lang C# -f net6.0 -n LibrayName -o samples/LibrayName/src
dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o LibrayName/src
dotnet sln SolutionName.sln add --in-root LibrayName/src

dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src





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
