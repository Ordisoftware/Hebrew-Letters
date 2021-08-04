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

- Hebrew letters database with their customizable meanings.
- Analyze a word letter by letter to get a sentence describing its sense.
- Online research with Pealim, Sefaria, Shorashim, Wiktionary, Translator, etc.
- Store results in a notebook that can also be used in Hebrew Words.
- Copy the result or a screenshot to the clipboard.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

_"An easy-to-use and intuitive way to study and translate Hebrew words"_

[![Note](https://www.ordisoftware.com/wp-content/theming/softpedia4.5-white.png)](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

## Requirements

- Windows 7 SP1 x32/x64 or higher
- Screen 1024x768 or higher
- Framework .NET 4.7.2

## Download

**What's new in the latest version 6.0**

- Overall performances are optimized.
- Some fixes and improvements.
- SQLite ODBC Driver is no more needed.

[Last release](https://github.com/Ordisoftware/Hebrew-Letters/releases/latest)

## Screenshots

[![Analyze view](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-analyze-en-400x390.png)](http://www.ordisoftware.com/uploads/2020/04/hebrew-letters-data-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Data view](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-data-en-330x390.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-data-en.png)

[![Preferences window](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-preferences-en-325x255.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-preferences-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Search results](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-searchresult-en.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-searchresult-en.png)

## Videos

[![Showing video](https://img.youtube.com/vi/rs7l-wvVt-I/mqdefault.jpg)](https://www.youtube.com/watch?v=rs7l-wvVt-I)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Showing video](https://img.youtube.com/vi/Wc5SdiASvCg/mqdefault.jpg)](https://www.youtube.com/watch?v=Wc5SdiASvCg)

## Frequently asked questions

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it. This certificate is normally updated within the two months of its annual expiration and a new version is released. You can manually check the latest version available online in case of problem.

#### What are command-line options?

- Change interface language (does not change the meanings of letters unless restoring them):

  `Ordisoftware.Hebrew.Letters.exe --lang [en|fr]`

- Analyze a word in Hebrew unicode chars or else Hebrew font chars like "`בראשית`" and "`ty>arb`":

  `Ordisoftware.Hebrew.Letters.exe --word [word]` 

  Or without any other option:

  `Ordisoftware.Hebrew.Letters.exe [word]`

  All diacritics are removed and if the word can't be processed it is set to empty.

  If any Hebrew unicode chars is present, all non-unicode are removed, else Hebrew font chars are used and all non-font chars are removed.

#### How to run a word contextual analysis from any application such as browser or text editor?

It is possible to use [AutoHotKey](https://www.autohotkey.com) to define for example this Shift + Ctrl + Alt + H command on a selected word:

```
!^+H::
  clipboardOld := ClipboardAll
  ControlGetFocus, ctrl
  Send, ^c
  sleep 100
  word := Clipboard
  Clipboard := clipboardOld
  ;appPath := "C:\Program Files\Ordisoftware\Hebrew Letters\Bin\"
  appPath := "c:\Users\Olivier\Projects\Software\Public\Hebrew Letters\Bin\Debug\"
  appExe := "Ordisoftware.Hebrew.Letters.exe"
  sleep 200
  Run %appPath%%appExe% "%word%"
  return 
```

## Keyboard shortcuts

| Keys | Actions |
|-|-|
| Ctrl + Tab | Next view |
| Shift + Ctrl + Tab | Previous view |
| F1 | Analysis view |
| F2 | Data view |
| F3 | Notebook view |
| F5 (or Ctrl + F) | Search
| Ctrl + Home | First letter |
| Ctrl + End | Last letter |
| Ctrl + PageUp | Previous letter |
| Ctrl + PageDn | Next letter |
| Ctrl + Ins (or +) | Add meaning |
| Ctrl + Del (or -) | Delete meaning |
| Ctrl + S | Save changes |
| Ctrl + Back | Cancel changes |
| Ctrl + M | Lettriq analysis method notice |
| Ctrl + G | Grammar guide |
| Alt + N | New window |
| Alt + T | Tools menu |
| Alt + L | Web links menu |
| Alt + S | Settings menu |
| Alt + I | Information menu |
| F9 | Preferences |
| F10 | Log file window |
| F11 | Usage statistics window |
| F12 | About |
| Alt + F4 (or Escape) | Exit application |

## Future improvements

- Add analyzed words data table and notebook view.
- Add find gematria possible combinations.
- Add reset only some columns to factory defaults.
- Add export and import database.
- Add export data to TXT/CSV/JSON.
- Add import data from TXT/CSV/JSON.
- Add print data.
- Rewrite advanced undo/redo.
- Optimize more ComboBoxes creation.

## Changelog

#### 2021.08.08 - Version 6.0

- Switch from SQLite ODBC Driver to SQLite-Net with SQLitePCLraw nugets.
- Optimize overall performances.
- Replace proprietary simple TraceListener by SeriLog.
- Improve trace form.
- Some fixes and improvements.
- Code refactoring and quality improvement.

#### 2021.04.30 - Version 5.3

- Fix drop down menus shown on another monitor instead of the same screen.
- Improve web check update timeout to 5s.
- Code refactoring and quality improvement.

#### 2021.03.27 - Version 5.2

- Fix exception in analysis meanings comboboxes introduced in previous version.
- Update web links.

#### 2021.03.19 - Version 5.1

- Improve analysis labels to be clickable to switch to letter's details.
- Update web links.

#### 2021.03.07 - Version 5.0

- Optimize ComboBoxes creation (the old system is really much slower on Windows 10 than 7).
- Add Windows double-buffering drawing to optimize startup.
- Add context menu on letters' buttons to allow inserting a letter or open its data.
- Add link to *hebrew.ch* shorashim database.
- Add create and save a screenshot of the form.
- Add open new window top menu button.
- Add concurrency control to avoid database editing when multiple instances are running.
- Add permanent database file locking while running.
- Add usage statistics form in tools menu.
- Add option to enable or disable the web links menu.
- Add option to enable or disable message boxes sounds.
- Add option to set automatic web check update frequency.
- Add option to set application's volume.
- Add Option to set color theme.
- Add import and export settings.
- Add sounds to clipboard actions.
- Add keyboard shortcuts notice in windows settings menu.
- Add news in version notice in the Information menu.
- Add show usage statistics from about box.
- Add check update from about box.
- Add command-line options (see FAQ).
- Fix pasting Hebrew font chars removes special final letters.
- Fix pasting unicode chars removes special final letters.
- Improve data edition.
- Improve copy and paste to support both Hebrew font and unicode chars from context menu and keyboard.
- Improve search box to add Left and Right keys to switch between lists.
- Improve check update to allow auto update or direct download or open app web page.
- Improve check update to verify the SSL certificate of the website and the checksum of the setup file.
- Improve debugger to support logging.
- Improve exception form to view log.
- Improve message boxes.
- Improve keyboard shortcuts.
- Improve UI/UX.
- Rework of the preferences form design to have a Tab Control with pages with more options.
- Change all TextBox for TextBoxEx to have the new context menu.
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
- Replace simple command-line parser by CommandLineParser NuGet package.
- The application now automatically creates the ODBC DSN in the Windows registry.
- files and code refactoring.
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
