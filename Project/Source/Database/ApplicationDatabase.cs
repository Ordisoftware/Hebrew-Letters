/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-05 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Letters;

using Equin.ApplicationFramework;

[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "<En attente>")]
sealed class ApplicationDatabase : SQLiteDatabase
{

  static public ApplicationDatabase Instance { get; }

  static ApplicationDatabase()
  {
    Instance = new ApplicationDatabase();
  }

  public List<Letter> Letters { get; private set; }
  public List<Meaning> Meanings { get; private set; }

  public BindingListView<Letter> LettersAsBindingList { get; private set; }

  private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
  {
  }

  protected override void Vacuum(bool force = false)
  {
    if ( Program.Settings.VacuumAtStartup )
    {
      var dateNew = Connection.Optimize(Program.Settings.VacuumLastDone, Program.Settings.VacuumAtStartupDaysInterval);
      if ( Program.Settings.VacuumLastDone != dateNew )
      {
        HebrewDatabase.Instance.Connection.Optimize(dateNew, force: true);
        Program.Settings.VacuumLastDone = dateNew;
      }
    }
  }

  protected override void DoClose()
  {
    if ( Letters is null && Meanings is null ) return;
    if ( ClearListsOnCloseOrRelease )
    {
      Meanings?.Clear();
      Letters?.Clear();
    }
    Meanings = null;
    Letters = null;
  }

  protected override void CreateTables()
  {
    Connection.CreateTable<Letter>();
    Connection.CreateTable<Meaning>();
  }

  protected override void DoLoadAll()
  {
    Letters = [.. Connection.Table<Letter>()];
    Meanings = [.. Connection.Table<Meaning>()];
  }

  protected override void CreateBindingLists()
  {
    LettersAsBindingList?.Dispose();
    LettersAsBindingList = new(Letters);
  }

  protected override void DoSaveAll()
  {
    CheckAccess(Letters, nameof(Letters));
    CheckAccess(Meanings, nameof(Meanings));
    Connection.UpdateAll(Letters);
    Connection.UpdateAll(Meanings);
  }

  public void DeleteAll()
  {
    CheckConnected();
    CheckAccess(Meanings, nameof(Meanings));
    CheckAccess(Letters, nameof(Letters));
    Connection.DeleteAll<Meaning>();
    Connection.DeleteAll<Letter>();
    Meanings.Clear();
    Letters.Clear();
  }

  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  protected override void UpgradeSchema()
  {
    base.UpgradeSchema();
    if ( Connection.CheckTable(nameof(Meanings)) )
    {
      if ( !Connection.CheckColumn(nameof(Meanings), "ID") )
      {
        ProcessTableUpgrade<Meaning, MeaningNoID>(
          nameof(Meanings),
          nameof(MeaningNoID),
          (rowOld, rowNew) =>
          {
            rowNew.ID = Guid.NewGuid().ToString();
            rowNew.LetterCode = rowOld.LetterCode;
            rowNew.Text = rowOld.Text;
          });
        Globals.IsDatabaseUpgraded = true;
      }
      const string sqlColumn = "ALTER TABLE %TABLE% ADD COLUMN %COLUMN% TEXT DEFAULT '' NOT NULL";
      bool upgrade = Globals.IsDatabaseUpgraded;
      upgrade = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Hebrew), sqlColumn) || upgrade;
      upgrade = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Positive), sqlColumn) || upgrade;
      upgrade = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Negative), sqlColumn) || upgrade;
      Globals.IsDatabaseUpgraded = upgrade;
    }
  }

  protected override bool CreateDataIfNotExist(bool reset = false)
  {
    CheckAccess(Letters, nameof(Letters));
    CheckAccess(Meanings, nameof(Meanings));
    try
    {
      if ( !reset && Connection.CountRows(nameof(Letters)) == HebrewAlphabet.KeyCodes.Length ) return false;
      bool temp = Globals.IsReady;
      Globals.IsReady = false;
      BeginTransaction();
      try
      {
        DeleteAll();
        string pathFile = string.Format(Program.MeaningsFilePath, Languages.CurrentCode.ToUpper());
        string data = File.ReadAllText(pathFile, Encoding.Default);
        int indexStart = 0;
        string getStrValue(string name)
        {
          int pos = data.IndexOf(name, indexStart, StringComparison.Ordinal);
          int start = pos + name.Length;
          int count = data.IndexOf(Environment.NewLine, pos, StringComparison.Ordinal) - pos - name.Length;
          string s = data.Substring(start, count);
          indexStart = data.IndexOf(Environment.NewLine, pos, StringComparison.Ordinal) + 2;
          return s.Trim();
        }
        int getIntValue(string name)
        {
          return Convert.ToInt32(getStrValue(name));
        }
        for ( int index = 0; index < HebrewAlphabet.KeyCodes.Length; index++ )
        {
          var rowLetter = new Letter
          {
            Code = HebrewAlphabet.KeyCodes[index],
            Name = HebrewAlphabet.Transcriptions.GetLang()[index],
            Hebrew = HebrewAlphabet.Hebrew[index],
            ValueSimple = getIntValue("ValueSimple: "),
            ValueFull = getIntValue("ValueFull: "),
            Positive = getStrValue("Positive: "),
            Negative = getStrValue("Negative: "),
            Verb = getStrValue("Verb: "),
            Structure = getStrValue("Structure: "),
            Function = getStrValue("Function: ")
          };
          Letters.Add(rowLetter);
          Connection.Insert(rowLetter);
          foreach ( var meaning in getStrValue("Meanings: ").Split(',') )
          {
            var rowMeaning = new Meaning
            {
              ID = Guid.NewGuid().ToString(),
              LetterCode = rowLetter.Code,
              Text = meaning.Trim()
            };
            Meanings.Add(rowMeaning);
            Connection.Insert(rowMeaning);
          }
        }
        Commit();
        return true;
      }
      catch
      {
        Rollback();
        throw;
      }
      finally
      {
        Globals.IsReady = temp;
      }
    }
    catch ( Exception ex )
    {
      ex.Manage();
      return false;
    }
  }

}
