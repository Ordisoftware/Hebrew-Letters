# Hebrew Letters

> Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
> This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).<br/>
> [Website](https://www.ordisoftware.com/projects/hebrew-letters)<br/>
> [Twitter](https://twitter.com/ordisoftware)<br/>

A libre and open-source software written in C# that helps for the lettriq letter-by-letter study and analysis of Hebrew words.

## Table of content

1. [Functionalities](#Functionalities)
2. [Review](#Review)
3. [Requirements](#Requirements)
4. [Download](#Download)
5. [Screenshots](#Screenshots)
6. [Videos](#Videos)
7. [Frequently asked questions](#Frequently-asked-questions)
8. [Keyboard shortcuts](#Keyboard-shortcuts)
9. [Future improvements](#Future-improvements)
10. [Changelog](#Changelog)

## Functionalities

- Database of Hebrew letters with their customizable meanings.
- Analyse a word letter by letter to get a sentence describing its sense.
- Copy to the clipboard the analysis and the sentence or a screenshot.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

_"An easy-to-use and intuitive way to study and translate Hebrew words"_

[![Note](https://www.ordisoftware.com/theme/softpedia4.5-white.png)](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

## Requirements

- Windows 7 SP1 x32/x64 or higher
- Screen 1024x768 or higher
- Framework .NET 4.7.2
- SQLite ODBC Driver

## Download

**What's new in the latest version**

- Startup and combo boxes creation are optimized.
- Modification of the database is only possible by one instance at a time.
- New top menu icon to open a new window.
- New context menu on letters' buttons.
- New screenshot button.
- New usage statistics window.
- Rework of the preferences window design with more options.
- Fixed and improved copy, paste and delete for both Hebrew font chars and unicode.
- Incorporate common code written since more than one year for Hebrew Calendar.
- Added news in version in the Information menu.
- Modification and addition of web links and online providers for the study of words and verses of the Bible.
- Some improvements in appearance and function.

[Last release](https://github.com/Ordisoftware/Hebrew-Letters/releases/latest)

## Screenshots

[![Analyse](https://i0.wp.com/www.ordisoftware.com/uploads/2020/04/hebrew-letters-analyse-en.png?resize=300%2C292&ssl=1)](http://www.ordisoftware.com/uploads/2020/04/hebrew-letters-analyse-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Parameters](https://i1.wp.com/www.ordisoftware.com/uploads/2020/04/hebrew-letters-settings-en.png?resize=272%2C300&ssl=1)](http://www.ordisoftware.com/uploads/2020/04/hebrew-letters-settings-en.png)

## Videos

[![Showing video](https://img.youtube.com/vi/rs7l-wvVt-I/mqdefault.jpg)](https://www.youtube.com/watch?v=rs7l-wvVt-I)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Showing video](https://img.youtube.com/vi/Wc5SdiASvCg/mqdefault.jpg)](https://www.youtube.com/watch?v=Wc5SdiASvCg)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

The setup installs:

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) on Windows 32-bit.
- [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) on Windows 64-bit.

In the event that an error message indicates that a DLL file could not be copied, it is usually due to the fact that an application using this driver already installed is running and is blocking the file. You can ignore this error or close the application in question and restart the installation to obtain a driver update.

#### What to do in case of ODBC datasource connection error?

The software tries to register an ODBC DSN to the registry but in case of problem run:

&emsp;`C:\Program Files\Ordisoftware\Hebrew Letters\System\RegisterODBC.reg`

Or open the ODBC Datasource Manager (Admin tools in Windows' Control panel) and create a user datasource named:

&emsp;`Hebrew-Letters` for `SQLite 3 ODBC Driver`

With Database Name sets to:

&emsp;`%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Letters\Hebrew-Letters.sqlite`

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it. This certificate is normally updated within the two months of its annual expiration and a new version is released. If the application has not been updated within this period, you can manually check the latest version available online.

## Keyboard shortcuts

| Keys | Actions |
|-|-|
| F1 | Analyse view |
| F2 | Settings view |
| F3 | Search a term |
| Ctrl+N | Open a new window |
| Ctrl+M | Open the lettriq analysis method notice |
| Ctrl+G | Open the grammar guide |
| Ctrl+L | Open Shorashon web page |
| Ctrl+F11 | Current log window |
| Ctrl+F12 | Statistics window |
| F9 | Preferences |
| F12 | About |
| Alt + F4 (or Escape) | Close window |

## Future improvements

- Add print data.
- Add import data.
- Add import and export database.
- Rewrite advanced undo/redo.
- Optimize more ComboBoxes creation.

## Changelog

#### 2021.03.12 - Version 5.0

>- Add export and import or merge data.
>- Add sounds to clipboard actions.
>- Add keyboard shortcuts notice in windows settings menu.

- Optimize ComboBoxes creation (the old system is really much slower on Windows 10 than 7).
- Add Windows double-buffering drawing to optimize startup.
- Add context menu on letters' buttons to allow inserting a letter or open its parameters.
- Add create a screenshot of the form.
- Add open new window menu button.
- Add concurrency control to avoid database editing when multiple instances are running.
- Add permanent database file locking while running.
- Add usage statistics form in tools menu.
- Add option to set automatic web check update frequency.
- Add option to enable or disable the web links menu.
- Add option to enable or disable message boxes sounds.
- Add option to set application's volume.
- Add news in version notice in the Information menu.
- Add show usage statistics from about box.
- Add check update from about box.
- Fix pasting Hebrew font chars removes special final letters.
- Fix pasting unicode chars removes special final letters.
- Improve copy and paste to support both Hebrew font and unicode chars from context menu and keyboard.
- Improve check update to allow auto update or direct download or open app web page.
- Improve check update to verify the SSL certificate of the website and the checksum of the setup file.
- Improve debugger to support logging.
- Improve exception form to view log.
- Improve message boxes.
- Improve UI/UX.
- Rework of the preferences form design to have a Tab Control with pages.
- Change all TextBox for UndoRedoTextBox to have the new context menu.
- Remove advanced undo/redo due to a problem that requires a complete rewrite to have the cursor not misplaced in certain cases.
- Add Markdig NuGet package.
- Add FileHelpers NuGet package.
- Add Newtonsoft.Json NuGet package.
- Add MoreLINQ NuGet package.
- Add Enums.NET NuGet package.
- Add Global Shortcut Manager dependency.
- Add InputSimulatorStandard NuGet package.
- Add Serilog NuGet package.
- Add Serilog-sinks-file NuGet package.
- Add Serilog-sinks-winforms NuGet package.
- Replace simple internal command line parser by CommandLineParser NuGet package.
- The application now automatically creates the ODBC DSN in the Windows registry.
- Massive files and code refactoring.
- Incorporate common code written since more than one year for Calendar.
- Update to SQLite 3.32.3 ODBC Driver.
- Update to Framework .NET 4.7.2 and supported Windows only 7 SP1 or higher.
- Update setup.
- Update web links.
- Update help.

#### 2020.04.23 - Version 4.1

- Add select all (Ctrl+A) and undo/redo support for text boxes.
- Add undo/redo & copy/cut/paste context menu for text boxes.
- Add backspace key management for text boxes.
- Fix copy/cut/paste of Hebrew text box.
- Fix inserting a letter at the caret when clicking on letters buttons.
- Add option to set the max length of the textbox of the Hebrew input panel.
- Improve auto optimize database at startup that is done once a week.
- Improve debugger to create a GitHub issue.
- Optimize startup time.

#### 2020.04.19 - Version 4.0

- Exit application at startup if user choose to download a newer version.
- Add lettriq analysis method notice.
- Add grammar guide from Hebrew Words.
- Add menu for web links about judaism.
- Add option to auto optimize database at startup.
- Add option to auto sort meanings combobox items.
- Add option to use Escape key to close app.
- Add option to enable debugger.
- Add debugger (exception information form).
- Fix paste from clipboard to overwrite the selected text.
- Fix selected row in meanings array when the last item is deleted.
- Improve search term result dialog box.
- Improve UI/UX.
- Code refactoring.
- Move online providers values from code to files in the application documents folder.
- Update help.

#### 2020.04.07 - Version 3.1

- Add option to change the sentence font size.
- Improve search term form.
- Improve copy meanings to clipboard.
- Remove diacritics from unicode clipboard content.

#### 2020.03.14 - Version 3.0

- Add search a term.
- Add letters values in the input panel.
- Add copy/cut/paste for the input box.
- Add copy Hebrew unicode to clipboard button.
- Add paste from unicode clipboard content button.
- Add online search from several providers (Pealim, Google, Bing, Wiktionary, Sefaria, Reverso, Glosbe, Dict.com).
- Add  links to Shorashon and Lexilogos.

#### 2019.10.27 - Version 2.9

- Improve meanings by trimming leading and trailing spaces.

#### 2019.10.21 - Version 2.8

- Fix french translation of parameters labels lost in previous version.
- Update help.

#### 2019.10.18 - Version 2.7

- Improve UI.
- Some fixes.
- Some code refactorings.
- Setup install SQLite ODBC Driver if not present.

#### 2019.09.25 - Version 2.6

- Add option to choose language.
- Fix meanings can't be edited or deleted.
- Fix meanings list.
- Improve UI.
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
- Some improvements.

#### 2019.05.22 - Version 1.1

- Add check update.

#### 2019.01.24 - Version 1.0

- Initial release.
