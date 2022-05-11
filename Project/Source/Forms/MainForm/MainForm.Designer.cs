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
      if ( disposing && ( components != null ) )
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelMainOuter = new System.Windows.Forms.Panel();
      this.PanelMainInner = new System.Windows.Forms.Panel();
      this.PanelMainCenter = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageText = new System.Windows.Forms.TabPage();
      this.PanelViewAnalysis = new System.Windows.Forms.Panel();
      this.ActionCopyToMeanings = new System.Windows.Forms.Button();
      this.LabelClipboardContentType = new System.Windows.Forms.Label();
      this.EditCopyToClipboardCloseApp = new System.Windows.Forms.CheckBox();
      this.SelectAnalyze = new System.Windows.Forms.Panel();
      this.ActionSearchOnline = new System.Windows.Forms.Button();
      this.ContextMenuSearchOnline = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionPaste = new System.Windows.Forms.Button();
      this.ActionCopyToHebrew = new System.Windows.Forms.Button();
      this.ActionCopyToUnicode = new System.Windows.Forms.Button();
      this.ActionClear = new System.Windows.Forms.Button();
      this.ActionSaveScreenshot = new System.Windows.Forms.Button();
      this.ActionScreenshot = new System.Windows.Forms.Button();
      this.ActionViewAllMeaningsList = new System.Windows.Forms.Button();
      this.ActionSaveTermLettriq = new System.Windows.Forms.Button();
      this.ActionCopyToResult = new System.Windows.Forms.Button();
      this.EditSentence = new Ordisoftware.Core.TextBoxEx();
      this.EditWord = new Ordisoftware.Hebrew.LettersControl();
      this.PanelWordDetails = new System.Windows.Forms.Panel();
      this.ActionOpenConcordance = new System.Windows.Forms.Button();
      this.LabelCondordance = new System.Windows.Forms.Label();
      this.EditConcordance = new System.Windows.Forms.NumericUpDown();
      this.LabelTranscription = new System.Windows.Forms.Label();
      this.LabelDictionary = new System.Windows.Forms.Label();
      this.LabelMemo = new System.Windows.Forms.Label();
      this.EditDictionary = new Ordisoftware.Core.TextBoxEx();
      this.EditMemo = new Ordisoftware.Core.TextBoxEx();
      this.EditTranscription = new Ordisoftware.Core.TextBoxEx();
      this.PanelEditWordControl = new System.Windows.Forms.Panel();
      this.EditCopyWithFinalLetter = new System.Windows.Forms.CheckBox();
      this.ActionDelFirst = new System.Windows.Forms.Button();
      this.ActionDelLast = new System.Windows.Forms.Button();
      this.ActionReset = new System.Windows.Forms.Button();
      this.ActionOpenTermLettriq = new System.Windows.Forms.Button();
      this.PanelGematria = new System.Windows.Forms.Panel();
      this.EditGematriaFull = new Ordisoftware.Core.TextBoxEx();
      this.LabelGematria = new System.Windows.Forms.Label();
      this.LabelGematriaFull = new System.Windows.Forms.Label();
      this.EditGematriaSimple = new Ordisoftware.Core.TextBoxEx();
      this.LabelGematriaSimple = new System.Windows.Forms.Label();
      this.TabPageLetters = new System.Windows.Forms.TabPage();
      this.PanelViewLetters = new System.Windows.Forms.Panel();
      this.PanelLettersInner = new System.Windows.Forms.Panel();
      this.PanelLetter = new System.Windows.Forms.Panel();
      this.LettersNavigator = new Ordisoftware.Core.ComboBoxNavigator();
      this.SelectLetter = new System.Windows.Forms.ComboBox();
      this.LettersBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.TextBoxStructure = new Ordisoftware.Core.TextBoxEx();
      this.LabelHebrew = new System.Windows.Forms.Label();
      this.ActionRestoreDefaults = new System.Windows.Forms.LinkLabel();
      this.TextBoxNegative = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxName = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxFunction = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxPositive = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxVerb = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxValueSimple = new Ordisoftware.Core.TextBoxEx();
      this.TextBoxValueFull = new Ordisoftware.Core.TextBoxEx();
      this.ActionUndo = new System.Windows.Forms.Button();
      this.ActionSave = new System.Windows.Forms.Button();
      this.ActionDeleteMeaning = new System.Windows.Forms.Button();
      this.ActionAddMeaning = new System.Windows.Forms.Button();
      this.EditMeanings = new System.Windows.Forms.DataGridView();
      this.ColumnMeaningsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MeaningsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.TabPageNotebook = new System.Windows.Forms.TabPage();
      this.PanelViewNotebook = new System.Windows.Forms.Panel();
      this.SplitContainerNotebook = new System.Windows.Forms.SplitContainer();
      this.ListNotebookWords = new System.Windows.Forms.DataGridView();
      this.hebrewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TermsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.ListNotebookLetters = new System.Windows.Forms.DataGridView();
      this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel2 = new System.Windows.Forms.Panel();
      this.ActionNotebookClearLetter = new System.Windows.Forms.Button();
      this.ActionNotebookClearWord = new System.Windows.Forms.Button();
      this.ActionNotebookDeleteWord = new System.Windows.Forms.Button();
      this.ListNotebookSentences = new System.Windows.Forms.DataGridView();
      this.sentenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LettriqsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel3 = new System.Windows.Forms.Panel();
      this.ActionNotebookClearFilter = new System.Windows.Forms.Button();
      this.EditNotebookFilterSentence = new System.Windows.Forms.TextBox();
      this.ActionNotebookDeleteSentence = new System.Windows.Forms.Button();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.PanelTitleInner = new System.Windows.Forms.Panel();
      this.LabelCurrentView = new System.Windows.Forms.Label();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.Sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.ActionSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowKeyboardNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditUseAdvancedDialogBoxes = new System.Windows.Forms.ToolStripMenuItem();
      this.EditSoundsEnabled = new System.Windows.Forms.ToolStripMenuItem();
      this.EditShowSuccessDialogs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewAnalysis = new System.Windows.Forms.ToolStripButton();
      this.ActionViewLetters = new System.Windows.Forms.ToolStripButton();
      this.ActionViewNotebook = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSearchTerm = new System.Windows.Forms.ToolStripButton();
      this.ActionNewInstance = new System.Windows.Forms.ToolStripButton();
      this.ActionCloseOtherWindows = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionShowTranscriptionGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowMethodNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionGematriaCombinationsSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ActionGematriaCombinations = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenExportFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionVacuumDB = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.TimerProcesses = new System.Windows.Forms.Timer(this.components);
      this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
      this.ToolTipClipboard = new System.Windows.Forms.ToolTip(this.components);
      this.ContextMenuOpenTermLettriq = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ContextMenuOpenConcordance = new System.Windows.Forms.ContextMenuStrip(this.components);
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
      this.PanelViewAnalysis.SuspendLayout();
      this.PanelWordDetails.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditConcordance)).BeginInit();
      this.PanelEditWordControl.SuspendLayout();
      this.PanelGematria.SuspendLayout();
      this.TabPageLetters.SuspendLayout();
      this.PanelViewLetters.SuspendLayout();
      this.PanelLettersInner.SuspendLayout();
      this.PanelLetter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LettersBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditMeanings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MeaningsBindingSource)).BeginInit();
      this.TabPageNotebook.SuspendLayout();
      this.PanelViewNotebook.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainerNotebook)).BeginInit();
      this.SplitContainerNotebook.Panel1.SuspendLayout();
      this.SplitContainerNotebook.Panel2.SuspendLayout();
      this.SplitContainerNotebook.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookWords)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TermsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookLetters)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookSentences)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LettriqsBindingSource)).BeginInit();
      this.panel3.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      this.PanelTitleInner.SuspendLayout();
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
      this.PanelMainInner.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainInner.Controls.Add(this.PanelMainCenter);
      resources.ApplyResources(this.PanelMainInner, "PanelMainInner");
      this.PanelMainInner.Name = "PanelMainInner";
      // 
      // PanelMainCenter
      // 
      this.PanelMainCenter.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainCenter.Controls.Add(this.TabControl);
      resources.ApplyResources(this.PanelMainCenter, "PanelMainCenter");
      this.PanelMainCenter.Name = "PanelMainCenter";
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageText);
      this.TabControl.Controls.Add(this.TabPageLetters);
      this.TabControl.Controls.Add(this.TabPageNotebook);
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // TabPageText
      // 
      this.TabPageText.Controls.Add(this.PanelViewAnalysis);
      resources.ApplyResources(this.TabPageText, "TabPageText");
      this.TabPageText.Name = "TabPageText";
      this.TabPageText.UseVisualStyleBackColor = true;
      // 
      // PanelViewAnalysis
      // 
      resources.ApplyResources(this.PanelViewAnalysis, "PanelViewAnalysis");
      this.PanelViewAnalysis.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewAnalysis.Controls.Add(this.ActionCopyToMeanings);
      this.PanelViewAnalysis.Controls.Add(this.LabelClipboardContentType);
      this.PanelViewAnalysis.Controls.Add(this.EditCopyToClipboardCloseApp);
      this.PanelViewAnalysis.Controls.Add(this.SelectAnalyze);
      this.PanelViewAnalysis.Controls.Add(this.ActionSearchOnline);
      this.PanelViewAnalysis.Controls.Add(this.ActionPaste);
      this.PanelViewAnalysis.Controls.Add(this.ActionCopyToHebrew);
      this.PanelViewAnalysis.Controls.Add(this.ActionCopyToUnicode);
      this.PanelViewAnalysis.Controls.Add(this.ActionClear);
      this.PanelViewAnalysis.Controls.Add(this.ActionSaveScreenshot);
      this.PanelViewAnalysis.Controls.Add(this.ActionScreenshot);
      this.PanelViewAnalysis.Controls.Add(this.ActionViewAllMeaningsList);
      this.PanelViewAnalysis.Controls.Add(this.ActionSaveTermLettriq);
      this.PanelViewAnalysis.Controls.Add(this.ActionCopyToResult);
      this.PanelViewAnalysis.Controls.Add(this.EditSentence);
      this.PanelViewAnalysis.Controls.Add(this.EditWord);
      this.PanelViewAnalysis.Controls.Add(this.PanelWordDetails);
      this.PanelViewAnalysis.Controls.Add(this.PanelEditWordControl);
      this.PanelViewAnalysis.Controls.Add(this.ActionOpenTermLettriq);
      this.PanelViewAnalysis.Controls.Add(this.PanelGematria);
      this.PanelViewAnalysis.Name = "PanelViewAnalysis";
      // 
      // ActionCopyToMeanings
      // 
      resources.ApplyResources(this.ActionCopyToMeanings, "ActionCopyToMeanings");
      this.ActionCopyToMeanings.FlatAppearance.BorderSize = 0;
      this.ActionCopyToMeanings.Name = "ActionCopyToMeanings";
      this.ActionCopyToMeanings.UseVisualStyleBackColor = true;
      this.ActionCopyToMeanings.Click += new System.EventHandler(this.ActionCopyToMeanings_Click);
      // 
      // LabelClipboardContentType
      // 
      resources.ApplyResources(this.LabelClipboardContentType, "LabelClipboardContentType");
      this.LabelClipboardContentType.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelClipboardContentType.Name = "LabelClipboardContentType";
      this.ToolTipClipboard.SetToolTip(this.LabelClipboardContentType, resources.GetString("LabelClipboardContentType.ToolTip"));
      this.LabelClipboardContentType.MouseHover += new System.EventHandler(this.LabelClipboardContentType_MouseHover);
      // 
      // EditCopyToClipboardCloseApp
      // 
      resources.ApplyResources(this.EditCopyToClipboardCloseApp, "EditCopyToClipboardCloseApp");
      this.EditCopyToClipboardCloseApp.Name = "EditCopyToClipboardCloseApp";
      this.EditCopyToClipboardCloseApp.UseVisualStyleBackColor = true;
      // 
      // SelectAnalyze
      // 
      resources.ApplyResources(this.SelectAnalyze, "SelectAnalyze");
      this.SelectAnalyze.BackColor = System.Drawing.Color.MintCream;
      this.SelectAnalyze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.SelectAnalyze.Name = "SelectAnalyze";
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
      this.ContextMenuSearchOnline.Name = "ContextMenuSearchOnline";
      resources.ApplyResources(this.ContextMenuSearchOnline, "ContextMenuSearchOnline");
      // 
      // ActionPaste
      // 
      this.ActionPaste.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionPaste, "ActionPaste");
      this.ActionPaste.Name = "ActionPaste";
      this.ActionPaste.UseVisualStyleBackColor = true;
      this.ActionPaste.Click += new System.EventHandler(this.ActionPaste_Click);
      // 
      // ActionCopyToHebrew
      // 
      resources.ApplyResources(this.ActionCopyToHebrew, "ActionCopyToHebrew");
      this.ActionCopyToHebrew.FlatAppearance.BorderSize = 0;
      this.ActionCopyToHebrew.Name = "ActionCopyToHebrew";
      this.ActionCopyToHebrew.UseVisualStyleBackColor = true;
      this.ActionCopyToHebrew.Click += new System.EventHandler(this.ActionCopyToHebrew_Click);
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
      // ActionSaveScreenshot
      // 
      resources.ApplyResources(this.ActionSaveScreenshot, "ActionSaveScreenshot");
      this.ActionSaveScreenshot.FlatAppearance.BorderSize = 0;
      this.ActionSaveScreenshot.Name = "ActionSaveScreenshot";
      this.ActionSaveScreenshot.UseVisualStyleBackColor = true;
      this.ActionSaveScreenshot.Click += new System.EventHandler(this.ActionSaveScreenshot_Click);
      // 
      // ActionScreenshot
      // 
      resources.ApplyResources(this.ActionScreenshot, "ActionScreenshot");
      this.ActionScreenshot.FlatAppearance.BorderSize = 0;
      this.ActionScreenshot.Name = "ActionScreenshot";
      this.ActionScreenshot.UseVisualStyleBackColor = true;
      this.ActionScreenshot.Click += new System.EventHandler(this.ActionScreenshot_Click);
      // 
      // ActionViewAllMeaningsList
      // 
      resources.ApplyResources(this.ActionViewAllMeaningsList, "ActionViewAllMeaningsList");
      this.ActionViewAllMeaningsList.FlatAppearance.BorderSize = 0;
      this.ActionViewAllMeaningsList.Name = "ActionViewAllMeaningsList";
      this.ActionViewAllMeaningsList.UseVisualStyleBackColor = true;
      this.ActionViewAllMeaningsList.Click += new System.EventHandler(this.ActionViewAllMeaningsList_Click);
      // 
      // ActionSaveTermLettriq
      // 
      resources.ApplyResources(this.ActionSaveTermLettriq, "ActionSaveTermLettriq");
      this.ActionSaveTermLettriq.FlatAppearance.BorderSize = 0;
      this.ActionSaveTermLettriq.Name = "ActionSaveTermLettriq";
      this.ActionSaveTermLettriq.UseVisualStyleBackColor = true;
      this.ActionSaveTermLettriq.Click += new System.EventHandler(this.ActionSaveTermLettriq_Click);
      // 
      // ActionCopyToResult
      // 
      resources.ApplyResources(this.ActionCopyToResult, "ActionCopyToResult");
      this.ActionCopyToResult.FlatAppearance.BorderSize = 0;
      this.ActionCopyToResult.Name = "ActionCopyToResult";
      this.ActionCopyToResult.UseVisualStyleBackColor = true;
      this.ActionCopyToResult.Click += new System.EventHandler(this.ActionCopyToResult_Click);
      // 
      // EditSentence
      // 
      resources.ApplyResources(this.EditSentence, "EditSentence");
      this.EditSentence.BackColor = System.Drawing.SystemColors.Window;
      this.EditSentence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditSentence.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditSentence.Name = "EditSentence";
      this.EditSentence.FontChanged += new System.EventHandler(this.EditSentence_FontChanged);
      this.EditSentence.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // EditWord
      // 
      this.EditWord.BackColor = System.Drawing.Color.Transparent;
      this.EditWord.ContextMenuDetailsVisible = false;
      resources.ApplyResources(this.EditWord, "EditWord");
      this.EditWord.MarginX = -5;
      this.EditWord.MarginY = 0;
      this.EditWord.Name = "EditWord";
      this.EditWord.ViewLetterDetails += new Ordisoftware.Hebrew.ViewLetterDetails(this.EditWord_ViewLetterDetails);
      this.EditWord.InputTextChanged += new System.EventHandler(this.EditWord_InputTextChanged);
      // 
      // PanelWordDetails
      // 
      resources.ApplyResources(this.PanelWordDetails, "PanelWordDetails");
      this.PanelWordDetails.Controls.Add(this.ActionOpenConcordance);
      this.PanelWordDetails.Controls.Add(this.LabelCondordance);
      this.PanelWordDetails.Controls.Add(this.EditConcordance);
      this.PanelWordDetails.Controls.Add(this.LabelTranscription);
      this.PanelWordDetails.Controls.Add(this.LabelDictionary);
      this.PanelWordDetails.Controls.Add(this.LabelMemo);
      this.PanelWordDetails.Controls.Add(this.EditDictionary);
      this.PanelWordDetails.Controls.Add(this.EditMemo);
      this.PanelWordDetails.Controls.Add(this.EditTranscription);
      this.PanelWordDetails.Name = "PanelWordDetails";
      // 
      // ActionOpenConcordance
      // 
      this.ActionOpenConcordance.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionOpenConcordance, "ActionOpenConcordance");
      this.ActionOpenConcordance.Name = "ActionOpenConcordance";
      this.ActionOpenConcordance.UseVisualStyleBackColor = true;
      this.ActionOpenConcordance.Click += new System.EventHandler(this.ActionOpenConcordance_Click);
      // 
      // LabelCondordance
      // 
      resources.ApplyResources(this.LabelCondordance, "LabelCondordance");
      this.LabelCondordance.Name = "LabelCondordance";
      // 
      // EditConcordance
      // 
      this.EditConcordance.BackColor = System.Drawing.Color.MintCream;
      resources.ApplyResources(this.EditConcordance, "EditConcordance");
      this.EditConcordance.Name = "EditConcordance";
      // 
      // LabelTranscription
      // 
      resources.ApplyResources(this.LabelTranscription, "LabelTranscription");
      this.LabelTranscription.Name = "LabelTranscription";
      // 
      // LabelDictionary
      // 
      resources.ApplyResources(this.LabelDictionary, "LabelDictionary");
      this.LabelDictionary.Name = "LabelDictionary";
      // 
      // LabelMemo
      // 
      resources.ApplyResources(this.LabelMemo, "LabelMemo");
      this.LabelMemo.Name = "LabelMemo";
      // 
      // EditDictionary
      // 
      this.EditDictionary.BackColor = System.Drawing.Color.AliceBlue;
      this.EditDictionary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditDictionary.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditDictionary, "EditDictionary");
      this.EditDictionary.Name = "EditDictionary";
      this.EditDictionary.FontChanged += new System.EventHandler(this.EditSentence_FontChanged);
      this.EditDictionary.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // EditMemo
      // 
      this.EditMemo.BackColor = System.Drawing.Color.AliceBlue;
      this.EditMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditMemo.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditMemo, "EditMemo");
      this.EditMemo.Name = "EditMemo";
      this.EditMemo.FontChanged += new System.EventHandler(this.EditSentence_FontChanged);
      this.EditMemo.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // EditTranscription
      // 
      this.EditTranscription.BackColor = System.Drawing.Color.AliceBlue;
      this.EditTranscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditTranscription.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditTranscription, "EditTranscription");
      this.EditTranscription.Name = "EditTranscription";
      this.EditTranscription.FontChanged += new System.EventHandler(this.EditSentence_FontChanged);
      this.EditTranscription.TextChanged += new System.EventHandler(this.EditSentence_TextChanged);
      // 
      // PanelEditWordControl
      // 
      this.PanelEditWordControl.Controls.Add(this.EditCopyWithFinalLetter);
      this.PanelEditWordControl.Controls.Add(this.ActionDelFirst);
      this.PanelEditWordControl.Controls.Add(this.ActionDelLast);
      this.PanelEditWordControl.Controls.Add(this.ActionReset);
      resources.ApplyResources(this.PanelEditWordControl, "PanelEditWordControl");
      this.PanelEditWordControl.Name = "PanelEditWordControl";
      // 
      // EditCopyWithFinalLetter
      // 
      resources.ApplyResources(this.EditCopyWithFinalLetter, "EditCopyWithFinalLetter");
      this.EditCopyWithFinalLetter.Checked = global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default.CopyWithFinalLetter;
      this.EditCopyWithFinalLetter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditCopyWithFinalLetter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default, "CopyWithFinalLetter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditCopyWithFinalLetter.Name = "EditCopyWithFinalLetter";
      // 
      // ActionDelFirst
      // 
      resources.ApplyResources(this.ActionDelFirst, "ActionDelFirst");
      this.ActionDelFirst.FlatAppearance.BorderSize = 0;
      this.ActionDelFirst.Name = "ActionDelFirst";
      this.ActionDelFirst.UseVisualStyleBackColor = true;
      this.ActionDelFirst.Click += new System.EventHandler(this.ActionDelFirst_Click);
      // 
      // ActionDelLast
      // 
      resources.ApplyResources(this.ActionDelLast, "ActionDelLast");
      this.ActionDelLast.FlatAppearance.BorderSize = 0;
      this.ActionDelLast.Name = "ActionDelLast";
      this.ActionDelLast.UseVisualStyleBackColor = true;
      this.ActionDelLast.Click += new System.EventHandler(this.ActionDelLast_Click);
      // 
      // ActionReset
      // 
      this.ActionReset.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionReset, "ActionReset");
      this.ActionReset.Name = "ActionReset";
      this.ActionReset.UseVisualStyleBackColor = true;
      this.ActionReset.Click += new System.EventHandler(this.ActionReset_Click);
      // 
      // ActionOpenTermLettriq
      // 
      resources.ApplyResources(this.ActionOpenTermLettriq, "ActionOpenTermLettriq");
      this.ActionOpenTermLettriq.FlatAppearance.BorderSize = 0;
      this.ActionOpenTermLettriq.Name = "ActionOpenTermLettriq";
      this.ActionOpenTermLettriq.UseVisualStyleBackColor = true;
      this.ActionOpenTermLettriq.Click += new System.EventHandler(this.ActionOpenTermLettriq_Click);
      // 
      // PanelGematria
      // 
      resources.ApplyResources(this.PanelGematria, "PanelGematria");
      this.PanelGematria.Controls.Add(this.EditGematriaFull);
      this.PanelGematria.Controls.Add(this.LabelGematria);
      this.PanelGematria.Controls.Add(this.LabelGematriaFull);
      this.PanelGematria.Controls.Add(this.EditGematriaSimple);
      this.PanelGematria.Controls.Add(this.LabelGematriaSimple);
      this.PanelGematria.Name = "PanelGematria";
      // 
      // EditGematriaFull
      // 
      resources.ApplyResources(this.EditGematriaFull, "EditGematriaFull");
      this.EditGematriaFull.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaFull.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaFull.Name = "EditGematriaFull";
      this.EditGematriaFull.ReadOnly = true;
      this.EditGematriaFull.TextChanged += new System.EventHandler(this.EditGematria_TextChanged);
      // 
      // LabelGematria
      // 
      resources.ApplyResources(this.LabelGematria, "LabelGematria");
      this.LabelGematria.Name = "LabelGematria";
      // 
      // LabelGematriaFull
      // 
      resources.ApplyResources(this.LabelGematriaFull, "LabelGematriaFull");
      this.LabelGematriaFull.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelGematriaFull.Name = "LabelGematriaFull";
      // 
      // EditGematriaSimple
      // 
      resources.ApplyResources(this.EditGematriaSimple, "EditGematriaSimple");
      this.EditGematriaSimple.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaSimple.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaSimple.Name = "EditGematriaSimple";
      this.EditGematriaSimple.ReadOnly = true;
      this.EditGematriaSimple.TextChanged += new System.EventHandler(this.EditGematria_TextChanged);
      // 
      // LabelGematriaSimple
      // 
      resources.ApplyResources(this.LabelGematriaSimple, "LabelGematriaSimple");
      this.LabelGematriaSimple.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelGematriaSimple.Name = "LabelGematriaSimple";
      // 
      // TabPageLetters
      // 
      this.TabPageLetters.Controls.Add(this.PanelViewLetters);
      resources.ApplyResources(this.TabPageLetters, "TabPageLetters");
      this.TabPageLetters.Name = "TabPageLetters";
      this.TabPageLetters.UseVisualStyleBackColor = true;
      // 
      // PanelViewLetters
      // 
      resources.ApplyResources(this.PanelViewLetters, "PanelViewLetters");
      this.PanelViewLetters.Controls.Add(this.PanelLettersInner);
      this.PanelViewLetters.Name = "PanelViewLetters";
      // 
      // PanelLettersInner
      // 
      resources.ApplyResources(this.PanelLettersInner, "PanelLettersInner");
      this.PanelLettersInner.BackColor = System.Drawing.SystemColors.Control;
      this.PanelLettersInner.Controls.Add(this.PanelLetter);
      this.PanelLettersInner.Controls.Add(this.ActionUndo);
      this.PanelLettersInner.Controls.Add(this.ActionSave);
      this.PanelLettersInner.Controls.Add(this.ActionDeleteMeaning);
      this.PanelLettersInner.Controls.Add(this.ActionAddMeaning);
      this.PanelLettersInner.Controls.Add(LabelMeanings);
      this.PanelLettersInner.Controls.Add(this.EditMeanings);
      this.PanelLettersInner.Name = "PanelLettersInner";
      // 
      // PanelLetter
      // 
      this.PanelLetter.Controls.Add(this.LettersNavigator);
      this.PanelLetter.Controls.Add(this.SelectLetter);
      this.PanelLetter.Controls.Add(this.TextBoxStructure);
      this.PanelLetter.Controls.Add(this.LabelHebrew);
      this.PanelLetter.Controls.Add(this.ActionRestoreDefaults);
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
      resources.ApplyResources(this.PanelLetter, "PanelLetter");
      this.PanelLetter.Name = "PanelLetter";
      // 
      // LettersNavigator
      // 
      resources.ApplyResources(this.LettersNavigator, "LettersNavigator");
      this.LettersNavigator.ComboBox = this.SelectLetter;
      this.LettersNavigator.KeepFocus = true;
      this.LettersNavigator.Name = "LettersNavigator";
      this.LettersNavigator.SelectedIndex = -1;
      this.LettersNavigator.SelectedItem = null;
      this.LettersNavigator.Navigated += new System.EventHandler(this.LettersNavigator_Navigated);
      // 
      // SelectLetter
      // 
      this.SelectLetter.BackColor = System.Drawing.Color.LightYellow;
      this.SelectLetter.DataSource = this.LettersBindingSource;
      this.SelectLetter.DisplayMember = "Code";
      this.SelectLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      resources.ApplyResources(this.SelectLetter, "SelectLetter");
      this.SelectLetter.FormattingEnabled = true;
      this.SelectLetter.Name = "SelectLetter";
      this.SelectLetter.SelectedIndexChanged += new System.EventHandler(this.SelectLetter_SelectedIndexChanged);
      // 
      // LettersBindingSource
      // 
      this.LettersBindingSource.DataSource = typeof(Ordisoftware.Hebrew.Letters.Letter);
      // 
      // TextBoxStructure
      // 
      this.TextBoxStructure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxStructure.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxStructure.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Structure", true));
      resources.ApplyResources(this.TextBoxStructure, "TextBoxStructure");
      this.TextBoxStructure.Name = "TextBoxStructure";
      this.TextBoxStructure.Tag = "data";
      this.TextBoxStructure.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxData_ContextMenuEditOpening);
      this.TextBoxStructure.ContextMenuEditOpened += new System.EventHandler(this.TextBoxData_ContextMenuEditOpened);
      this.TextBoxStructure.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxStructure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
      // 
      // LabelHebrew
      // 
      resources.ApplyResources(this.LabelHebrew, "LabelHebrew");
      this.LabelHebrew.Name = "LabelHebrew";
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
      // TextBoxNegative
      // 
      this.TextBoxNegative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxNegative.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxNegative.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Negative", true));
      resources.ApplyResources(this.TextBoxNegative, "TextBoxNegative");
      this.TextBoxNegative.Name = "TextBoxNegative";
      this.TextBoxNegative.Tag = "data";
      this.TextBoxNegative.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxData_ContextMenuEditOpening);
      this.TextBoxNegative.ContextMenuEditOpened += new System.EventHandler(this.TextBoxData_ContextMenuEditOpened);
      this.TextBoxNegative.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxNegative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
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
      this.TextBoxFunction.Tag = "data";
      this.TextBoxFunction.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxData_ContextMenuEditOpening);
      this.TextBoxFunction.ContextMenuEditOpened += new System.EventHandler(this.TextBoxData_ContextMenuEditOpened);
      this.TextBoxFunction.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxFunction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
      // 
      // TextBoxPositive
      // 
      this.TextBoxPositive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxPositive.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxPositive.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Positive", true));
      resources.ApplyResources(this.TextBoxPositive, "TextBoxPositive");
      this.TextBoxPositive.Name = "TextBoxPositive";
      this.TextBoxPositive.Tag = "data";
      this.TextBoxPositive.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxData_ContextMenuEditOpening);
      this.TextBoxPositive.ContextMenuEditOpened += new System.EventHandler(this.TextBoxData_ContextMenuEditOpened);
      this.TextBoxPositive.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxPositive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
      // 
      // TextBoxVerb
      // 
      this.TextBoxVerb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TextBoxVerb.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.TextBoxVerb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LettersBindingSource, "Verb", true));
      resources.ApplyResources(this.TextBoxVerb, "TextBoxVerb");
      this.TextBoxVerb.Name = "TextBoxVerb";
      this.TextBoxVerb.Tag = "data";
      this.TextBoxVerb.ContextMenuEditOpening += new System.ComponentModel.CancelEventHandler(this.TextBoxData_ContextMenuEditOpening);
      this.TextBoxVerb.ContextMenuEditOpened += new System.EventHandler(this.TextBoxData_ContextMenuEditOpened);
      this.TextBoxVerb.TextChanged += new System.EventHandler(this.TextBoxPositive_TextChanged);
      this.TextBoxVerb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
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
      // ActionUndo
      // 
      resources.ApplyResources(this.ActionUndo, "ActionUndo");
      this.ActionUndo.FlatAppearance.BorderSize = 0;
      this.ActionUndo.Name = "ActionUndo";
      this.ActionUndo.UseVisualStyleBackColor = true;
      this.ActionUndo.Click += new System.EventHandler(this.ActionUndo_Click);
      // 
      // ActionSave
      // 
      resources.ApplyResources(this.ActionSave, "ActionSave");
      this.ActionSave.FlatAppearance.BorderSize = 0;
      this.ActionSave.Name = "ActionSave";
      this.ActionSave.UseVisualStyleBackColor = true;
      this.ActionSave.Click += new System.EventHandler(this.ActionSave_Click);
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
            this.ColumnMeaningsText});
      this.EditMeanings.DataSource = this.MeaningsBindingSource;
      this.EditMeanings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.EditMeanings.MultiSelect = false;
      this.EditMeanings.Name = "EditMeanings";
      this.EditMeanings.RowHeadersVisible = false;
      this.EditMeanings.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EditMeanings_CellBeginEdit);
      this.EditMeanings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditMeanings_CellDoubleClick);
      this.EditMeanings.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditMeanings_CellEndEdit);
      this.EditMeanings.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EditMeanings_CellValidating);
      this.EditMeanings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditMeanings_CellValueChanged);
      this.EditMeanings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.EditMeanings_DataError);
      this.EditMeanings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditMeanings_KeyDown);
      this.EditMeanings.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditMeanings_KeyUp);
      // 
      // ColumnMeaningsText
      // 
      this.ColumnMeaningsText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ColumnMeaningsText.DataPropertyName = "Text";
      resources.ApplyResources(this.ColumnMeaningsText, "ColumnMeaningsText");
      this.ColumnMeaningsText.Name = "ColumnMeaningsText";
      this.ColumnMeaningsText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // MeaningsBindingSource
      // 
      this.MeaningsBindingSource.DataMember = "Meanings";
      this.MeaningsBindingSource.DataSource = this.LettersBindingSource;
      // 
      // TabPageNotebook
      // 
      this.TabPageNotebook.Controls.Add(this.PanelViewNotebook);
      resources.ApplyResources(this.TabPageNotebook, "TabPageNotebook");
      this.TabPageNotebook.Name = "TabPageNotebook";
      this.TabPageNotebook.UseVisualStyleBackColor = true;
      // 
      // PanelViewNotebook
      // 
      resources.ApplyResources(this.PanelViewNotebook, "PanelViewNotebook");
      this.PanelViewNotebook.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewNotebook.Controls.Add(this.SplitContainerNotebook);
      this.PanelViewNotebook.Name = "PanelViewNotebook";
      // 
      // SplitContainerNotebook
      // 
      this.SplitContainerNotebook.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default, "MainFormSplitContainerNotebookDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      resources.ApplyResources(this.SplitContainerNotebook, "SplitContainerNotebook");
      this.SplitContainerNotebook.Name = "SplitContainerNotebook";
      // 
      // SplitContainerNotebook.Panel1
      // 
      this.SplitContainerNotebook.Panel1.Controls.Add(this.ListNotebookWords);
      this.SplitContainerNotebook.Panel1.Controls.Add(this.panel1);
      this.SplitContainerNotebook.Panel1.Controls.Add(this.ListNotebookLetters);
      this.SplitContainerNotebook.Panel1.Controls.Add(this.panel2);
      // 
      // SplitContainerNotebook.Panel2
      // 
      this.SplitContainerNotebook.Panel2.Controls.Add(this.ListNotebookSentences);
      this.SplitContainerNotebook.Panel2.Controls.Add(this.panel3);
      this.SplitContainerNotebook.SplitterDistance = global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default.MainFormSplitContainerNotebookDistance;
      // 
      // ListNotebookWords
      // 
      this.ListNotebookWords.AllowUserToAddRows = false;
      this.ListNotebookWords.AllowUserToDeleteRows = false;
      this.ListNotebookWords.AllowUserToResizeColumns = false;
      this.ListNotebookWords.AllowUserToResizeRows = false;
      this.ListNotebookWords.AutoGenerateColumns = false;
      this.ListNotebookWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ListNotebookWords.ColumnHeadersVisible = false;
      this.ListNotebookWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hebrewDataGridViewTextBoxColumn});
      this.ListNotebookWords.DataSource = this.TermsBindingSource;
      resources.ApplyResources(this.ListNotebookWords, "ListNotebookWords");
      this.ListNotebookWords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.ListNotebookWords.MultiSelect = false;
      this.ListNotebookWords.Name = "ListNotebookWords";
      this.ListNotebookWords.ReadOnly = true;
      this.ListNotebookWords.RowHeadersVisible = false;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Hebrew", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ListNotebookWords.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.ListNotebookWords.RowTemplate.Height = 28;
      this.ListNotebookWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ListNotebookWords.ShowCellToolTips = false;
      this.ListNotebookWords.SelectionChanged += new System.EventHandler(this.ListNotebookWords_SelectionChanged);
      // 
      // hebrewDataGridViewTextBoxColumn
      // 
      this.hebrewDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.hebrewDataGridViewTextBoxColumn.DataPropertyName = "Hebrew";
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Hebrew", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.hebrewDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
      resources.ApplyResources(this.hebrewDataGridViewTextBoxColumn, "hebrewDataGridViewTextBoxColumn");
      this.hebrewDataGridViewTextBoxColumn.Name = "hebrewDataGridViewTextBoxColumn";
      this.hebrewDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // TermsBindingSource
      // 
      this.TermsBindingSource.DataSource = typeof(Ordisoftware.Hebrew.TermHebrew);
      // 
      // panel1
      // 
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // ListNotebookLetters
      // 
      this.ListNotebookLetters.AllowUserToAddRows = false;
      this.ListNotebookLetters.AllowUserToDeleteRows = false;
      this.ListNotebookLetters.AllowUserToResizeColumns = false;
      this.ListNotebookLetters.AllowUserToResizeRows = false;
      this.ListNotebookLetters.AutoGenerateColumns = false;
      this.ListNotebookLetters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ListNotebookLetters.ColumnHeadersVisible = false;
      this.ListNotebookLetters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn});
      this.ListNotebookLetters.DataSource = this.LettersBindingSource;
      resources.ApplyResources(this.ListNotebookLetters, "ListNotebookLetters");
      this.ListNotebookLetters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.ListNotebookLetters.MultiSelect = false;
      this.ListNotebookLetters.Name = "ListNotebookLetters";
      this.ListNotebookLetters.ReadOnly = true;
      this.ListNotebookLetters.RowHeadersVisible = false;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Hebrew", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ListNotebookLetters.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.ListNotebookLetters.RowTemplate.Height = 28;
      this.ListNotebookLetters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ListNotebookLetters.ShowCellToolTips = false;
      this.ListNotebookLetters.SelectionChanged += new System.EventHandler(this.ListNotebookLetters_SelectionChanged);
      // 
      // codeDataGridViewTextBoxColumn
      // 
      this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Hebrew", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.codeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
      resources.ApplyResources(this.codeDataGridViewTextBoxColumn, "codeDataGridViewTextBoxColumn");
      this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
      this.codeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.ActionNotebookClearLetter);
      this.panel2.Controls.Add(this.ActionNotebookClearWord);
      this.panel2.Controls.Add(this.ActionNotebookDeleteWord);
      resources.ApplyResources(this.panel2, "panel2");
      this.panel2.Name = "panel2";
      // 
      // ActionNotebookClearLetter
      // 
      this.ActionNotebookClearLetter.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionNotebookClearLetter, "ActionNotebookClearLetter");
      this.ActionNotebookClearLetter.Name = "ActionNotebookClearLetter";
      this.ActionNotebookClearLetter.UseVisualStyleBackColor = true;
      this.ActionNotebookClearLetter.Click += new System.EventHandler(this.ActionNotebookClearLetter_Click);
      // 
      // ActionNotebookClearWord
      // 
      this.ActionNotebookClearWord.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionNotebookClearWord, "ActionNotebookClearWord");
      this.ActionNotebookClearWord.Name = "ActionNotebookClearWord";
      this.ActionNotebookClearWord.UseVisualStyleBackColor = true;
      this.ActionNotebookClearWord.Click += new System.EventHandler(this.ActionNotebookClearWord_Click);
      // 
      // ActionNotebookDeleteWord
      // 
      resources.ApplyResources(this.ActionNotebookDeleteWord, "ActionNotebookDeleteWord");
      this.ActionNotebookDeleteWord.FlatAppearance.BorderSize = 0;
      this.ActionNotebookDeleteWord.Name = "ActionNotebookDeleteWord";
      this.ActionNotebookDeleteWord.UseVisualStyleBackColor = true;
      this.ActionNotebookDeleteWord.Click += new System.EventHandler(this.ActionNotebookDeleteWord_Click);
      // 
      // ListNotebookSentences
      // 
      this.ListNotebookSentences.AllowUserToAddRows = false;
      this.ListNotebookSentences.AllowUserToDeleteRows = false;
      this.ListNotebookSentences.AllowUserToResizeColumns = false;
      this.ListNotebookSentences.AllowUserToResizeRows = false;
      this.ListNotebookSentences.AutoGenerateColumns = false;
      this.ListNotebookSentences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ListNotebookSentences.ColumnHeadersVisible = false;
      this.ListNotebookSentences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sentenceDataGridViewTextBoxColumn});
      this.ListNotebookSentences.DataSource = this.LettriqsBindingSource;
      resources.ApplyResources(this.ListNotebookSentences, "ListNotebookSentences");
      this.ListNotebookSentences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.ListNotebookSentences.Name = "ListNotebookSentences";
      this.ListNotebookSentences.ReadOnly = true;
      this.ListNotebookSentences.RowHeadersVisible = false;
      this.ListNotebookSentences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ListNotebookSentences.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListNotebookWord_CellDoubleClick);
      // 
      // sentenceDataGridViewTextBoxColumn
      // 
      this.sentenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.sentenceDataGridViewTextBoxColumn.DataPropertyName = "Sentence";
      resources.ApplyResources(this.sentenceDataGridViewTextBoxColumn, "sentenceDataGridViewTextBoxColumn");
      this.sentenceDataGridViewTextBoxColumn.Name = "sentenceDataGridViewTextBoxColumn";
      this.sentenceDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // LettriqsBindingSource
      // 
      this.LettriqsBindingSource.DataSource = typeof(Ordisoftware.Hebrew.TermLettriq);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.ActionNotebookClearFilter);
      this.panel3.Controls.Add(this.EditNotebookFilterSentence);
      this.panel3.Controls.Add(this.ActionNotebookDeleteSentence);
      resources.ApplyResources(this.panel3, "panel3");
      this.panel3.Name = "panel3";
      // 
      // ActionNotebookClearFilter
      // 
      this.ActionNotebookClearFilter.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionNotebookClearFilter, "ActionNotebookClearFilter");
      this.ActionNotebookClearFilter.Name = "ActionNotebookClearFilter";
      this.ActionNotebookClearFilter.UseVisualStyleBackColor = true;
      this.ActionNotebookClearFilter.Click += new System.EventHandler(this.ActionNotebookClearFilter_Click);
      // 
      // EditNotebookFilterSentence
      // 
      resources.ApplyResources(this.EditNotebookFilterSentence, "EditNotebookFilterSentence");
      this.EditNotebookFilterSentence.Name = "EditNotebookFilterSentence";
      this.EditNotebookFilterSentence.TextChanged += new System.EventHandler(this.EditNotebookFilterSentence_TextChanged);
      // 
      // ActionNotebookDeleteSentence
      // 
      resources.ApplyResources(this.ActionNotebookDeleteSentence, "ActionNotebookDeleteSentence");
      this.ActionNotebookDeleteSentence.FlatAppearance.BorderSize = 0;
      this.ActionNotebookDeleteSentence.Name = "ActionNotebookDeleteSentence";
      this.ActionNotebookDeleteSentence.UseVisualStyleBackColor = true;
      this.ActionNotebookDeleteSentence.Click += new System.EventHandler(this.ActionNotebookDeleteSentence_Click);
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.PanelTitleInner);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // PanelTitleInner
      // 
      this.PanelTitleInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelTitleInner.Controls.Add(this.LabelCurrentView);
      this.PanelTitleInner.Controls.Add(this.LabelTitle);
      resources.ApplyResources(this.PanelTitleInner, "PanelTitleInner");
      this.PanelTitleInner.Name = "PanelTitleInner";
      // 
      // LabelCurrentView
      // 
      this.LabelCurrentView.BackColor = System.Drawing.Color.Transparent;
      resources.ApplyResources(this.LabelCurrentView, "LabelCurrentView");
      this.LabelCurrentView.Name = "LabelCurrentView";
      // 
      // LabelTitle
      // 
      this.LabelTitle.BackColor = System.Drawing.Color.Transparent;
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
            this.ActionPreferences,
            this.ActionSettings,
            this.ActionViewAnalysis,
            this.ActionViewLetters,
            this.ActionViewNotebook,
            this.toolStripSeparator6,
            this.ActionSearchTerm,
            this.ActionNewInstance,
            this.ActionCloseOtherWindows,
            this.toolStripSeparator7,
            this.ActionTools,
            this.ActionWebLinks,
            this.ActionInformation});
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
      this.ActionExit.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionExit.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      this.ActionExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionExit_MouseUp);
      // 
      // Sep4
      // 
      this.Sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep4.Name = "Sep4";
      resources.ApplyResources(this.Sep4, "Sep4");
      // 
      // ActionPreferences
      // 
      this.ActionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPreferences, "ActionPreferences");
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      this.ActionPreferences.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionPreferences.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionSettings
      // 
      this.ActionSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionSettings, "ActionSettings");
      this.ActionSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionScreenPosition,
            this.ActionResetWinSettings,
            this.toolStripSeparator5,
            this.ActionShowKeyboardNotice,
            this.Sep7,
            this.EditShowTips,
            this.EditUseAdvancedDialogBoxes,
            this.EditSoundsEnabled,
            this.EditShowSuccessDialogs,
            this.toolStripSeparator2,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      this.ActionSettings.Name = "ActionSettings";
      this.ActionSettings.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionScreenPosition
      // 
      this.ActionScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      resources.ApplyResources(this.ActionScreenPosition, "ActionScreenPosition");
      this.ActionScreenPosition.Name = "ActionScreenPosition";
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
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // ActionShowKeyboardNotice
      // 
      resources.ApplyResources(this.ActionShowKeyboardNotice, "ActionShowKeyboardNotice");
      this.ActionShowKeyboardNotice.Name = "ActionShowKeyboardNotice";
      this.ActionShowKeyboardNotice.Click += new System.EventHandler(this.ActionShowKeyboardNotice_Click);
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
      // EditShowSuccessDialogs
      // 
      this.EditShowSuccessDialogs.Checked = true;
      this.EditShowSuccessDialogs.CheckOnClick = true;
      this.EditShowSuccessDialogs.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowSuccessDialogs, "EditShowSuccessDialogs");
      this.EditShowSuccessDialogs.Name = "EditShowSuccessDialogs";
      this.EditShowSuccessDialogs.CheckedChanged += new System.EventHandler(this.EditShowSuccessDialogs_CheckedChanged);
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
      this.ActionViewAnalysis.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionViewAnalysis.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionViewLetters
      // 
      this.ActionViewLetters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewLetters, "ActionViewLetters");
      this.ActionViewLetters.Name = "ActionViewLetters";
      this.ActionViewLetters.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewLetters.Click += new System.EventHandler(this.ActionViewLetters_Click);
      this.ActionViewLetters.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionViewLetters.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionViewNotebook
      // 
      this.ActionViewNotebook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewNotebook, "ActionViewNotebook");
      this.ActionViewNotebook.Name = "ActionViewNotebook";
      this.ActionViewNotebook.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewNotebook.Click += new System.EventHandler(this.ActionViewNotebook_Click);
      this.ActionViewNotebook.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionViewNotebook.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
      this.ActionSearchTerm.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchTerm.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionNewInstance
      // 
      this.ActionNewInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionNewInstance, "ActionNewInstance");
      this.ActionNewInstance.Name = "ActionNewInstance";
      this.ActionNewInstance.Padding = new System.Windows.Forms.Padding(5);
      this.ActionNewInstance.Click += new System.EventHandler(this.ActionNewInstance_Click);
      this.ActionNewInstance.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionNewInstance.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionCloseOtherWindows
      // 
      this.ActionCloseOtherWindows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionCloseOtherWindows, "ActionCloseOtherWindows");
      this.ActionCloseOtherWindows.Name = "ActionCloseOtherWindows";
      this.ActionCloseOtherWindows.Padding = new System.Windows.Forms.Padding(5);
      this.ActionCloseOtherWindows.Click += new System.EventHandler(this.ActionCloseOtherWindows_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // ActionTools
      // 
      resources.ApplyResources(this.ActionTools, "ActionTools");
      this.ActionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionShowTranscriptionGuide,
            this.ActionShowGrammarGuide,
            this.ActionShowMethodNotice,
            this.ActionGematriaCombinationsSeparator,
            this.ActionGematriaCombinations,
            this.toolStripSeparator1,
            this.ActionOpenExportFolder,
            this.ActionVacuumDB});
      this.ActionTools.Name = "ActionTools";
      this.ActionTools.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionShowTranscriptionGuide
      // 
      resources.ApplyResources(this.ActionShowTranscriptionGuide, "ActionShowTranscriptionGuide");
      this.ActionShowTranscriptionGuide.Name = "ActionShowTranscriptionGuide";
      this.ActionShowTranscriptionGuide.Click += new System.EventHandler(this.ActionShowTranscriptionGuide_Click);
      // 
      // ActionShowGrammarGuide
      // 
      resources.ApplyResources(this.ActionShowGrammarGuide, "ActionShowGrammarGuide");
      this.ActionShowGrammarGuide.Name = "ActionShowGrammarGuide";
      this.ActionShowGrammarGuide.Click += new System.EventHandler(this.ActionShowGrammarGuide_Click);
      // 
      // ActionShowMethodNotice
      // 
      resources.ApplyResources(this.ActionShowMethodNotice, "ActionShowMethodNotice");
      this.ActionShowMethodNotice.Name = "ActionShowMethodNotice";
      this.ActionShowMethodNotice.Click += new System.EventHandler(this.ActionShowMethodNotice_Click);
      // 
      // ActionGematriaCombinationsSeparator
      // 
      this.ActionGematriaCombinationsSeparator.Name = "ActionGematriaCombinationsSeparator";
      resources.ApplyResources(this.ActionGematriaCombinationsSeparator, "ActionGematriaCombinationsSeparator");
      // 
      // ActionGematriaCombinations
      // 
      resources.ApplyResources(this.ActionGematriaCombinations, "ActionGematriaCombinations");
      this.ActionGematriaCombinations.Name = "ActionGematriaCombinations";
      this.ActionGematriaCombinations.Click += new System.EventHandler(this.ActionGematriaCombinations_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionOpenExportFolder
      // 
      resources.ApplyResources(this.ActionOpenExportFolder, "ActionOpenExportFolder");
      this.ActionOpenExportFolder.Name = "ActionOpenExportFolder";
      this.ActionOpenExportFolder.Click += new System.EventHandler(this.ActionOpenExportFolder_Click);
      // 
      // ActionVacuumDB
      // 
      resources.ApplyResources(this.ActionVacuumDB, "ActionVacuumDB");
      this.ActionVacuumDB.Name = "ActionVacuumDB";
      this.ActionVacuumDB.Click += new System.EventHandler(this.ActionVacuumDB_Click);
      // 
      // ActionWebLinks
      // 
      resources.ApplyResources(this.ActionWebLinks, "ActionWebLinks");
      this.ActionWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionWebLinks.Name = "ActionWebLinks";
      this.ActionWebLinks.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionInformation
      // 
      this.ActionInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionInformation, "ActionInformation");
      this.ActionInformation.Name = "ActionInformation";
      this.ActionInformation.Padding = new System.Windows.Forms.Padding(5);
      // 
      // TimerProcesses
      // 
      this.TimerProcesses.Enabled = true;
      this.TimerProcesses.Interval = 3000;
      this.TimerProcesses.Tick += new System.EventHandler(this.TimerProcesses_Tick);
      // 
      // ContextMenuOpenTermLettriq
      // 
      this.ContextMenuOpenTermLettriq.Name = "ContextMenuOpenTermLettriq";
      this.ContextMenuOpenTermLettriq.ShowImageMargin = false;
      resources.ApplyResources(this.ContextMenuOpenTermLettriq, "ContextMenuOpenTermLettriq");
      // 
      // ContextMenuOpenConcordance
      // 
      this.ContextMenuOpenConcordance.Name = "ContextMenuOpenTermLettriq";
      resources.ApplyResources(this.ContextMenuOpenConcordance, "ContextMenuOpenConcordance");
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
      this.PanelViewAnalysis.ResumeLayout(false);
      this.PanelViewAnalysis.PerformLayout();
      this.PanelWordDetails.ResumeLayout(false);
      this.PanelWordDetails.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditConcordance)).EndInit();
      this.PanelEditWordControl.ResumeLayout(false);
      this.PanelEditWordControl.PerformLayout();
      this.PanelGematria.ResumeLayout(false);
      this.PanelGematria.PerformLayout();
      this.TabPageLetters.ResumeLayout(false);
      this.PanelViewLetters.ResumeLayout(false);
      this.PanelLettersInner.ResumeLayout(false);
      this.PanelLettersInner.PerformLayout();
      this.PanelLetter.ResumeLayout(false);
      this.PanelLetter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LettersBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditMeanings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MeaningsBindingSource)).EndInit();
      this.TabPageNotebook.ResumeLayout(false);
      this.PanelViewNotebook.ResumeLayout(false);
      this.SplitContainerNotebook.Panel1.ResumeLayout(false);
      this.SplitContainerNotebook.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainerNotebook)).EndInit();
      this.SplitContainerNotebook.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookWords)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TermsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookLetters)).EndInit();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ListNotebookSentences)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LettriqsBindingSource)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.PanelTitle.ResumeLayout(false);
      this.PanelTitleInner.ResumeLayout(false);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ToolStripButton ActionExit;
    private System.Windows.Forms.ToolStripSeparator Sep4;
    private System.Windows.Forms.ToolStripDropDownButton ActionSettings;
    private System.Windows.Forms.ToolStripMenuItem ActionScreenPosition;
    private System.Windows.Forms.ToolStripSeparator Sep7;
    public System.Windows.Forms.ToolStripMenuItem EditScreenNone;
    public System.Windows.Forms.ToolStripMenuItem EditScreenCenter;
    public System.Windows.Forms.ToolStripMenuItem EditScreenTopLeft;
    public System.Windows.Forms.ToolStripMenuItem EditScreenTopRight;
    public System.Windows.Forms.ToolStripMenuItem EditScreenBottomLeft;
    public System.Windows.Forms.ToolStripMenuItem EditScreenBottomRight;
    public System.Windows.Forms.ToolStripMenuItem EditConfirmClosing;
    public System.Windows.Forms.ToolStripMenuItem EditShowTips;
    private System.Windows.Forms.ToolStripMenuItem ActionResetWinSettings;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Panel PanelMainOuter;
    private System.Windows.Forms.Panel PanelMainInner;
    private System.Windows.Forms.Timer TimerTooltip;
    public Ordisoftware.Hebrew.LettersControl EditWord;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageText;
    private System.Windows.Forms.Panel PanelViewAnalysis;
    private System.Windows.Forms.TabPage TabPageLetters;
    private System.Windows.Forms.ToolStripButton ActionViewAnalysis;
    private System.Windows.Forms.ToolStripButton ActionViewLetters;
    private Ordisoftware.Core.TextBoxEx TextBoxName;
    private Ordisoftware.Core.TextBoxEx TextBoxValueSimple;
    private Ordisoftware.Core.TextBoxEx TextBoxValueFull;
    private System.Windows.Forms.Panel PanelLettersInner;
    private System.Windows.Forms.LinkLabel ActionRestoreDefaults;
    private System.Windows.Forms.Button ActionDeleteMeaning;
    private System.Windows.Forms.Button ActionAddMeaning;
    private System.Windows.Forms.Panel SelectAnalyze;
    public System.Windows.Forms.CheckBox EditCopyToClipboardCloseApp;
    private System.Windows.Forms.Button ActionCopyToMeanings;
    private System.Windows.Forms.ToolStripButton ActionPreferences;
    public System.Windows.Forms.Label LabelGematria;
    public Ordisoftware.Core.TextBoxEx EditGematriaSimple;
    private System.Windows.Forms.Button ActionReset;
    private System.Windows.Forms.Button ActionDelLast;
    private System.Windows.Forms.Button ActionDelFirst;
    private System.Windows.Forms.DataGridView EditMeanings;
    private System.Windows.Forms.Label LabelHebrew;
    private System.Windows.Forms.ComboBox SelectLetter;
    private System.Windows.Forms.Panel PanelLetter;
    internal System.Windows.Forms.Button ActionCopyToUnicode;
    private System.Windows.Forms.Button ActionSearchOnline;
    private System.Windows.Forms.ContextMenuStrip ContextMenuSearchOnline;
    private System.Windows.Forms.ToolStripButton ActionSearchTerm;
    private System.Windows.Forms.ToolStripDropDownButton ActionTools;
    public Ordisoftware.Core.TextBoxEx EditSentence;
    public System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    private System.Windows.Forms.ToolStripDropDownButton ActionWebLinks;
    private System.Windows.Forms.ToolStripMenuItem ActionShowGrammarGuide;
    private System.Windows.Forms.ToolStripMenuItem ActionShowMethodNotice;
    public Ordisoftware.Core.TextBoxEx TextBoxStructure;
    public Ordisoftware.Core.TextBoxEx TextBoxFunction;
    public Ordisoftware.Core.TextBoxEx TextBoxVerb;
    public Ordisoftware.Core.TextBoxEx TextBoxNegative;
    public Ordisoftware.Core.TextBoxEx TextBoxPositive;
    public System.Windows.Forms.Button ActionClear;
    public System.Windows.Forms.Label LabelGematriaSimple;
    public Ordisoftware.Core.TextBoxEx EditGematriaFull;
    public System.Windows.Forms.Label LabelGematriaFull;
    public System.Windows.Forms.ToolStripMenuItem EditUseAdvancedDialogBoxes;
    public System.Windows.Forms.ToolStripMenuItem EditSoundsEnabled;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.Button ActionScreenshot;
    private System.Windows.Forms.Timer TimerProcesses;
    public System.Windows.Forms.ToolStripDropDownButton ActionInformation;
    private System.Windows.Forms.Button ActionPaste;
    public System.Windows.Forms.ToolStripMenuItem EditShowSuccessDialogs;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem ActionShowKeyboardNotice;
    private System.Windows.Forms.Button ActionCopyToHebrew;
    private System.Windows.Forms.Button ActionSaveScreenshot;
    private System.Windows.Forms.Button ActionViewAllMeaningsList;
    private System.Windows.Forms.Button ActionUndo;
    private System.Windows.Forms.Button ActionSave;
    private System.Windows.Forms.ToolStripButton ActionNewInstance;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    public System.Windows.Forms.CheckBox EditCopyWithFinalLetter;
    private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    public System.Windows.Forms.Label LabelClipboardContentType;
    private System.Windows.Forms.ToolTip ToolTipClipboard;
    internal System.Windows.Forms.Panel PanelMainCenter;
    private Core.ComboBoxNavigator LettersNavigator;
    private System.Windows.Forms.ToolStripSeparator ActionGematriaCombinationsSeparator;
    private System.Windows.Forms.ToolStripMenuItem ActionGematriaCombinations;
    internal System.Windows.Forms.Button ActionCopyToResult;
    private System.Windows.Forms.BindingSource MeaningsBindingSource;
    private System.Windows.Forms.BindingSource LettersBindingSource;
    private System.Windows.Forms.ToolStripButton ActionViewNotebook;
    private System.Windows.Forms.TabPage TabPageNotebook;
    private System.Windows.Forms.Panel PanelViewNotebook;
    private System.Windows.Forms.Panel PanelViewLetters;
    private System.Windows.Forms.SplitContainer SplitContainerNotebook;
    private System.Windows.Forms.DataGridView ListNotebookWords;
    private System.Windows.Forms.BindingSource TermsBindingSource;
    private System.Windows.Forms.DataGridView ListNotebookSentences;
    private System.Windows.Forms.BindingSource LettriqsBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn sentenceDataGridViewTextBoxColumn;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView ListNotebookLetters;
    public System.Windows.Forms.TextBox EditNotebookFilterSentence;
    public System.Windows.Forms.Button ActionNotebookDeleteSentence;
    public System.Windows.Forms.Button ActionNotebookClearWord;
    public System.Windows.Forms.Button ActionNotebookClearLetter;
    private System.Windows.Forms.Button ActionSaveTermLettriq;
    private System.Windows.Forms.Button ActionOpenTermLettriq;
    private System.Windows.Forms.ContextMenuStrip ContextMenuOpenTermLettriq;
    public System.Windows.Forms.Button ActionNotebookClearFilter;
    public System.Windows.Forms.Button ActionNotebookDeleteWord;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.DataGridViewTextBoxColumn hebrewDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
    private System.Windows.Forms.Label LabelCurrentView;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMeaningsText;
    public Core.TextBoxEx EditTranscription;
    public Core.TextBoxEx EditDictionary;
    public System.Windows.Forms.Label LabelDictionary;
    public System.Windows.Forms.Label LabelTranscription;
    public Core.TextBoxEx EditMemo;
    public System.Windows.Forms.Label LabelMemo;
    public System.Windows.Forms.Label LabelCondordance;
    private System.Windows.Forms.NumericUpDown EditConcordance;
    public System.Windows.Forms.Button ActionOpenConcordance;
    private System.Windows.Forms.ContextMenuStrip ContextMenuOpenConcordance;
    internal System.Windows.Forms.Panel PanelWordDetails;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenExportFolder;
    private System.Windows.Forms.ToolStripMenuItem ActionVacuumDB;
    private System.Windows.Forms.Panel PanelEditWordControl;
    internal System.Windows.Forms.ToolStrip ToolStrip;
    internal Panel PanelGematria;
    private Panel PanelTitleInner;
    private ToolStripMenuItem ActionShowTranscriptionGuide;
    private ToolStripButton ActionCloseOtherWindows;
  }
}
