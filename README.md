# Hebrew Letters

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-letters)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows the lettriq study of hebrew words.

## Functionalities

- Hebrew letters database with their customizable meanings.
- Analyse a word letter by letter to get a sentence describing its meaning.
- Copy the result to clipboard.
- English, French.

## Requirements

- Windows Vista x32/x64 or superior
- Screen 1024x768 or superior
- Framework .NET 3.5 or superior
- [SQLite ODBC Driver](http://www.ch-werner.de/sqliteodbc/)

## Screenshots

![Analyse Tab](http://www.ordisoftware.com/uploads/2019/01/hebrew-letters-analyse.png)

![Settings Tab](http://www.ordisoftware.com/uploads/2019/01/hebrew-letters-settings.png)

## Videos

[![Showing video](https://img.youtube.com/vi/rs7l-wvVt-I/0.jpg)](https://www.youtube.com/watch?v=rs7l-wvVt-I)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) must be installed on Windows 32-bit.
- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) and [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) must be installed on Windows 64-bit.

#### What to do in case of ODBC datasource connection error?

The setup tries to register an ODBC DSN to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Letters\Register ODBC.reg" or open the ODBC datasource manager (Admin tools in Windows' Control panel) and create a user datasource named "Hebrew-Letters" for "SQLite 3 ODBC Driver" with "Database Name" sets to:

"%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Letters\Hebrew-Letters.sqlite"

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

## Changelog

#### 2019.__.__ - Version 2.6

- Add option to choose language.
- Update help.
- Some code refactorings.

#### 2019.09.19 - Version 2.5

- Add option to disable startup check update.
- Some code refactorings.

#### 2019.09.15 - Version 2.4

- Fix starting form location.

#### 2019.09.04 - Version 2.3

- Update controls tabs.

#### 2019.08.28 - Version 2.2

- Fix letters english names.

#### 2019.08.27 - Version 2.1

- Improve raw export to clipboard of a word's meanings.

#### 2019.08.22 - Version 2.0

- Upgrade DB to improve letters description.
- Add raw export to clipboard of a word's meanings.
- Some improvments.

#### 2019.05.22 - Version 1.1

- Add check update.

#### 2019.01.24 - Version 1.0

- Initial release.
