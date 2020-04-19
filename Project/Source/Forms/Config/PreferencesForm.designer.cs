namespace Ordisoftware.HebrewLetters
{
  partial class PreferencesForm
  {
    /// <summary>
    /// Required designer variable
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionResetSettings = new System.Windows.Forms.LinkLabel();
      this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.MenuSelectOnlineVerseURL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionSelectLangEN = new System.Windows.Forms.Button();
      this.ActionSelectLangFR = new System.Windows.Forms.Button();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.EditEnableDebugger = new System.Windows.Forms.CheckBox();
      this.EditAutoSortAnalysisMeanings = new System.Windows.Forms.CheckBox();
      this.EditVacuumAtStartup = new System.Windows.Forms.CheckBox();
      this.EditCheckUpdateAtStartup = new System.Windows.Forms.CheckBox();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.SuspendLayout();
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      // 
      // PanelBottom
      // 
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Controls.Add(this.ActionResetSettings);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionResetSettings
      // 
      resources.ApplyResources(this.ActionResetSettings, "ActionResetSettings");
      this.ActionResetSettings.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      this.ActionResetSettings.LinkColor = System.Drawing.Color.Navy;
      this.ActionResetSettings.Name = "ActionResetSettings";
      this.ActionResetSettings.TabStop = true;
      this.ActionResetSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionResetSettings_LinkClicked);
      // 
      // OpenFileDialog
      // 
      resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
      // 
      // FolderBrowserDialog
      // 
      resources.ApplyResources(this.FolderBrowserDialog, "FolderBrowserDialog");
      // 
      // MenuSelectOnlineVerseURL
      // 
      resources.ApplyResources(this.MenuSelectOnlineVerseURL, "MenuSelectOnlineVerseURL");
      this.MenuSelectOnlineVerseURL.Name = "MenuSelectOnlineVerseURL";
      // 
      // ActionSelectLangEN
      // 
      resources.ApplyResources(this.ActionSelectLangEN, "ActionSelectLangEN");
      this.ActionSelectLangEN.AllowDrop = true;
      this.ActionSelectLangEN.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.ActionSelectLangEN.Name = "ActionSelectLangEN";
      this.ActionSelectLangEN.TabStop = false;
      this.ActionSelectLangEN.UseVisualStyleBackColor = true;
      this.ActionSelectLangEN.Click += new System.EventHandler(this.ActionSelectLangEN_Click);
      // 
      // ActionSelectLangFR
      // 
      resources.ApplyResources(this.ActionSelectLangFR, "ActionSelectLangFR");
      this.ActionSelectLangFR.AllowDrop = true;
      this.ActionSelectLangFR.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.ActionSelectLangFR.Name = "ActionSelectLangFR";
      this.ActionSelectLangFR.TabStop = false;
      this.ActionSelectLangFR.UseVisualStyleBackColor = true;
      this.ActionSelectLangFR.Click += new System.EventHandler(this.ActionSelectLangFR_Click);
      // 
      // LabelFontSize
      // 
      resources.ApplyResources(this.LabelFontSize, "LabelFontSize");
      this.LabelFontSize.Name = "LabelFontSize";
      // 
      // EditFontSize
      // 
      resources.ApplyResources(this.EditFontSize, "EditFontSize");
      this.EditFontSize.BackColor = System.Drawing.SystemColors.Window;
      this.EditFontSize.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
      this.EditFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.EditFontSize.Name = "EditFontSize";
      this.EditFontSize.ReadOnly = true;
      this.EditFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EditFontSize_ValueChanged);
      // 
      // EditEnableDebugger
      // 
      resources.ApplyResources(this.EditEnableDebugger, "EditEnableDebugger");
      this.EditEnableDebugger.Checked = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.DebuggerEnabled;
      this.EditEnableDebugger.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditEnableDebugger.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "DebuggerEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditEnableDebugger.Name = "EditEnableDebugger";
      this.EditEnableDebugger.UseVisualStyleBackColor = true;
      this.EditEnableDebugger.CheckedChanged += new System.EventHandler(this.EditEnableDebugger_CheckedChanged);
      // 
      // EditAutoSortAnalysisMeanings
      // 
      resources.ApplyResources(this.EditAutoSortAnalysisMeanings, "EditAutoSortAnalysisMeanings");
      this.EditAutoSortAnalysisMeanings.Checked = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.AutoSortAnalysisMeanings;
      this.EditAutoSortAnalysisMeanings.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditAutoSortAnalysisMeanings.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "AutoSortAnalysisMeanings", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditAutoSortAnalysisMeanings.Name = "EditAutoSortAnalysisMeanings";
      this.EditAutoSortAnalysisMeanings.UseVisualStyleBackColor = true;
      // 
      // EditVacuumAtStartup
      // 
      resources.ApplyResources(this.EditVacuumAtStartup, "EditVacuumAtStartup");
      this.EditVacuumAtStartup.Checked = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.VacuumAtStartup;
      this.EditVacuumAtStartup.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditVacuumAtStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "VacuumAtStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditVacuumAtStartup.Name = "EditVacuumAtStartup";
      this.EditVacuumAtStartup.UseVisualStyleBackColor = true;
      // 
      // EditCheckUpdateAtStartup
      // 
      resources.ApplyResources(this.EditCheckUpdateAtStartup, "EditCheckUpdateAtStartup");
      this.EditCheckUpdateAtStartup.Checked = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.CheckUpdateAtStartup;
      this.EditCheckUpdateAtStartup.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditCheckUpdateAtStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "CheckUpdateAtStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditCheckUpdateAtStartup.Name = "EditCheckUpdateAtStartup";
      this.EditCheckUpdateAtStartup.UseVisualStyleBackColor = true;
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.EditEnableDebugger);
      this.Controls.Add(this.EditAutoSortAnalysisMeanings);
      this.Controls.Add(this.EditVacuumAtStartup);
      this.Controls.Add(this.EditFontSize);
      this.Controls.Add(this.LabelFontSize);
      this.Controls.Add(this.ActionSelectLangFR);
      this.Controls.Add(this.ActionSelectLangEN);
      this.Controls.Add(this.EditCheckUpdateAtStartup);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.ShowInTaskbar = false;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    private System.Windows.Forms.ContextMenuStrip MenuSelectOnlineVerseURL;
    private System.Windows.Forms.CheckBox EditCheckUpdateAtStartup;
    private System.Windows.Forms.Button ActionSelectLangEN;
    private System.Windows.Forms.Button ActionSelectLangFR;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private System.Windows.Forms.Label LabelFontSize;
    private System.Windows.Forms.CheckBox EditVacuumAtStartup;
    private System.Windows.Forms.CheckBox EditAutoSortAnalysisMeanings;
    private System.Windows.Forms.LinkLabel ActionResetSettings;
    private System.Windows.Forms.CheckBox EditEnableDebugger;
  }
}