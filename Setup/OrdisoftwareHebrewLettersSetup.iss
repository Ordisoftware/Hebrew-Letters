#define MyAppVersion "6.8"
#define MyAppName "Hebrew Letters"
#define MyAppNameNoSpace "HebrewLetters"
#define MyAppExeName "Ordisoftware.Hebrew.Letters.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hebrew-letters"

[Setup]
MinVersion=0,6.1sp1
LicenseFile=..\Project\Licenses\MPL 2.0.rtf
AppCopyright=Copyright 2012-2022 Olivier Rogier
AppId={{1FD1454B-F437-4AC5-844F-C3649D664D8F}
;AppMutex=e4e4c05b-71ed-42de-a2fa-345ae793a9ac
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Run]
#include "Scripts\Run.iss"

[Registry]

[Tasks]
#include "Scripts\Tasks.iss"

[Icons]
#include "Scripts\Icons.iss"

[CustomMessages]
#include "Scripts\Messages.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"
