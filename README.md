# Hebrew Letters

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-letters)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows the lettriq letter-by-letter study of hebrew words.

## Functionalities

- Hebrew letters database with their customizable meanings.
- Analyse a word letter by letter to get a sentence describing its meaning.
- Copy the result to clipboard.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

_"An easy-to-use and intuitive way to study and translate Hebrew words"_

![Note](http://www.ordisoftware.com/uploads/2019/10/softpedia4.5-1.png)

## Requirements

- Windows Vista x32/x64 or higher
- Screen 1024x768 or higher
- Framework .NET 4.5
- SQLite ODBC Driver

## Screenshots

![Analyse Tab](http://www.ordisoftware.com/uploads/2019/09/hebrew-letters-analyse-en.png)

![Settings Tab](http://www.ordisoftware.com/uploads/2019/09/hebrew-letters-settings-en.png)

## Videos

[![Showing video](https://img.youtube.com/vi/rs7l-wvVt-I/0.jpg)](https://www.youtube.com/watch?v=rs7l-wvVt-I)

[![Showing video](https://img.youtube.com/vi/Wc5SdiASvCg/0.jpg)](https://www.youtube.com/watch?v=Wc5SdiASvCg)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

The setup tries to install the driver:

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) on Windows 32-bit.
- [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) on Windows 64-bit.

#### What to do in case of ODBC datasource connection error?

The setup tries to register an ODBC DSN to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Letters\Register ODBC.reg" or open the ODBC datasource manager (Admin tools in Windows' Control panel) and create a user datasource named "Hebrew-Letters" for "SQLite 3 ODBC Driver" with "Database Name" sets to:

"%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Letters\Hebrew-Letters.sqlite"

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

#### Keyboard shortcuts

- F1 : Analyse view
- F2 : Settings view
- F3 : Search a term
- Ctrl+M : Open the lettriq analysis method notice
- Ctrl+G : Open the grammar guide
- Ctrl+L : Open Shorashon web page
- F8 : Preferences
- F11 : Help
- F12 : About

## Changelog

#### 2020.04.23 - Version 4.1

- Add select all (Ctrl+A) and undo/redo support for textboxes.
- Add undo/redo & copy/cut/paste context menu for text boxes.
- Add backspace key management for textboxes.
- Fix copy/cut/paste of  hebrew textbox.
- Fix inserting a letter at the caret when clicking on letters buttons.
- Add option to set the max length of the textbox of the hebrew input panel.
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
- Add copy hebrew unicode to clipboard button.
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
