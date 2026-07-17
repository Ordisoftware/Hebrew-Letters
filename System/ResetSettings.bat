@echo off
taskkill /im Ordisoftware.Hebrew.Letters.exe
rem ping localhost -n 3 >NUL //OBSOLETE WIN0+
timeout /t 2 /nobreak >NUL
start "" ..\Bin\Ordisoftware.Hebrew.Letters.exe --reset