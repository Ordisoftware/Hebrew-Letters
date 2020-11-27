namespace Ordisoftware.Hebrew.Letters
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
      this.EditGematriaFull = new Ordisoftware.Core.UndoRedoTextBox();
      this.LabelGematriaFull = new System.Windows.Forms.Label();
      this.LabelGematriaSimple = new System.Windows.Forms.Label();
      this.ActionReset = new System.Windows.Forms.Button();
      this.ActionDelLast = new System.Windows.Forms.Button();
      this.ActionDelFirst = new System.Windows.Forms.Button();
      this.EditCopyToClipboardCloseApp = new System.Windows.Forms.CheckBox();
      this.EditAnalyze = new System.Windows.Forms.Panel();
      this.ActionSearchOnline = new System.Windows.Forms.Button();
      this.ContextMenuSearchOnline = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionOpenWordOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionPasteFromUnicode = new System.Windows.Forms.Button();
      this.ActionCopyToUnicode = new System.Windows.Forms.Button();
      this.ActionClear = new System.Windows.Forms.Button();
      this.ActionSnapshot = new System.Windows.Forms.Button();
      this.ActionCopyToClipboardMeanings = new System.Windows.Forms.Button();
      this.ActionCopyToClipboardResult = new System.Windows.Forms.Button();
      this.EditSentence = new Ordisoftware.Core.UndoRedoTextBox();
      this.EditGematriaSimple = new Ordisoftware.Core.UndoRedoTextBox();
      this.LabelGematria = new System.Windows.Forms.Label();
      this.EditLetters = new Ordisoftware.Hebrew.LettersControl();
      this.TabPageMonth = new System.Windows.Forms.TabPage();
      this.PanelViewSettings = new System.Windows.Forms.Panel();
      this.PanelSettingsDetails = new System.Windows.Forms.Panel();
      this.PanelLetter = new System.Windows.Forms.Panel();
      this.ComboBoxCode = new System.Windows.Forms.ComboBox();
      this.LettersBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.DataSet = new Ordisoftware.Hebrew.Letters.Data.DataSet();
      this.TextBoxStructure = new Ordisoftware.Core.UndoRedoTextBox();
      this.LabelHebrew = new System.Windows.Forms.Label();
      this.TextBoxNegative = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxName = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxFunction = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxPositive = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxVerb = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxValueSimple = new Ordisoftware.Core.UndoRedoTextBox();
      this.TextBoxValueFull = new Ordisoftware.Core.UndoRedoTextBox();
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
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.Sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.ActionSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.MenuitemScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.EditUseAdvancedDialogBoxes = new System.Windows.Forms.ToolStripMenuItem();
      this.EditSoundsEnabled = new System.Windows.Forms.ToolStripMenuItem();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewAnalysis = new System.Windows.Forms.ToolStripButton();
      this.ActionViewLetters = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSearchTerm = new System.Windows.Forms.ToolStripButton();
      this.ActionNewInstance = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionShowMethodNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenShorashon = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenLexilogosOld = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenLexilogosModern = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewLog = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewStats = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.LettersTableAdapter = new Ordisoftware.Hebrew.Letters.Data.DataSetTableAdapters.LettersTableAdapter();
      this.TableAdapterManager = new Ordisoftware.Hebrew.Letters.Data.DataSetTableAdapters.TableAdapterManager();
      this.MeaningsTableAdapter = new Ordisoftware.Hebrew.Letters.Data.DataSetTableAdapters.MeaningsTableAdapter();
      this.TimerProcesses = new System.Windows.Forms.Timer(this.components);
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
      this.ContextMenuSearchOnline.SuspendLayout();
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
      this.PanelViewSearch.Controls.Add(this.EditGematriaFull);
      this.PanelViewSearch.Controls.Add(this.LabelGematriaFull);
      this.PanelViewSearch.Controls.Add(this.LabelGematriaSimple);
      this.PanelViewSearch.Controls.Add(this.ActionReset);
      this.PanelViewSearch.Controls.Add(this.ActionDelLast);
      this.PanelViewSearch.Controls.Add(this.ActionDelFirst);
      this.PanelViewSearch.Controls.Add(this.EditCopyToClipboardCloseApp);
      this.PanelViewSearch.Controls.Add(this.EditAnalyze);
      this.PanelViewSearch.Controls.Add(this.ActionSearchOnline);
      this.PanelViewSearch.Controls.Add(this.ActionPasteFromUnicode);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToUnicode);
      this.PanelViewSearch.Controls.Add(this.ActionClear);
      this.PanelViewSearch.Controls.Add(this.ActionSnapshot);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToClipboardMeanings);
      this.PanelViewSearch.Controls.Add(this.ActionCopyToClipboardResult);
      this.PanelViewSearch.Controls.Add(this.EditSentence);
      this.PanelViewSearch.Controls.Add(this.EditGematriaSimple);
      this.PanelViewSearch.Controls.Add(this.LabelGematria);
      this.PanelViewSearch.Controls.Add(this.EditLetters);
      this.PanelViewSearch.Name = "PanelViewSearch";
      // 
      // EditGematriaFull
      // 
      resources.ApplyResources(this.EditGematriaFull, "EditGematriaFull");
      this.EditGematriaFull.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaFull.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaFull.Name = "EditGematriaFull";
      this.EditGematriaFull.ReadOnly = true;
      // 
      // LabelGematriaFull
      // 
      resources.ApplyResources(this.LabelGematriaFull, "LabelGematriaFull");
      this.LabelGematriaFull.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelGematriaFull.Name = "LabelGematriaFull";
      // 
      // LabelGematriaSimple
      // 
      resources.ApplyResources(this.LabelGematriaSimple, "LabelGematriaSimple");
      this.LabelGematriaSimple.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelGematriaSimple.Name = "LabelGematriaSimple";
      // 
      // ActionReset
      // 
      this.ActionReset.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionReset, "ActionReset");
      this.ActionReset.Name = "ActionReset";
      this.ActionReset.UseVisualStyleBackColor = true;
      this.ActionReset.Click += new System.EventHandler(this.ActionReset_Click);
      // 
      // ActionDelLast
      // 
      resources.ApplyResources(this.ActionDelLast, "ActionDelLast");
      this.ActionDelLast.FlatAppearance.BorderSize = 0;
      this.ActionDelLast.Name = "ActionDelLast";
      this.ActionDelLast.UseVisualStyleBackColor = true;
      this.ActionDelLast.Click += new System.EventHandler(this.ActionDelLast_Click);
      // 
      // ActionDelFirst
      // 
      resources.ApplyResources(this.ActionDelFirst, "ActionDelFirst");
      this.ActionDelFirst.FlatAppearance.BorderSize = 0;
      this.ActionDelFirst.Name = "ActionDelFirst";
      this.ActionDelFirst.UseVisualStyleBackColor = true;
      this.ActionDelFirst.Click += new System.EventHandler(this.ActionDelFirst_Click);
      // 
      // EditCopyToClipboardCloseApp
      // 
      resources.ApplyResources(this.EditCopyToClipboardCloseApp, "EditCopyToClipboardCloseApp");
      this.EditCopyToClipboardCloseApp.Name = "EditCopyToClipboardCloseApp";
      this.EditCopyToClipboardCloseApp.UseVisualStyleBackColor = true;
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
      this.ActionSearchOnline.ContextMenuStrip = this.ContextMenuSearchOnline;
      this.ActionSearchOnline.Cursor = System.Windows.Forms.Cursors.Default;
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.FlatAppearance.BorderSize = 0;
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      this.ActionSearchOnline.UseVisualStyleBackColor = true;
      this.ActionSearchOnline.Click += new System.EventHandler(this.ActionSearchOnline_Click);
      // 
      // ContextMenuSearchOnline
      // 
      this.ContextMenuSearchOnline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionOpenWordOnline});
      this.ContextMenuSearchOnline.Name = "ContextMenuSearchOnline";
      resources.ApplyResources(this.ContextMenuSearchOnline, "ContextMenuSearchOnline");
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
      // ActionSnapshot
      // 
      resources.ApplyResources(this.ActionSnapshot, "ActionSnapshot");
      this.ActionSnapshot.FlatAppearance.BorderSize = 0;
      this.ActionSnapshot.Name = "ActionSnapshot";
      this.ActionSnapshot.UseVisualStyleBackColor = true;
      this.ActionSnapshot.Click += new System.EventHandler(this.ActionSnapshot_Click);
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
      this.EditSentence.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditSentence.Name = "EditSentence";
      this.EditSentence.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // EditGematriaSimple
      // 
      resources.ApplyResources(this.EditGematriaSimple, "EditGematriaSimple");
      this.EditGematriaSimple.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaSimple.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaSimple.Name = "EditGematriaSimple";
      this.EditGematriaSimple.ReadOnly = true;
      // 
      // LabelGematria
      // 
      resources.ApplyResources(this.LabelGematria, "LabelGematria");
      this.LabelGematria.Name = "LabelGematria";
      // 
      // EditLetters
      // 
      this.EditLetters.BackColor = System.Drawing.Color.Transparent;
      this.EditLetters.InputSelectionStart = 0;
      this.EditLetters.InputText = "";
      resources.ApplyResources(this.EditLetters, "EditLetters");
      this.EditLetters.Name = "EditLetters";
      this.EditLetters.ViewLetterDetails += new Ordisoftware.Hebrew.ViewLetterDetails(this.EditLetters_ViewLetterDetails);
      this.EditLetters.InputTextChanged += new System.EventHandler(this.EditLetters_InputTextChanged);
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
      this.TextBoxStructure.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxStructure.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Structure", true));
      resources.ApplyResources(this.TextBoxStructure, "TextBoxStructure");
      this.TextBoxStructure.Name = "TextBoxStructure";
      this.TextBoxStructure.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxPositive_ContextMenuEditOpening);
      this.TextBoxStructure.ContextMenuEditOpened += new System.EventHandler(this.TextBoxPositive_ContextMenuEditOpened);
      this.TextBoxStructure.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxStructure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositive_KeyPress);
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
      this.TextBoxNegative.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxNegative.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Negative", true));
      resources.ApplyResources(this.TextBoxNegative, "TextBoxNegative");
      this.TextBoxNegative.Name = "TextBoxNegative";
      this.TextBoxNegative.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxPositive_ContextMenuEditOpening);
      this.TextBoxNegative.ContextMenuEditOpened += new System.EventHandler(this.TextBoxPositive_ContextMenuEditOpened);
      this.TextBoxNegative.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxNegative.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositive_KeyPress);
      // 
      // TextBoxName
      // 
      this.TextBoxName.BackColor = System.Drawing.Color.LightYellow;
      this.TextBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxName.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Name", true));
      resources.ApplyResources(this.TextBoxName, "TextBoxName");
      this.TextBoxName.Name = "TextBoxName";
      this.TextBoxName.ReadOnly = true;
      // 
      // TextBoxFunction
      // 
      this.TextBoxFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxFunction.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxFunction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Function", true));
      resources.ApplyResources(this.TextBoxFunction, "TextBoxFunction");
      this.TextBoxFunction.Name = "TextBoxFunction";
      this.TextBoxFunction.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxPositive_ContextMenuEditOpening);
      this.TextBoxFunction.ContextMenuEditOpened += new System.EventHandler(this.TextBoxPositive_ContextMenuEditOpened);
      this.TextBoxFunction.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxFunction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositive_KeyPress);
      // 
      // TextBoxPositive
      // 
      this.TextBoxPositive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxPositive.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxPositive.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Positive", true));
      resources.ApplyResources(this.TextBoxPositive, "TextBoxPositive");
      this.TextBoxPositive.Name = "TextBoxPositive";
      this.TextBoxPositive.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxPositive_ContextMenuEditOpening);
      this.TextBoxPositive.ContextMenuEditOpened += new System.EventHandler(this.TextBoxPositive_ContextMenuEditOpened);
      this.TextBoxPositive.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxPositive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositive_KeyPress);
      // 
      // TextBoxVerb
      // 
      this.TextBoxVerb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxVerb.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxVerb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Verb", true));
      resources.ApplyResources(this.TextBoxVerb, "TextBoxVerb");
      this.TextBoxVerb.Name = "TextBoxVerb";
      this.TextBoxVerb.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxPositive_ContextMenuEditOpening);
      this.TextBoxVerb.ContextMenuEditOpened += new System.EventHandler(this.TextBoxPositive_ContextMenuEditOpened);
      this.TextBoxVerb.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxVerb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositive_KeyPress);
      // 
      // TextBoxValueSimple
      // 
      this.TextBoxValueSimple.BackColor = System.Drawing.Color.LavenderBlush;
      this.TextBoxValueSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxValueSimple.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxValueSimple.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "ValueSimple", true));
      resources.ApplyResources(this.TextBoxValueSimple, "TextBoxValueSimple");
      this.TextBoxValueSimple.Name = "TextBoxValueSimple";
      this.TextBoxValueSimple.ReadOnly = true;
      // 
      // TextBoxValueFull
      // 
      this.TextBoxValueFull.BackColor = System.Drawing.Color.LavenderBlush;
      this.TextBoxValueFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxValueFull.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
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
            this.ActionInformation,
            this.Sep6,
            this.ActionPreferences,
            this.ActionSettings,
            this.ActionViewAnalysis,
            this.ActionViewLetters,
            this.toolStripSeparator6,
            this.ActionSearchTerm,
            this.ActionNewInstance,
            this.toolStripSeparator1,
            this.ActionTools,
            this.ActionWebLinks});
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
      this.ActionExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionExit_MouseUp);
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
      // ActionInformation
      // 
      this.ActionInformation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionInformation, "ActionInformation");
      this.ActionInformation.Name = "ActionInformation";
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
      // ActionSettings
      // 
      this.ActionSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuitemScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.EditUseAdvancedDialogBoxes,
            this.EditSoundsEnabled,
            this.EditShowTips,
            this.toolStripSeparator2,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      resources.ApplyResources(this.ActionSettings, "ActionSettings");
      this.ActionSettings.Name = "ActionSettings";
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
      // EditUseAdvancedDialogBoxes
      // 
      this.EditUseAdvancedDialogBoxes.Checked = true;
      this.EditUseAdvancedDialogBoxes.CheckOnClick = true;
      this.EditUseAdvancedDialogBoxes.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditUseAdvancedDialogBoxes, "EditUseAdvancedDialogBoxes");
      this.EditUseAdvancedDialogBoxes.Name = "EditUseAdvancedDialogBoxes";
      this.EditUseAdvancedDialogBoxes.CheckedChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditSoundsEnabled
      // 
      this.EditSoundsEnabled.Checked = true;
      this.EditSoundsEnabled.CheckOnClick = true;
      this.EditSoundsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditSoundsEnabled, "EditSoundsEnabled");
      this.EditSoundsEnabled.Name = "EditSoundsEnabled";
      this.EditSoundsEnabled.CheckedChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowTips, "EditShowTips");
      this.EditShowTips.Name = "EditShowTips";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
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
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
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
      // ActionNewInstance
      // 
      this.ActionNewInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionNewInstance, "ActionNewInstance");
      this.ActionNewInstance.Name = "ActionNewInstance";
      this.ActionNewInstance.Padding = new System.Windows.Forms.Padding(5);
      this.ActionNewInstance.Click += new System.EventHandler(this.ActionNewInstance_Click);
      this.ActionNewInstance.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionNewInstance.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionTools
      // 
      this.ActionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionShowMethodNotice,
            this.ActionShowGrammarGuide,
            this.toolStripSeparator4,
            this.ActionOpenShorashon,
            this.toolStripSeparator3,
            this.ActionOpenLexilogosOld,
            this.ActionOpenLexilogosModern,
            this.toolStripSeparator5,
            this.ActionViewLog,
            this.ActionViewStats});
      resources.ApplyResources(this.ActionTools, "ActionTools");
      this.ActionTools.Name = "ActionTools";
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
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // ActionViewLog
      // 
      resources.ApplyResources(this.ActionViewLog, "ActionViewLog");
      this.ActionViewLog.Name = "ActionViewLog";
      this.ActionViewLog.Click += new System.EventHandler(this.ActionViewLog_Click);
      // 
      // ActionViewStats
      // 
      resources.ApplyResources(this.ActionViewStats, "ActionViewStats");
      this.ActionViewStats.Name = "ActionViewStats";
      this.ActionViewStats.Click += new System.EventHandler(this.ActionViewStats_Click);
      // 
      // ActionWebLinks
      // 
      this.ActionWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionWebLinks, "ActionWebLinks");
      this.ActionWebLinks.Name = "ActionWebLinks";
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
      this.TableAdapterManager.UpdateOrder = Ordisoftware.Hebrew.Letters.Data.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // MeaningsTableAdapter
      // 
      this.MeaningsTableAdapter.ClearBeforeFill = true;
      // 
      // TimerProcesses
      // 
      this.TimerProcesses.Enabled = true;
      this.TimerProcesses.Interval = 2000;
      this.TimerProcesses.Tick += new System.EventHandler(this.TimerProcesses_Tick);
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
      this.ContextMenuSearchOnline.ResumeLayout(false);
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
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton ActionExit;
    private System.Windows.Forms.ToolStripSeparator Sep4;
    private System.Windows.Forms.ToolStripDropDownButton ActionSettings;
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
    internal Ordisoftware.Hebrew.LettersControl EditLetters;
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
    private Ordisoftware.Core.UndoRedoTextBox TextBoxName;
    private Ordisoftware.Core.UndoRedoTextBox TextBoxValueSimple;
    private Ordisoftware.Core.UndoRedoTextBox TextBoxValueFull;
    private Data.DataSetTableAdapters.MeaningsTableAdapter MeaningsTableAdapter;
    private System.Windows.Forms.Panel PanelSettingsDetails;
    private System.Windows.Forms.LinkLabel ActionRestoreDefaults;
    private System.Windows.Forms.Button ActionDeleteMeaning;
    private System.Windows.Forms.Button ActionAddMeaning;
    private System.Windows.Forms.Button ActionCopyToClipboardResult;
    private System.Windows.Forms.Panel EditAnalyze;
    internal System.Windows.Forms.CheckBox EditCopyToClipboardCloseApp;
    private System.Windows.Forms.Button ActionCopyToClipboardMeanings;
    private System.Windows.Forms.ToolStripButton ActionPreferences;
    internal System.Windows.Forms.Label LabelGematria;
    internal Ordisoftware.Core.UndoRedoTextBox EditGematriaSimple;
    private System.Windows.Forms.Button ActionReset;
    private System.Windows.Forms.Button ActionDelLast;
    private System.Windows.Forms.Button ActionDelFirst;
    private System.Windows.Forms.DataGridView EditMeanings;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.Label LabelHebrew;
    private System.Windows.Forms.ComboBox ComboBoxCode;
    private System.Windows.Forms.Panel PanelLetter;
    private System.Windows.Forms.Button ActionCopyToUnicode;
    private System.Windows.Forms.Button ActionSearchOnline;
    private System.Windows.Forms.ContextMenuStrip ContextMenuSearchOnline;
    private System.Windows.Forms.Button ActionPasteFromUnicode;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton ActionSearchTerm;
    private System.Windows.Forms.ToolStripDropDownButton ActionTools;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenShorashon;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenLexilogosOld;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenLexilogosModern;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenWordOnline;
    internal Ordisoftware.Core.UndoRedoTextBox EditSentence;
    internal System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    private System.Windows.Forms.ToolStripDropDownButton ActionWebLinks;
    private System.Windows.Forms.ToolStripMenuItem ActionShowGrammarGuide;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem ActionShowMethodNotice;
    internal System.Windows.Forms.BindingSource MeaningsBindingSource;
    internal Ordisoftware.Core.UndoRedoTextBox TextBoxStructure;
    internal Ordisoftware.Core.UndoRedoTextBox TextBoxFunction;
    internal Ordisoftware.Core.UndoRedoTextBox TextBoxVerb;
    internal Ordisoftware.Core.UndoRedoTextBox TextBoxNegative;
    internal Ordisoftware.Core.UndoRedoTextBox TextBoxPositive;
    internal System.Windows.Forms.Button ActionClear;
    internal System.Windows.Forms.Label LabelGematriaSimple;
    internal Ordisoftware.Core.UndoRedoTextBox EditGematriaFull;
    internal System.Windows.Forms.Label LabelGematriaFull;
    internal System.Windows.Forms.ToolStripDropDownButton ActionInformation;
    internal System.Windows.Forms.ToolStripMenuItem EditUseAdvancedDialogBoxes;
    internal System.Windows.Forms.ToolStripMenuItem EditSoundsEnabled;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewLog;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewStats;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton ActionNewInstance;
    private System.Windows.Forms.Button ActionSnapshot;
    private System.Windows.Forms.Timer TimerProcesses;
  }
}
