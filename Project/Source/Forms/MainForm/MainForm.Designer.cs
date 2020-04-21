namespace Ordisoftware.HebrewLetters
{
  partial class MainForm
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && (components != null) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label LabelName;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.Label LabelStructure;
      System.Windows.Forms.Label LabelFunction;
      System.Windows.Forms.Label LabelValueSimple;
      System.Windows.Forms.Label LabelValueFull;
      System.Windows.Forms.Label LabelMeanings;
      System.Windows.Forms.Label LabelVerb;
      System.Windows.Forms.Label LabelPositive;
      System.Windows.Forms.Label LabelNegative;
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelMainOuter = new System.Windows.Forms.Panel();
      this.PanelMainInner = new System.Windows.Forms.Panel();
      this.PanelMainCenter = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageText = new System.Windows.Forms.TabPage();
      this.PanelViewSearch = new System.Windows.Forms.Panel();
      this.ActionReset = new System.Windows.Forms.Button();
      this.ActionDelLast = new System.Windows.Forms.Button();
      this.ActionDelFirst = new System.Windows.Forms.Button();
      this.SelectCloseApp = new System.Windows.Forms.CheckBox();
      this.EditAnalyze = new System.Windows.Forms.Panel();
      this.ActionSearchOnline = new System.Windows.Forms.Button();
      this.ContextMenuStripSearchOnline = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionOpenWordOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionPasteFromUnicode = new System.Windows.Forms.Button();
      this.ActionCopyToUnicode = new System.Windows.Forms.Button();
      this.ActionClear = new System.Windows.Forms.Button();
      this.ActionCopyToClipboardMeanings = new System.Windows.Forms.Button();
      this.ActionCopyToClipboardResult = new System.Windows.Forms.Button();
      this.EditSentence = new System.Windows.Forms.TextBox();
      this.EditGematria = new System.Windows.Forms.TextBox();
      this.LabelGematria = new System.Windows.Forms.Label();
      this.EditLetters = new Ordisoftware.HebrewCommon.LettersControl();
      this.TabPageMonth = new System.Windows.Forms.TabPage();
      this.PanelViewSettings = new System.Windows.Forms.Panel();
      this.PanelSettingsDetails = new System.Windows.Forms.Panel();
      this.PanelLetter = new System.Windows.Forms.Panel();
      this.ComboBoxCode = new System.Windows.Forms.ComboBox();
      this.LettersBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.DataSet = new Ordisoftware.HebrewLetters.Data.DataSet();
      this.TextBoxStructure = new System.Windows.Forms.TextBox();
      this.LabelHebrew = new System.Windows.Forms.Label();
      this.TextBoxNegative = new System.Windows.Forms.TextBox();
      this.TextBoxName = new System.Windows.Forms.TextBox();
      this.TextBoxFunction = new System.Windows.Forms.TextBox();
      this.TextBoxPositive = new System.Windows.Forms.TextBox();
      this.TextBoxVerb = new System.Windows.Forms.TextBox();
      this.TextBoxValueSimple = new System.Windows.Forms.TextBox();
      this.TextBoxValueFull = new System.Windows.Forms.TextBox();
      this.ActionRestoreDefaults = new System.Windows.Forms.LinkLabel();
      this.ActionDeleteMeaning = new System.Windows.Forms.Button();
      this.ActionAddMeaning = new System.Windows.Forms.Button();
      this.EditMeanings = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MeaningsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.Sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHelp = new System.Windows.Forms.ToolStripButton();
      this.MenuWeb = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCreateGitHubIssue = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebQA = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebHome = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebContact = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebTipeee = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebTwitter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebYouTube = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionDownloadHebrewCalendar = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionDownloadHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.MenuSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.MenuitemScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewAnalysis = new System.Windows.Forms.ToolStripButton();
      this.ActionViewLetters = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchTerm = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionShowMethodNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenShorashon = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenLexilogosOld = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenLexilogosModern = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionOpenWebLinkTemplateFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenWebLinkTemplateLink = new System.Windows.Forms.ToolStripMenuItem();
      this.LettersTableAdapter = new Ordisoftware.HebrewLetters.Data.DataSetTableAdapters.LettersTableAdapter();
      this.TableAdapterManager = new Ordisoftware.HebrewLetters.Data.DataSetTableAdapters.TableAdapterManager();
      this.MeaningsTableAdapter = new Ordisoftware.HebrewLetters.Data.DataSetTableAdapters.MeaningsTableAdapter();
      this.ContextMenuStripSentence = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCut = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionPaste = new System.Windows.Forms.ToolStripMenuItem();
      LabelName = new System.Windows.Forms.Label();
      LabelStructure = new System.Windows.Forms.Label();
      LabelFunction = new System.Windows.Forms.Label();
      LabelValueSimple = new System.Windows.Forms.Label();
      LabelValueFull = new System.Windows.Forms.Label();
      LabelMeanings = new System.Windows.Forms.Label();
      LabelVerb = new System.Windows.Forms.Label();
      LabelPositive = new System.Windows.Forms.Label();
      LabelNegative = new System.Windows.Forms.Label();
      this.PanelMain.SuspendLayout();
      this.PanelMainOuter.SuspendLayout();
      this.PanelMainInner.SuspendLayout();
      this.PanelMainCenter.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageText.SuspendLayout();
      this.PanelViewSearch.SuspendLayout();
      this.ContextMenuStripSearchOnline.SuspendLayout();
      this.TabPageMonth.SuspendLayout();
      this.PanelViewSettings.SuspendLayout();
      this.PanelSettingsDetails.SuspendLayout();
      this.PanelLetter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LettersBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditMeanings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MeaningsBindingSource)).BeginInit();
      this.PanelTitle.SuspendLayout();
      this.ToolStrip.SuspendLayout();
      this.ContextMenuStripSentence.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelName
      // 
      resources.ApplyResources(LabelName, "LabelName");
      LabelName.Name = "LabelName";
      // 
      // LabelStructure
      // 
      resources.ApplyResources(LabelStructure, "LabelStructure");
      LabelStructure.Name = "LabelStructure";
      // 
      // LabelFunction
      // 
      resources.ApplyResources(LabelFunction, "LabelFunction");
      LabelFunction.Name = "LabelFunction";
      // 
      // LabelValueSimple
      // 
      resources.ApplyResources(LabelValueSimple, "LabelValueSimple");
      LabelValueSimple.Name = "LabelValueSimple";
      // 
      // LabelValueFull
      // 
      resources.ApplyResources(LabelValueFull, "LabelValueFull");
      LabelValueFull.Name = "LabelValueFull";
      // 
      // LabelMeanings
      // 
      resources.ApplyResources(LabelMeanings, "LabelMeanings");
      LabelMeanings.Name = "LabelMeanings";
      // 
      // LabelVerb
      // 
      resources.ApplyResources(LabelVerb, "LabelVerb");
      LabelVerb.Name = "LabelVerb";
      // 
      // LabelPositive
      // 
      resources.ApplyResources(LabelPositive, "LabelPositive");
      LabelPositive.Name = "LabelPositive";
      // 
      // LabelNegative
      // 
      resources.ApplyResources(LabelNegative, "LabelNegative");
      LabelNegative.Name = "LabelNegative";
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.PanelMainOuter);
      this.PanelMain.Controls.Add(this.PanelSepTop);
      this.PanelMain.Controls.Add(this.PanelTitle);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // PanelMainOuter
      // 
      this.PanelMainOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelMainOuter.Controls.Add(this.PanelMainInner);
      resources.ApplyResources(this.PanelMainOuter, "PanelMainOuter");
      this.PanelMainOuter.Name = "PanelMainOuter";
      // 
      // PanelMainInner
      // 
      this.PanelMainInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelMainInner.Controls.Add(this.PanelMainCenter);
      resources.ApplyResources(this.PanelMainInner, "PanelMainInner");
      this.PanelMainInner.Name = "PanelMainInner";
      // 
      // PanelMainCenter
      // 
      this.PanelMainCenter.Controls.Add(this.TabControl);
      resources.ApplyResources(this.PanelMainCenter, "PanelMainCenter");
      this.PanelMainCenter.Name = "PanelMainCenter";
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageText);
      this.TabControl.Controls.Add(this.TabPageMonth);
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // TabPageText
      // 
      this.TabPageText.Controls.Add(this.PanelViewSearch);
      resources.ApplyResources(this.TabPageText, "TabPageText");
      this.TabPageText.Name = "TabPageText";
      this.TabPageText.UseVisualStyleBackColor = true;
      // 
      // PanelViewSearch
      // 
      resources.ApplyResources(this.PanelViewSearch, "PanelViewSearch");
      this.PanelViewSearch.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewSearch.Controls.Add(this.ActionReset);
      this.PanelViewSearch.Controls.Add(this.ActionDelLast);
      this.PanelViewSearch.Controls.Add(this.ActionDelFirst);
      this.PanelViewSearch.Controls.Add(this.SelectCloseApp);
      this.PanelViewSearch.Controls.Add(this.EditAnalyze);
      this.PanelViewSearch.Controls.Add(this.ActionSearchOnline);
      this.PanelViewSearch.Controls.Add(this.ActionPasteFromUnicode);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToUnicode);
      this.PanelViewSearch.Controls.Add(this.ActionClear);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToClipboardMeanings);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToClipboardResult);
      this.PanelViewSearch.Controls.Add(this.EditSentence);
      this.PanelViewSearch.Controls.Add(this.EditGematria);
      this.PanelViewSearch.Controls.Add(this.LabelGematria);
      this.PanelViewSearch.Controls.Add(this.EditLetters);
      this.PanelViewSearch.Name = "PanelViewSearch";
      // 
      // ActionReset
      // 
      this.ActionReset.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionReset, "ActionReset");
      this.ActionReset.Name = "ActionReset";
      this.ActionReset.TabStop = false;
      this.ActionReset.UseVisualStyleBackColor = true;
      this.ActionReset.Click += new System.EventHandler(this.ActionReset_Click);
      // 
      // ActionDelLast
      // 
      resources.ApplyResources(this.ActionDelLast, "ActionDelLast");
      this.ActionDelLast.FlatAppearance.BorderSize = 0;
      this.ActionDelLast.Name = "ActionDelLast";
      this.ActionDelLast.TabStop = false;
      this.ActionDelLast.UseVisualStyleBackColor = true;
      this.ActionDelLast.Click += new System.EventHandler(this.ActionDelLast_Click);
      // 
      // ActionDelFirst
      // 
      resources.ApplyResources(this.ActionDelFirst, "ActionDelFirst");
      this.ActionDelFirst.FlatAppearance.BorderSize = 0;
      this.ActionDelFirst.Name = "ActionDelFirst";
      this.ActionDelFirst.TabStop = false;
      this.ActionDelFirst.UseVisualStyleBackColor = true;
      this.ActionDelFirst.Click += new System.EventHandler(this.ActionDelFirst_Click);
      // 
      // SelectCloseApp
      // 
      resources.ApplyResources(this.SelectCloseApp, "SelectCloseApp");
      this.SelectCloseApp.Name = "SelectCloseApp";
      this.SelectCloseApp.UseVisualStyleBackColor = true;
      // 
      // EditAnalyze
      // 
      resources.ApplyResources(this.EditAnalyze, "EditAnalyze");
      this.EditAnalyze.BackColor = System.Drawing.Color.MintCream;
      this.EditAnalyze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditAnalyze.Name = "EditAnalyze";
      // 
      // ActionSearchOnline
      // 
      this.ActionSearchOnline.ContextMenuStrip = this.ContextMenuStripSearchOnline;
      this.ActionSearchOnline.Cursor = System.Windows.Forms.Cursors.Default;
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.FlatAppearance.BorderSize = 0;
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      this.ActionSearchOnline.UseVisualStyleBackColor = true;
      this.ActionSearchOnline.Click += new System.EventHandler(this.ActionSearchOnline_Click);
      // 
      // ContextMenuStripSearchOnline
      // 
      this.ContextMenuStripSearchOnline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionOpenWordOnline});
      this.ContextMenuStripSearchOnline.Name = "ContextMenuSearchOnline";
      resources.ApplyResources(this.ContextMenuStripSearchOnline, "ContextMenuStripSearchOnline");
      // 
      // ActionOpenWordOnline
      // 
      resources.ApplyResources(this.ActionOpenWordOnline, "ActionOpenWordOnline");
      this.ActionOpenWordOnline.Name = "ActionOpenWordOnline";
      // 
      // ActionPasteFromUnicode
      // 
      this.ActionPasteFromUnicode.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionPasteFromUnicode, "ActionPasteFromUnicode");
      this.ActionPasteFromUnicode.Name = "ActionPasteFromUnicode";
      this.ActionPasteFromUnicode.UseVisualStyleBackColor = true;
      this.ActionPasteFromUnicode.Click += new System.EventHandler(this.ActionPasteFromUnicode_Click);
      // 
      // ActionCopyToUnicode
      // 
      resources.ApplyResources(this.ActionCopyToUnicode, "ActionCopyToUnicode");
      this.ActionCopyToUnicode.FlatAppearance.BorderSize = 0;
      this.ActionCopyToUnicode.Name = "ActionCopyToUnicode";
      this.ActionCopyToUnicode.UseVisualStyleBackColor = true;
      this.ActionCopyToUnicode.Click += new System.EventHandler(this.ActionCopyToUnicode_Click);
      // 
      // ActionClear
      // 
      resources.ApplyResources(this.ActionClear, "ActionClear");
      this.ActionClear.FlatAppearance.BorderSize = 0;
      this.ActionClear.Name = "ActionClear";
      this.ActionClear.UseVisualStyleBackColor = true;
      this.ActionClear.Click += new System.EventHandler(this.ActionClear_Click);
      // 
      // ActionCopyToClipboardMeanings
      // 
      resources.ApplyResources(this.ActionCopyToClipboardMeanings, "ActionCopyToClipboardMeanings");
      this.ActionCopyToClipboardMeanings.FlatAppearance.BorderSize = 0;
      this.ActionCopyToClipboardMeanings.Name = "ActionCopyToClipboardMeanings";
      this.ActionCopyToClipboardMeanings.UseVisualStyleBackColor = true;
      this.ActionCopyToClipboardMeanings.Click += new System.EventHandler(this.ActionCopyToClipboardMeanings_Click);
      // 
      // ActionCopyToClipboardResult
      // 
      resources.ApplyResources(this.ActionCopyToClipboardResult, "ActionCopyToClipboardResult");
      this.ActionCopyToClipboardResult.FlatAppearance.BorderSize = 0;
      this.ActionCopyToClipboardResult.Name = "ActionCopyToClipboardResult";
      this.ActionCopyToClipboardResult.UseVisualStyleBackColor = true;
      this.ActionCopyToClipboardResult.Click += new System.EventHandler(this.ActionCopyToClipboardResults_Click);
      // 
      // EditSentence
      // 
      resources.ApplyResources(this.EditSentence, "EditSentence");
      this.EditSentence.BackColor = System.Drawing.SystemColors.Window;
      this.EditSentence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditSentence.ContextMenuStrip = this.ContextMenuStripSentence;
      this.EditSentence.Name = "EditSentence";
      this.EditSentence.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // EditGematria
      // 
      resources.ApplyResources(this.EditGematria, "EditGematria");
      this.EditGematria.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematria.Name = "EditGematria";
      this.EditGematria.ReadOnly = true;
      this.EditGematria.TabStop = false;
      // 
      // LabelGematria
      // 
      resources.ApplyResources(this.LabelGematria, "LabelGematria");
      this.LabelGematria.Name = "LabelGematria";
      // 
      // EditLetters
      // 
      this.EditLetters.BackColor = System.Drawing.Color.Transparent;
      this.EditLetters.InputBackColor = System.Drawing.Color.AliceBlue;
      this.EditLetters.LettersBackground = System.Drawing.Color.LightYellow;
      resources.ApplyResources(this.EditLetters, "EditLetters");
      this.EditLetters.MaxLength = 20;
      this.EditLetters.Name = "EditLetters";
      this.EditLetters.ShowValues = true;
      this.EditLetters.TextChanged += new System.EventHandler(this.EditLetters_InputTextChanged);
      // 
      // TabPageMonth
      // 
      this.TabPageMonth.Controls.Add(this.PanelViewSettings);
      resources.ApplyResources(this.TabPageMonth, "TabPageMonth");
      this.TabPageMonth.Name = "TabPageMonth";
      this.TabPageMonth.UseVisualStyleBackColor = true;
      // 
      // PanelViewSettings
      // 
      resources.ApplyResources(this.PanelViewSettings, "PanelViewSettings");
      this.PanelViewSettings.Controls.Add(this.PanelSettingsDetails);
      this.PanelViewSettings.Name = "PanelViewSettings";
      // 
      // PanelSettingsDetails
      // 
      this.PanelSettingsDetails.BackColor = System.Drawing.SystemColors.Control;
      this.PanelSettingsDetails.Controls.Add(this.PanelLetter);
      this.PanelSettingsDetails.Controls.Add(this.ActionDeleteMeaning);
      this.PanelSettingsDetails.Controls.Add(this.ActionAddMeaning);
      this.PanelSettingsDetails.Controls.Add(LabelMeanings);
      this.PanelSettingsDetails.Controls.Add(this.EditMeanings);
      resources.ApplyResources(this.PanelSettingsDetails, "PanelSettingsDetails");
      this.PanelSettingsDetails.Name = "PanelSettingsDetails";
      // 
      // PanelLetter
      // 
      this.PanelLetter.Controls.Add(this.ComboBoxCode);
      this.PanelLetter.Controls.Add(this.TextBoxStructure);
      this.PanelLetter.Controls.Add(this.LabelHebrew);
      this.PanelLetter.Controls.Add(LabelStructure);
      this.PanelLetter.Controls.Add(LabelNegative);
      this.PanelLetter.Controls.Add(LabelFunction);
      this.PanelLetter.Controls.Add(this.TextBoxNegative);
      this.PanelLetter.Controls.Add(this.TextBoxName);
      this.PanelLetter.Controls.Add(LabelPositive);
      this.PanelLetter.Controls.Add(this.TextBoxFunction);
      this.PanelLetter.Controls.Add(this.TextBoxPositive);
      this.PanelLetter.Controls.Add(LabelName);
      this.PanelLetter.Controls.Add(LabelVerb);
      this.PanelLetter.Controls.Add(LabelValueSimple);
      this.PanelLetter.Controls.Add(this.TextBoxVerb);
      this.PanelLetter.Controls.Add(this.TextBoxValueSimple);
      this.PanelLetter.Controls.Add(LabelValueFull);
      this.PanelLetter.Controls.Add(this.TextBoxValueFull);
      this.PanelLetter.Controls.Add(this.ActionRestoreDefaults);
      resources.ApplyResources(this.PanelLetter, "PanelLetter");
      this.PanelLetter.Name = "PanelLetter";
      // 
      // ComboBoxCode
      // 
      this.ComboBoxCode.BackColor = System.Drawing.Color.LightYellow;
      this.ComboBoxCode.DataSource = this.LettersBindingSource;
      this.ComboBoxCode.DisplayMember = "Code";
      this.ComboBoxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      resources.ApplyResources(this.ComboBoxCode, "ComboBoxCode");
      this.ComboBoxCode.FormattingEnabled = true;
      this.ComboBoxCode.Name = "ComboBoxCode";
      this.ComboBoxCode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCode_SelectedIndexChanged);
      // 
      // LettersBindingSource
      // 
      this.LettersBindingSource.AllowNew = true;
      this.LettersBindingSource.DataMember = "Letters";
      this.LettersBindingSource.DataSource = this.DataSet;
      this.LettersBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.BindingSource_DataError);
      // 
      // DataSet
      // 
      this.DataSet.DataSetName = "DataSet";
      this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // TextBoxStructure
      // 
      this.TextBoxStructure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxStructure.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Structure", true));
      resources.ApplyResources(this.TextBoxStructure, "TextBoxStructure");
      this.TextBoxStructure.Name = "TextBoxStructure";
      // 
      // LabelHebrew
      // 
      this.LabelHebrew.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Hebrew", true));
      resources.ApplyResources(this.LabelHebrew, "LabelHebrew");
      this.LabelHebrew.Name = "LabelHebrew";
      // 
      // TextBoxNegative
      // 
      this.TextBoxNegative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxNegative.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Negative", true));
      resources.ApplyResources(this.TextBoxNegative, "TextBoxNegative");
      this.TextBoxNegative.Name = "TextBoxNegative";
      // 
      // TextBoxName
      // 
      this.TextBoxName.BackColor = System.Drawing.Color.LightYellow;
      this.TextBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Name", true));
      resources.ApplyResources(this.TextBoxName, "TextBoxName");
      this.TextBoxName.Name = "TextBoxName";
      this.TextBoxName.ReadOnly = true;
      // 
      // TextBoxFunction
      // 
      this.TextBoxFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxFunction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Function", true));
      resources.ApplyResources(this.TextBoxFunction, "TextBoxFunction");
      this.TextBoxFunction.Name = "TextBoxFunction";
      // 
      // TextBoxPositive
      // 
      this.TextBoxPositive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxPositive.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Positive", true));
      resources.ApplyResources(this.TextBoxPositive, "TextBoxPositive");
      this.TextBoxPositive.Name = "TextBoxPositive";
      // 
      // TextBoxVerb
      // 
      this.TextBoxVerb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxVerb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Verb", true));
      resources.ApplyResources(this.TextBoxVerb, "TextBoxVerb");
      this.TextBoxVerb.Name = "TextBoxVerb";
      // 
      // TextBoxValueSimple
      // 
      this.TextBoxValueSimple.BackColor = System.Drawing.Color.LavenderBlush;
      this.TextBoxValueSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxValueSimple.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "ValueSimple", true));
      resources.ApplyResources(this.TextBoxValueSimple, "TextBoxValueSimple");
      this.TextBoxValueSimple.Name = "TextBoxValueSimple";
      this.TextBoxValueSimple.ReadOnly = true;
      // 
      // TextBoxValueFull
      // 
      this.TextBoxValueFull.BackColor = System.Drawing.Color.LavenderBlush;
      this.TextBoxValueFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxValueFull.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "ValueFull", true));
      resources.ApplyResources(this.TextBoxValueFull, "TextBoxValueFull");
      this.TextBoxValueFull.Name = "TextBoxValueFull";
      this.TextBoxValueFull.ReadOnly = true;
      // 
      // ActionRestoreDefaults
      // 
      this.ActionRestoreDefaults.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionRestoreDefaults, "ActionRestoreDefaults");
      this.ActionRestoreDefaults.LinkColor = System.Drawing.Color.Navy;
      this.ActionRestoreDefaults.Name = "ActionRestoreDefaults";
      this.ActionRestoreDefaults.TabStop = true;
      this.ActionRestoreDefaults.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionRestoreDefaults_LinkClicked);
      // 
      // ActionDeleteMeaning
      // 
      resources.ApplyResources(this.ActionDeleteMeaning, "ActionDeleteMeaning");
      this.ActionDeleteMeaning.FlatAppearance.BorderSize = 0;
      this.ActionDeleteMeaning.Name = "ActionDeleteMeaning";
      this.ActionDeleteMeaning.UseVisualStyleBackColor = true;
      this.ActionDeleteMeaning.Click += new System.EventHandler(this.ActionDeleteMeaning_Click);
      // 
      // ActionAddMeaning
      // 
      resources.ApplyResources(this.ActionAddMeaning, "ActionAddMeaning");
      this.ActionAddMeaning.FlatAppearance.BorderSize = 0;
      this.ActionAddMeaning.Name = "ActionAddMeaning";
      this.ActionAddMeaning.UseVisualStyleBackColor = true;
      this.ActionAddMeaning.Click += new System.EventHandler(this.ActionAddMeaning_Click);
      // 
      // EditMeanings
      // 
      this.EditMeanings.AllowUserToAddRows = false;
      this.EditMeanings.AllowUserToDeleteRows = false;
      this.EditMeanings.AllowUserToResizeColumns = false;
      this.EditMeanings.AllowUserToResizeRows = false;
      resources.ApplyResources(this.EditMeanings, "EditMeanings");
      this.EditMeanings.AutoGenerateColumns = false;
      this.EditMeanings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.EditMeanings.ColumnHeadersVisible = false;
      this.EditMeanings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
      this.EditMeanings.DataSource = this.MeaningsBindingSource;
      this.EditMeanings.MultiSelect = false;
      this.EditMeanings.Name = "EditMeanings";
      this.EditMeanings.RowHeadersVisible = false;
      this.EditMeanings.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EditMeanings_CellBeginEdit);
      this.EditMeanings.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditMeanings_CellEndEdit);
      this.EditMeanings.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EditMeanings_CellValidating);
      this.EditMeanings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.EditMeanings_DataError);
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.dataGridViewTextBoxColumn2.DataPropertyName = "Meaning";
      resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // MeaningsBindingSource
      // 
      this.MeaningsBindingSource.AllowNew = true;
      this.MeaningsBindingSource.DataMember = "Letters_Meanings";
      this.MeaningsBindingSource.DataSource = this.LettersBindingSource;
      this.MeaningsBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.BindingSource_DataError);
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.LabelTitle);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // LabelTitle
      // 
      this.LabelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // TimerTooltip
      // 
      this.TimerTooltip.Interval = 500;
      this.TimerTooltip.Tick += new System.EventHandler(this.TimerTooltip_Tick);
      // 
      // ToolStrip
      // 
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionExit,
            this.Sep4,
            this.ActionHelp,
            this.MenuWeb,
            this.Sep6,
            this.ActionPreferences,
            this.MenuSettings,
            this.ActionViewAnalysis,
            this.ActionViewLetters,
            this.ActionSearchTerm,
            this.toolStripSeparator1,
            this.MenuTools,
            this.MenuWebLinks});
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // ActionExit
      // 
      this.ActionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionExit, "ActionExit");
      this.ActionExit.Name = "ActionExit";
      this.ActionExit.Padding = new System.Windows.Forms.Padding(5);
      this.ActionExit.Click += new System.EventHandler(this.ActionExit_Click);
      this.ActionExit.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionExit.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep4
      // 
      this.Sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep4.Name = "Sep4";
      resources.ApplyResources(this.Sep4, "Sep4");
      // 
      // ActionHelp
      // 
      this.ActionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.Padding = new System.Windows.Forms.Padding(5);
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      this.ActionHelp.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionHelp.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // MenuWeb
      // 
      this.MenuWeb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.MenuWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuWeb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionAbout,
            this.ActionWebCheckUpdate,
            this.toolStripSeparator7,
            this.ActionCreateGitHubIssue,
            this.ActionWebQA,
            this.toolStripSeparator2,
            this.ActionWebHome,
            this.ActionWebContact,
            this.ActionWebTipeee,
            this.toolStripSeparator5,
            this.ActionWebLinkedIn,
            this.ActionWebTwitter,
            this.ActionWebYouTube,
            this.toolStripSeparator6,
            this.ActionDownloadHebrewCalendar,
            this.ActionDownloadHebrewWords});
      resources.ApplyResources(this.MenuWeb, "MenuWeb");
      this.MenuWeb.Name = "MenuWeb";
      // 
      // ActionAbout
      // 
      this.ActionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionAbout, "ActionAbout");
      this.ActionAbout.Name = "ActionAbout";
      this.ActionAbout.Click += new System.EventHandler(this.ActionAbout_Click);
      // 
      // ActionWebCheckUpdate
      // 
      this.ActionWebCheckUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebCheckUpdate, "ActionWebCheckUpdate");
      this.ActionWebCheckUpdate.Name = "ActionWebCheckUpdate";
      this.ActionWebCheckUpdate.Click += new System.EventHandler(this.ActionCheckUpdate_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // ActionCreateGitHubIssue
      // 
      this.ActionCreateGitHubIssue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionCreateGitHubIssue, "ActionCreateGitHubIssue");
      this.ActionCreateGitHubIssue.Name = "ActionCreateGitHubIssue";
      this.ActionCreateGitHubIssue.Tag = "";
      this.ActionCreateGitHubIssue.Click += new System.EventHandler(this.ActionCreateGitHubIssue_Click);
      // 
      // ActionWebQA
      // 
      resources.ApplyResources(this.ActionWebQA, "ActionWebQA");
      this.ActionWebQA.Name = "ActionWebQA";
      this.ActionWebQA.Tag = "http://asherhaimhalevi.free-bb.fr/";
      this.ActionWebQA.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // ActionWebHome
      // 
      this.ActionWebHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebHome, "ActionWebHome");
      this.ActionWebHome.Name = "ActionWebHome";
      this.ActionWebHome.Click += new System.EventHandler(this.ActionApplicationHome_Click);
      // 
      // ActionWebContact
      // 
      this.ActionWebContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebContact, "ActionWebContact");
      this.ActionWebContact.Name = "ActionWebContact";
      this.ActionWebContact.Click += new System.EventHandler(this.ActionContact_Click);
      // 
      // ActionWebTipeee
      // 
      this.ActionWebTipeee.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebTipeee, "ActionWebTipeee");
      this.ActionWebTipeee.Name = "ActionWebTipeee";
      this.ActionWebTipeee.Tag = "https://fr.tipeee.com/ordisoftware";
      this.ActionWebTipeee.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // ActionWebLinkedIn
      // 
      this.ActionWebLinkedIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebLinkedIn, "ActionWebLinkedIn");
      this.ActionWebLinkedIn.Name = "ActionWebLinkedIn";
      this.ActionWebLinkedIn.Tag = "https://www.linkedin.com/in/ordisoftware";
      this.ActionWebLinkedIn.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionWebTwitter
      // 
      this.ActionWebTwitter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebTwitter, "ActionWebTwitter");
      this.ActionWebTwitter.Name = "ActionWebTwitter";
      this.ActionWebTwitter.Tag = "https://twitter.com/ordisoftware";
      this.ActionWebTwitter.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionWebYouTube
      // 
      this.ActionWebYouTube.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebYouTube, "ActionWebYouTube");
      this.ActionWebYouTube.Name = "ActionWebYouTube";
      this.ActionWebYouTube.Tag = "https://www.youtube.com/user/Ordisoftware";
      this.ActionWebYouTube.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      // 
      // ActionDownloadHebrewCalendar
      // 
      resources.ApplyResources(this.ActionDownloadHebrewCalendar, "ActionDownloadHebrewCalendar");
      this.ActionDownloadHebrewCalendar.Name = "ActionDownloadHebrewCalendar";
      this.ActionDownloadHebrewCalendar.Tag = "http://www.ordisoftware.com/projects/hebrew-calendar";
      this.ActionDownloadHebrewCalendar.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionDownloadHebrewWords
      // 
      resources.ApplyResources(this.ActionDownloadHebrewWords, "ActionDownloadHebrewWords");
      this.ActionDownloadHebrewWords.Name = "ActionDownloadHebrewWords";
      this.ActionDownloadHebrewWords.Tag = "http://www.ordisoftware.com/projects/hebrew-words";
      this.ActionDownloadHebrewWords.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // Sep6
      // 
      this.Sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep6.Name = "Sep6";
      resources.ApplyResources(this.Sep6, "Sep6");
      // 
      // ActionPreferences
      // 
      this.ActionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPreferences, "ActionPreferences");
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      this.ActionPreferences.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionPreferences.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // MenuSettings
      // 
      this.MenuSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.MenuSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuitemScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.EditShowTips,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      resources.ApplyResources(this.MenuSettings, "MenuSettings");
      this.MenuSettings.Name = "MenuSettings";
      // 
      // MenuitemScreenPosition
      // 
      this.MenuitemScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      resources.ApplyResources(this.MenuitemScreenPosition, "MenuitemScreenPosition");
      this.MenuitemScreenPosition.Name = "MenuitemScreenPosition";
      // 
      // EditScreenNone
      // 
      this.EditScreenNone.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenNone, "EditScreenNone");
      this.EditScreenNone.Name = "EditScreenNone";
      this.EditScreenNone.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopLeft
      // 
      this.EditScreenTopLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopLeft, "EditScreenTopLeft");
      this.EditScreenTopLeft.Name = "EditScreenTopLeft";
      this.EditScreenTopLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopRight
      // 
      this.EditScreenTopRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopRight, "EditScreenTopRight");
      this.EditScreenTopRight.Name = "EditScreenTopRight";
      this.EditScreenTopRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomLeft
      // 
      this.EditScreenBottomLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomLeft, "EditScreenBottomLeft");
      this.EditScreenBottomLeft.Name = "EditScreenBottomLeft";
      this.EditScreenBottomLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomRight
      // 
      this.EditScreenBottomRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomRight, "EditScreenBottomRight");
      this.EditScreenBottomRight.Name = "EditScreenBottomRight";
      this.EditScreenBottomRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenCenter
      // 
      this.EditScreenCenter.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenCenter, "EditScreenCenter");
      this.EditScreenCenter.Name = "EditScreenCenter";
      this.EditScreenCenter.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // ActionResetWinSettings
      // 
      resources.ApplyResources(this.ActionResetWinSettings, "ActionResetWinSettings");
      this.ActionResetWinSettings.Name = "ActionResetWinSettings";
      this.ActionResetWinSettings.Click += new System.EventHandler(this.ActionResetWinSettings_Click);
      // 
      // Sep7
      // 
      this.Sep7.Name = "Sep7";
      resources.ApplyResources(this.Sep7, "Sep7");
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowTips, "EditShowTips");
      this.EditShowTips.Name = "EditShowTips";
      // 
      // EditESCtoExit
      // 
      this.EditESCtoExit.CheckOnClick = true;
      resources.ApplyResources(this.EditESCtoExit, "EditESCtoExit");
      this.EditESCtoExit.Name = "EditESCtoExit";
      // 
      // EditConfirmClosing
      // 
      resources.ApplyResources(this.EditConfirmClosing, "EditConfirmClosing");
      this.EditConfirmClosing.CheckOnClick = true;
      this.EditConfirmClosing.Name = "EditConfirmClosing";
      // 
      // ActionViewAnalysis
      // 
      this.ActionViewAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewAnalysis, "ActionViewAnalysis");
      this.ActionViewAnalysis.Name = "ActionViewAnalysis";
      this.ActionViewAnalysis.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewAnalysis.Click += new System.EventHandler(this.ActionViewAnalysis_Click);
      this.ActionViewAnalysis.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionViewAnalysis.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionViewLetters
      // 
      this.ActionViewLetters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewLetters, "ActionViewLetters");
      this.ActionViewLetters.Name = "ActionViewLetters";
      this.ActionViewLetters.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewLetters.Click += new System.EventHandler(this.ActionViewLetters_Click);
      this.ActionViewLetters.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionViewLetters.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionSearchTerm
      // 
      this.ActionSearchTerm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchTerm, "ActionSearchTerm");
      this.ActionSearchTerm.Name = "ActionSearchTerm";
      this.ActionSearchTerm.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchTerm.Click += new System.EventHandler(this.ActionSearchTerm_Click);
      this.ActionSearchTerm.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionSearchTerm.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // MenuTools
      // 
      this.MenuTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionShowMethodNotice,
            this.ActionShowGrammarGuide,
            this.toolStripSeparator4,
            this.ActionOpenShorashon,
            this.toolStripSeparator3,
            this.ActionOpenLexilogosOld,
            this.ActionOpenLexilogosModern});
      resources.ApplyResources(this.MenuTools, "MenuTools");
      this.MenuTools.Name = "MenuTools";
      // 
      // ActionShowMethodNotice
      // 
      resources.ApplyResources(this.ActionShowMethodNotice, "ActionShowMethodNotice");
      this.ActionShowMethodNotice.Name = "ActionShowMethodNotice";
      this.ActionShowMethodNotice.Click += new System.EventHandler(this.ActionShowMethodNotice_Click);
      // 
      // ActionShowGrammarGuide
      // 
      resources.ApplyResources(this.ActionShowGrammarGuide, "ActionShowGrammarGuide");
      this.ActionShowGrammarGuide.Name = "ActionShowGrammarGuide";
      this.ActionShowGrammarGuide.Click += new System.EventHandler(this.ActionShowGrammarGuide_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
      // 
      // ActionOpenShorashon
      // 
      resources.ApplyResources(this.ActionOpenShorashon, "ActionOpenShorashon");
      this.ActionOpenShorashon.Name = "ActionOpenShorashon";
      this.ActionOpenShorashon.Tag = "http://shorashon.free.fr/online/";
      this.ActionOpenShorashon.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // ActionOpenLexilogosOld
      // 
      resources.ApplyResources(this.ActionOpenLexilogosOld, "ActionOpenLexilogosOld");
      this.ActionOpenLexilogosOld.Name = "ActionOpenLexilogosOld";
      this.ActionOpenLexilogosOld.Tag = "https://www.lexilogos.com/hebreu_ancien_dictionnaire.htm";
      this.ActionOpenLexilogosOld.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionOpenLexilogosModern
      // 
      resources.ApplyResources(this.ActionOpenLexilogosModern, "ActionOpenLexilogosModern");
      this.ActionOpenLexilogosModern.Name = "ActionOpenLexilogosModern";
      this.ActionOpenLexilogosModern.Tag = "https://www.lexilogos.com/hebreu_moderne_dictionnaire.htm";
      this.ActionOpenLexilogosModern.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // MenuWebLinks
      // 
      this.MenuWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuWebLinks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionOpenWebLinkTemplateFolder,
            this.ActionOpenWebLinkTemplateLink});
      resources.ApplyResources(this.MenuWebLinks, "MenuWebLinks");
      this.MenuWebLinks.Name = "MenuWebLinks";
      // 
      // ActionOpenWebLinkTemplateFolder
      // 
      resources.ApplyResources(this.ActionOpenWebLinkTemplateFolder, "ActionOpenWebLinkTemplateFolder");
      this.ActionOpenWebLinkTemplateFolder.Name = "ActionOpenWebLinkTemplateFolder";
      // 
      // ActionOpenWebLinkTemplateLink
      // 
      resources.ApplyResources(this.ActionOpenWebLinkTemplateLink, "ActionOpenWebLinkTemplateLink");
      this.ActionOpenWebLinkTemplateLink.Name = "ActionOpenWebLinkTemplateLink";
      this.ActionOpenWebLinkTemplateLink.Tag = "";
      // 
      // LettersTableAdapter
      // 
      this.LettersTableAdapter.ClearBeforeFill = true;
      // 
      // TableAdapterManager
      // 
      this.TableAdapterManager.BackupDataSetBeforeUpdate = false;
      this.TableAdapterManager.LettersTableAdapter = this.LettersTableAdapter;
      this.TableAdapterManager.MeaningsTableAdapter = this.MeaningsTableAdapter;
      this.TableAdapterManager.UpdateOrder = Ordisoftware.HebrewLetters.Data.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // MeaningsTableAdapter
      // 
      this.MeaningsTableAdapter.ClearBeforeFill = true;
      // 
      // ContextMenuStripSentence
      // 
      this.ContextMenuStripSentence.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionCopy,
            this.ActionCut,
            this.ActionPaste});
      this.ContextMenuStripSentence.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuStripSentence, "ContextMenuStripSentence");
      this.ContextMenuStripSentence.Opened += new System.EventHandler(this.ContextMenuStripSentence_Opened);
      // 
      // ActionCopy
      // 
      resources.ApplyResources(this.ActionCopy, "ActionCopy");
      this.ActionCopy.Name = "ActionCopy";
      this.ActionCopy.Click += new System.EventHandler(this.ActionCopy_Click);
      // 
      // ActionCut
      // 
      resources.ApplyResources(this.ActionCut, "ActionCut");
      this.ActionCut.Name = "ActionCut";
      this.ActionCut.Click += new System.EventHandler(this.ActionCut_Click);
      // 
      // ActionPaste
      // 
      resources.ApplyResources(this.ActionPaste, "ActionPaste");
      this.ActionPaste.Name = "ActionPaste";
      this.ActionPaste.Click += new System.EventHandler(this.ActionPaste_Click);
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.ToolStrip);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.ClientSizeChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.LocationChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.PanelMain.ResumeLayout(false);
      this.PanelMainOuter.ResumeLayout(false);
      this.PanelMainInner.ResumeLayout(false);
      this.PanelMainCenter.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.TabPageText.ResumeLayout(false);
      this.PanelViewSearch.ResumeLayout(false);
      this.PanelViewSearch.PerformLayout();
      this.ContextMenuStripSearchOnline.ResumeLayout(false);
      this.TabPageMonth.ResumeLayout(false);
      this.PanelViewSettings.ResumeLayout(false);
      this.PanelSettingsDetails.ResumeLayout(false);
      this.PanelSettingsDetails.PerformLayout();
      this.PanelLetter.ResumeLayout(false);
      this.PanelLetter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LettersBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditMeanings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MeaningsBindingSource)).EndInit();
      this.PanelTitle.ResumeLayout(false);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ContextMenuStripSentence.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton ActionExit;
    private System.Windows.Forms.ToolStripSeparator Sep4;
    private System.Windows.Forms.ToolStripDropDownButton MenuSettings;
    private System.Windows.Forms.ToolStripMenuItem MenuitemScreenPosition;
    private System.Windows.Forms.ToolStripButton ActionHelp;
    private System.Windows.Forms.ToolStripSeparator Sep7;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenNone;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenCenter;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopRight;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomRight;
    internal System.Windows.Forms.ToolStripMenuItem EditConfirmClosing;
    internal System.Windows.Forms.ToolStripMenuItem EditShowTips;
    private System.Windows.Forms.ToolStripMenuItem ActionResetWinSettings;
    private System.Windows.Forms.ToolStripSeparator Sep6;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Panel PanelMainOuter;
    private System.Windows.Forms.Panel PanelMainInner;
    private System.Windows.Forms.Panel PanelMainCenter;
    private System.Windows.Forms.Timer TimerTooltip;
    internal Ordisoftware.HebrewCommon.LettersControl EditLetters;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageText;
    private System.Windows.Forms.Panel PanelViewSearch;
    private System.Windows.Forms.TabPage TabPageMonth;
    private System.Windows.Forms.Panel PanelViewSettings;
    private System.Windows.Forms.ToolStripButton ActionViewAnalysis;
    private System.Windows.Forms.ToolStripButton ActionViewLetters;
    internal Data.DataSet DataSet;
    internal System.Windows.Forms.BindingSource LettersBindingSource;
    private Data.DataSetTableAdapters.LettersTableAdapter LettersTableAdapter;
    private Data.DataSetTableAdapters.TableAdapterManager TableAdapterManager;
    private System.Windows.Forms.TextBox TextBoxName;
    private System.Windows.Forms.TextBox TextBoxValueSimple;
    private System.Windows.Forms.TextBox TextBoxValueFull;
    private Data.DataSetTableAdapters.MeaningsTableAdapter MeaningsTableAdapter;
    private System.Windows.Forms.Panel PanelSettingsDetails;
    private System.Windows.Forms.LinkLabel ActionRestoreDefaults;
    private System.Windows.Forms.Button ActionDeleteMeaning;
    private System.Windows.Forms.Button ActionAddMeaning;
    private System.Windows.Forms.Button ActionCopyToClipboardResult;
    private System.Windows.Forms.Panel EditAnalyze;
    internal System.Windows.Forms.CheckBox SelectCloseApp;
    private System.Windows.Forms.Button ActionCopyToClipboardMeanings;
    private System.Windows.Forms.ToolStripButton ActionPreferences;
    internal System.Windows.Forms.Label LabelGematria;
    internal System.Windows.Forms.TextBox EditGematria;
    private System.Windows.Forms.Button ActionReset;
    private System.Windows.Forms.Button ActionDelLast;
    private System.Windows.Forms.Button ActionDelFirst;
    private System.Windows.Forms.ToolStripDropDownButton MenuWeb;
    private System.Windows.Forms.ToolStripMenuItem ActionWebHome;
    private System.Windows.Forms.ToolStripMenuItem ActionWebContact;
    private System.Windows.Forms.ToolStripMenuItem ActionCreateGitHubIssue;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionWebCheckUpdate;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem ActionDownloadHebrewWords;
    private System.Windows.Forms.ToolStripMenuItem ActionDownloadHebrewCalendar;
    private System.Windows.Forms.DataGridView EditMeanings;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.Label LabelHebrew;
    private System.Windows.Forms.ComboBox ComboBoxCode;
    private System.Windows.Forms.Panel PanelLetter;
    private System.Windows.Forms.Button ActionCopyToUnicode;
    private System.Windows.Forms.Button ActionSearchOnline;
    private System.Windows.Forms.ContextMenuStrip ContextMenuStripSearchOnline;
    private System.Windows.Forms.Button ActionPasteFromUnicode;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton ActionSearchTerm;
    private System.Windows.Forms.ToolStripDropDownButton MenuTools;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenShorashon;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenLexilogosOld;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenLexilogosModern;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenWordOnline;
    internal System.Windows.Forms.TextBox EditSentence;
    internal System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    private System.Windows.Forms.ToolStripMenuItem ActionWebTwitter;
    private System.Windows.Forms.ToolStripMenuItem ActionWebYouTube;
    private System.Windows.Forms.ToolStripMenuItem ActionWebTipeee;
    private System.Windows.Forms.ToolStripMenuItem ActionWebLinkedIn;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem ActionAbout;
    private System.Windows.Forms.ToolStripMenuItem ActionWebQA;
    private System.Windows.Forms.ToolStripDropDownButton MenuWebLinks;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenWebLinkTemplateFolder;
    private System.Windows.Forms.ToolStripMenuItem ActionShowGrammarGuide;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenWebLinkTemplateLink;
    private System.Windows.Forms.ToolStripMenuItem ActionShowMethodNotice;
    internal System.Windows.Forms.BindingSource MeaningsBindingSource;
    internal System.Windows.Forms.TextBox TextBoxStructure;
    internal System.Windows.Forms.TextBox TextBoxFunction;
    internal System.Windows.Forms.TextBox TextBoxVerb;
    internal System.Windows.Forms.TextBox TextBoxNegative;
    internal System.Windows.Forms.TextBox TextBoxPositive;
    internal System.Windows.Forms.Button ActionClear;
    private System.Windows.Forms.ContextMenuStrip ContextMenuStripSentence;
    private System.Windows.Forms.ToolStripMenuItem ActionCopy;
    private System.Windows.Forms.ToolStripMenuItem ActionCut;
    private System.Windows.Forms.ToolStripMenuItem ActionPaste;
  }
}
