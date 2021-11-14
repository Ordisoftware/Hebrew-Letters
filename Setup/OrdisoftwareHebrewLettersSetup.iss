#define MyAppVersion "6.3"
#define MyAppName "Hebrew Letters"
#define MyAppNameNoSpace "HebrewLetters"
#define MyAppExeName "Ordisoftware.Hebrew.Letters.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hebrew-letters"

[Setup]
AppCopyright=Copyright 2012-2021 Olivier Rogier
AppId={{1FD1454B-F437-4AC5-844F-C3649D664D8F}
;AppMutex=e4e4c05b-71ed-42de-a2fa-345ae793a9ac
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[CustomMessages]
#include "Scripts\Messages.iss"


[Tasks]
#include "Scripts\Tasks.iss"


[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Icons]
#include "Scripts\Icons.iss"


[Registry]


[Run]
#include "Scripts\Run.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"
