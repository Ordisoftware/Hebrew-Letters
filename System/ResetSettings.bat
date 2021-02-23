@echo off
taskkill /im Ordisoftware.Hebrew.Letters.exe
ping localhost -n 3 >NUL
start "" ..\Bin\Ordisoftware.Hebrew.Letters.exe --reset