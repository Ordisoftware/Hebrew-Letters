[![License: MPL 2.0](https://img.shields.io/github/license/ordisoftware/hebrew-letters)](LICENSE)&nbsp;
[![GitHub all releases downloads](https://img.shields.io/github/downloads/ordisoftware/hebrew-letters/total)](https://github.com/Ordisoftware/Hebrew-Letters/releases)&nbsp;
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/ordisoftware/hebrew-letters)](https://github.com/Ordisoftware/Hebrew-Letters/releases/latest)&nbsp;
[![GitHub repo size](https://img.shields.io/github/repo-size/ordisoftware/hebrew-letters)](#)&nbsp;
[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/ordisoftware/hebrew-letters)](https://github.com/Ordisoftware/Hebrew-Letters/tree/master/Project)&nbsp;
[![Lines of code](https://img.shields.io/tokei/lines/github/ordisoftware/hebrew-letters)](https://github.com/Ordisoftware/Hebrew-Letters/tree/master/Project)&nbsp;<br/>
[![OS: Windows](https://img.shields.io/badge/Windows%207%2B-279CE8?label=os)](https://www.microsoft.com/windows/)&nbsp;
[![UI: WinForms](https://img.shields.io/badge/WinForms-279CE8?label=ui)](https://github.com/dotnet/winforms)&nbsp;
[![Framework: .Net](https://img.shields.io/badge/.NET%204.8-6E5FA6?label=framework)](https://dotnet.microsoft.com)&nbsp;
[![IDE: Visual Studio](https://img.shields.io/badge/Visual%20Studio%202022-6E5FA6.svg?label=ide)](https://visualstudio.microsoft.com)&nbsp;
[![Lang: C#](https://img.shields.io/badge/C%23%2010-%23239120.svg?label=lang)](https://docs.microsoft.com/dotnet/csharp/)&nbsp;
[![DB: SQLite](https://img.shields.io/badge/SQLite%203.35-darkgoldenrod.svg?label=db)](https://www.sqlite.org)&nbsp;<br/>
[![Ordisoftware.com Project](https://img.shields.io/badge/-Ordisoftware.com%20Project-355F90?logo=WordPress&logoColor=white)](https://www.ordisoftware.com/hebrew-letters)&nbsp;
[![Manufacturing Software Guidelines](https://img.shields.io/badge/-Manufacturing%20Software%20Guidelines-355F90?logo=MicrosoftWord&logoColor=white)](https://github.com/Ordisoftware/Guidelines)&nbsp;

# Hebrew Letters

A libre and open-source software written in C# that helps for the lettriq letter-by-letter study and analysis of Hebrew words.

## Table of content

1. [Functionalities](#functionalities)
2. [Review](#review)
3. [Requirements](#requirements)
4. [Download](#download)
5. [Screenshots](#screenshots)
6. [Videos](#videos)
7. [Frequently asked questions](#frequently-asked-questions)
8. [Keyboard shortcuts](#keyboard-shortcuts)
9. [Future improvements](#future-improvements)
10. [Changelog](#changelog)

## Functionalities

- Hebrew letters database with their customizable meanings.
- Analyze a word letter-by-letter to get a sentence describing its sense.
- Online research with Pealim, Sefaria, Shorashim, Wiktionary, Translator, etc.
- Store results in a notebook that can also be used in Hebrew Words.
- Copy analysis to the clipboard or take a screenshot.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

_"An easy-to-use and intuitive way to study and translate Hebrew words"_

[![Note](https://www.ordisoftware.com/wp-content/theming/softpedia4.5-white.png)](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml)

## Requirements

- Screen 1024x768 or higher
- Windows 7 SP1 x32/x64 or higher
- Framework .NET 4.8
- SQLite 3.35.5

## Download

**What's new in the latest version 6**

- SQLite ODBC Driver is no more needed.
- Overall performances are optimized.
- Some fixes and improvements.
- Update web links.

[Last release](https://github.com/Ordisoftware/Hebrew-Letters/releases/latest)

## Screenshots

[![Analyze view](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-analyze-en-400x390.png)](http://www.ordisoftware.com/uploads/2020/04/hebrew-letters-data-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Data view](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-data-en-330x390.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-data-en.png)

[![Preferences window](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-preferences-en-325x255.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-preferences-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Search results](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-searchresult-en.png)](https://www.ordisoftware.com/uploads/2021/03/hebrew-letters-searchresult-en.png)

## Videos

[![Showing video](https://img.youtube.com/vi/rs7l-wvVt-I/mqdefault.jpg)](https://www.youtube.com/watch?v=rs7l-wvVt-I)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Showing video](https://img.youtube.com/vi/Wc5SdiASvCg/mqdefault.jpg)](https://www.youtube.com/watch?v=Wc5SdiASvCg)

## Frequently asked questions

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it. This certificate is normally updated within the two months of its annual expiration and a new version is released. You can manually check the latest version available online in case of problem.

#### What is the Windows double-buffering?

When enabled, this will speed up rendering of the main form when it is displayed, but it may cause a slight black flicker.

When disabled, top menu painting may cause latency.

#### What are command-line options?

- Change interface language (does not change the meanings of letters unless restoring them):

  `Ordisoftware.Hebrew.Letters.exe --lang [en|fr]`

- Analyze a word in Hebrew Unicode chars or else Hebrew font chars like "`בראשית`" and "`ty>arb`":

  `Ordisoftware.Hebrew.Letters.exe --word [word]` 

  Or without any other option:

  `Ordisoftware.Hebrew.Letters.exe [word]`

  All diacritics are removed and if the word can't be processed it is set to empty.

  If any Hebrew Unicode chars is present, all non Unicode are removed, else Hebrew font chars are used and all non-font chars are removed.

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

- Add option to set primary source for check update between author website or GitHub.
- Add find gematria possible combinations.
- Add reset only some columns to factory defaults.
- Add export and import database.
- Add export data to TXT/CSV/JSON.
- Add import data from TXT/CSV/JSON.
- Add print data.
- Rewrite advanced undo/redo.
- Optimize more ComboBoxes creation.

## Changelog

#### In progress for 2022 - Version 7.0

- Add analyzed words data table and notebook view to save results.
- Add concordance, transcription, dictionary and comment fields for word analysis.
- Add search online concordance.

#### In progress  - Version 6.9

- Refactor and fix code.
- Update web links.

#### 2021.12.21 - Version 6.8

- Few fixes and improvements.
- Add Judaism 101 website link.

#### 2021.12.16 - Version 6.7

- Maintenance release.
- Some fixes.
- Refactoring.
- Update web links.
- Update Hebrew applications' icons.

#### 2021.12.05 - Version 6.6

- Change web check update to use GitHub as an alternative if author's website is down.
- Improve database management code.
- Fix data not available when the application is started for the very first time since v6.0.
- Fix web check update to not display timeout error in auto check mode.
- Few fixes and improvements.

#### 2021.11.25 - Version 6.5

- Improve about box to dynamically display the list of dependencies and media used.
- Add show only log files having errors in trace form.
- Few fixes and improvements.
- Code refactoring.

#### 2021.11.21 - Version 6.4

- Few fixes.
- Code refactoring.
- French and English corrections.
- Reorganize web links to avoid problems on small screens.

#### 2021.11.14 - Version 6.3

- Add menu in Tools to open export folder.
- Add menu in Tools to optimize database.
- Fix Windows version detection.
- French and English corrections.
- Upgrade to Visual Studio 2022 and C# 10.
- Update setup for Framework .NET 4.8
- Code refactoring.

#### 2021.11.09 - Version 6.2

- Fix getting CPU usage for multiple instances.
- Fix memory size calculation in usage statistics.
- Some fixes and improvements.
- Code refactoring and quality improvement.
- Update system menu.
- Update sqlite-net-pcl nuget.
- Update SQLitePCL.raw nuget.

#### 2021.10.17 - Version 6.1

- Maintenance release.
- Some fixes.
- Refactoring.
- Update web links.

#### 2021.08.05 - Version 6.0

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

- Fix exception in analysis meanings combo boxes introduced in previous version.
- Update web links.

#### 2021.03.19 - Version 5.1

- Improve analysis labels to be click-able to switch to letter's details.
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
- Fix pasting Unicode chars removes special final letters.
- Improve data edition.
- Improve copy and paste to support both Hebrew font and Unicode chars from context menu and keyboard.
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
- Add option to set the max length of the text box of the Hebrew input panel.
- Improve auto optimize database at startup that is done once a week.
- Improve debugger to create a GitHub issue.
- Optimize startup time.

#### 2020.04.19 - Version 4.0

- Exit application at startup if user choose to download a newer version.
- Add lettriq analysis method notice.
- Add grammar guide from Hebrew Words.
- Add menu for web links about Judaism.
- Add option to auto optimize database at startup.
- Add option to auto sort meanings combo box items.
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
- Remove diacritics from Unicode clipboard content.

#### 2020.03.14 - Version 3.0

- Add search a term.
- Add letters values in the input panel.
- Add copy/cut/paste for the input box.
- Add copy Hebrew Unicode to clipboard button.
- Add paste from Unicode clipboard content button.
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

- Fix letters English names.

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