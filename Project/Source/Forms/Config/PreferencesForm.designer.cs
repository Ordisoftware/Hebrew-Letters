namespace Ordisoftware.Hebrew.Letters
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
      System.Windows.Forms.Label LabelVolume;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      System.Windows.Forms.Label LabelCheckUpdateFrequency;
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionResetSettings = new System.Windows.Forms.LinkLabel();
      this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.MenuSelectOnlineVerseURL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageApplication = new System.Windows.Forms.TabPage();
      this.EditUsageStatisticsEnabled = new System.Windows.Forms.CheckBox();
      this.EditVolume = new System.Windows.Forms.TrackBar();
      this.ActionSelectLangEN = new System.Windows.Forms.Button();
      this.LabelVolumeValue = new System.Windows.Forms.Label();
      this.ActionSelectLangFR = new System.Windows.Forms.Button();
      this.EditVacuumAtStartup = new System.Windows.Forms.CheckBox();
      this.EditDebuggerEnabled = new System.Windows.Forms.CheckBox();
      this.EditWebLinksMenuEnabled = new System.Windows.Forms.CheckBox();
      this.EditLogEnabled = new System.Windows.Forms.CheckBox();
      this.TabPageCheckUpdate = new System.Windows.Forms.TabPage();
      this.EditCheckUpdateAtStartup = new System.Windows.Forms.CheckBox();
      this.EditCheckUpdateAtStartupInterval = new System.Windows.Forms.NumericUpDown();
      this.LabelCheckUpdateAtStartupInfo = new System.Windows.Forms.Label();
      this.TabPageAnalyzer = new System.Windows.Forms.TabPage();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.EditAutoSortAnalysisMeanings = new System.Windows.Forms.CheckBox();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.EditMaxLength = new System.Windows.Forms.NumericUpDown();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.LabelMaxLength = new System.Windows.Forms.Label();
      LabelVolume = new System.Windows.Forms.Label();
      LabelCheckUpdateFrequency = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageApplication.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditVolume)).BeginInit();
      this.TabPageCheckUpdate.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditCheckUpdateAtStartupInterval)).BeginInit();
      this.TabPageAnalyzer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMaxLength)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelVolume
      // 
      resources.ApplyResources(LabelVolume, "LabelVolume");
      LabelVolume.Name = "LabelVolume";
      // 
      // LabelCheckUpdateFrequency
      // 
      resources.ApplyResources(LabelCheckUpdateFrequency, "LabelCheckUpdateFrequency");
      LabelCheckUpdateFrequency.Name = "LabelCheckUpdateFrequency";
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
      this.PanelBottom.Controls.Add(this.ActionResetSettings);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBottom_Paint);
      // 
      // ActionResetSettings
      // 
      this.ActionResetSettings.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionResetSettings, "ActionResetSettings");
      this.ActionResetSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionResetSettings.LinkColor = System.Drawing.Color.Navy;
      this.ActionResetSettings.Name = "ActionResetSettings";
      this.ActionResetSettings.TabStop = true;
      this.ActionResetSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionResetSettings_LinkClicked);
      // 
      // OpenFileDialog
      // 
      resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
      // 
      // MenuSelectOnlineVerseURL
      // 
      this.MenuSelectOnlineVerseURL.Name = "MenuSelectOnlineVerseURL";
      resources.ApplyResources(this.MenuSelectOnlineVerseURL, "MenuSelectOnlineVerseURL");
      // 
      // TabControl
      // 
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Controls.Add(this.TabPageApplication);
      this.TabControl.Controls.Add(this.TabPageCheckUpdate);
      this.TabControl.Controls.Add(this.TabPageAnalyzer);
      this.TabControl.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default, "PreferencesFormSelectedTabIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.TabControl.Multiline = true;
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = global::Ordisoftware.Hebrew.Letters.Properties.Settings.Default.PreferencesFormSelectedTabIndex;
      // 
      // TabPageApplication
      // 
      this.TabPageApplication.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageApplication.Controls.Add(this.EditUsageStatisticsEnabled);
      this.TabPageApplication.Controls.Add(this.EditVolume);
      this.TabPageApplication.Controls.Add(this.ActionSelectLangEN);
      this.TabPageApplication.Controls.Add(LabelVolume);
      this.TabPageApplication.Controls.Add(this.LabelVolumeValue);
      this.TabPageApplication.Controls.Add(this.ActionSelectLangFR);
      this.TabPageApplication.Controls.Add(this.EditVacuumAtStartup);
      this.TabPageApplication.Controls.Add(this.EditDebuggerEnabled);
      this.TabPageApplication.Controls.Add(this.EditWebLinksMenuEnabled);
      this.TabPageApplication.Controls.Add(this.EditLogEnabled);
      resources.ApplyResources(this.TabPageApplication, "TabPageApplication");
      this.TabPageApplication.Name = "TabPageApplication";
      // 
      // EditUsageStatisticsEnabled
      // 
      resources.ApplyResources(this.EditUsageStatisticsEnabled, "EditUsageStatisticsEnabled");
      this.EditUsageStatisticsEnabled.Name = "EditUsageStatisticsEnabled";
      this.EditUsageStatisticsEnabled.UseVisualStyleBackColor = true;
      this.EditUsageStatisticsEnabled.CheckedChanged += new System.EventHandler(this.EditUsageStatisticsEnabled_CheckedChanged);
      // 
      // EditVolume
      // 
      resources.ApplyResources(this.EditVolume, "EditVolume");
      this.EditVolume.Maximum = 100;
      this.EditVolume.Name = "EditVolume";
      this.EditVolume.TickFrequency = 10;
      this.EditVolume.Value = 100;
      this.EditVolume.ValueChanged += new System.EventHandler(this.EditVolume_ValueChanged);
      // 
      // ActionSelectLangEN
      // 
      this.ActionSelectLangEN.AllowDrop = true;
      this.ActionSelectLangEN.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      resources.ApplyResources(this.ActionSelectLangEN, "ActionSelectLangEN");
      this.ActionSelectLangEN.Name = "ActionSelectLangEN";
      this.ActionSelectLangEN.TabStop = false;
      this.ActionSelectLangEN.UseVisualStyleBackColor = true;
      this.ActionSelectLangEN.Click += new System.EventHandler(this.ActionSelectLangEN_Click);
      // 
      // LabelVolumeValue
      // 
      resources.ApplyResources(this.LabelVolumeValue, "LabelVolumeValue");
      this.LabelVolumeValue.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelVolumeValue.Name = "LabelVolumeValue";
      // 
      // ActionSelectLangFR
      // 
      this.ActionSelectLangFR.AllowDrop = true;
      this.ActionSelectLangFR.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      resources.ApplyResources(this.ActionSelectLangFR, "ActionSelectLangFR");
      this.ActionSelectLangFR.Name = "ActionSelectLangFR";
      this.ActionSelectLangFR.TabStop = false;
      this.ActionSelectLangFR.UseVisualStyleBackColor = true;
      this.ActionSelectLangFR.Click += new System.EventHandler(this.ActionSelectLangFR_Click);
      // 
      // EditVacuumAtStartup
      // 
      resources.ApplyResources(this.EditVacuumAtStartup, "EditVacuumAtStartup");
      this.EditVacuumAtStartup.Name = "EditVacuumAtStartup";
      this.EditVacuumAtStartup.UseVisualStyleBackColor = true;
      // 
      // EditDebuggerEnabled
      // 
      resources.ApplyResources(this.EditDebuggerEnabled, "EditDebuggerEnabled");
      this.EditDebuggerEnabled.Name = "EditDebuggerEnabled";
      this.EditDebuggerEnabled.UseVisualStyleBackColor = true;
      this.EditDebuggerEnabled.CheckedChanged += new System.EventHandler(this.EditDebuggerEnabled_CheckedChanged);
      // 
      // EditWebLinksMenuEnabled
      // 
      resources.ApplyResources(this.EditWebLinksMenuEnabled, "EditWebLinksMenuEnabled");
      this.EditWebLinksMenuEnabled.Name = "EditWebLinksMenuEnabled";
      this.EditWebLinksMenuEnabled.UseVisualStyleBackColor = true;
      // 
      // EditLogEnabled
      // 
      resources.ApplyResources(this.EditLogEnabled, "EditLogEnabled");
      this.EditLogEnabled.Name = "EditLogEnabled";
      this.EditLogEnabled.UseVisualStyleBackColor = true;
      this.EditLogEnabled.CheckedChanged += new System.EventHandler(this.EditLogEnabled_CheckedChanged);
      // 
      // TabPageCheckUpdate
      // 
      this.TabPageCheckUpdate.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageCheckUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageCheckUpdate.Controls.Add(this.EditCheckUpdateAtStartup);
      this.TabPageCheckUpdate.Controls.Add(this.EditCheckUpdateAtStartupInterval);
      this.TabPageCheckUpdate.Controls.Add(this.LabelCheckUpdateAtStartupInfo);
      this.TabPageCheckUpdate.Controls.Add(LabelCheckUpdateFrequency);
      resources.ApplyResources(this.TabPageCheckUpdate, "TabPageCheckUpdate");
      this.TabPageCheckUpdate.Name = "TabPageCheckUpdate";
      // 
      // EditCheckUpdateAtStartup
      // 
      resources.ApplyResources(this.EditCheckUpdateAtStartup, "EditCheckUpdateAtStartup");
      this.EditCheckUpdateAtStartup.Name = "EditCheckUpdateAtStartup";
      this.EditCheckUpdateAtStartup.UseVisualStyleBackColor = true;
      // 
      // EditCheckUpdateAtStartupInterval
      // 
      this.EditCheckUpdateAtStartupInterval.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditCheckUpdateAtStartupInterval, "EditCheckUpdateAtStartupInterval");
      this.EditCheckUpdateAtStartupInterval.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
      this.EditCheckUpdateAtStartupInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.EditCheckUpdateAtStartupInterval.Name = "EditCheckUpdateAtStartupInterval";
      this.EditCheckUpdateAtStartupInterval.ReadOnly = true;
      this.EditCheckUpdateAtStartupInterval.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
      // 
      // LabelCheckUpdateAtStartupInfo
      // 
      resources.ApplyResources(this.LabelCheckUpdateAtStartupInfo, "LabelCheckUpdateAtStartupInfo");
      this.LabelCheckUpdateAtStartupInfo.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelCheckUpdateAtStartupInfo.Name = "LabelCheckUpdateAtStartupInfo";
      // 
      // TabPageAnalyzer
      // 
      this.TabPageAnalyzer.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageAnalyzer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageAnalyzer.Controls.Add(this.label2);
      this.TabPageAnalyzer.Controls.Add(this.label1);
      this.TabPageAnalyzer.Controls.Add(this.EditAutoSortAnalysisMeanings);
      this.TabPageAnalyzer.Controls.Add(this.LabelFontSize);
      this.TabPageAnalyzer.Controls.Add(this.EditMaxLength);
      this.TabPageAnalyzer.Controls.Add(this.EditFontSize);
      this.TabPageAnalyzer.Controls.Add(this.LabelMaxLength);
      resources.ApplyResources(this.TabPageAnalyzer, "TabPageAnalyzer");
      this.TabPageAnalyzer.Name = "TabPageAnalyzer";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
      this.label2.Name = "label2";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
      this.label1.Name = "label1";
      // 
      // EditAutoSortAnalysisMeanings
      // 
      resources.ApplyResources(this.EditAutoSortAnalysisMeanings, "EditAutoSortAnalysisMeanings");
      this.EditAutoSortAnalysisMeanings.Name = "EditAutoSortAnalysisMeanings";
      this.EditAutoSortAnalysisMeanings.UseVisualStyleBackColor = true;
      // 
      // LabelFontSize
      // 
      resources.ApplyResources(this.LabelFontSize, "LabelFontSize");
      this.LabelFontSize.Name = "LabelFontSize";
      // 
      // EditMaxLength
      // 
      this.EditMaxLength.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditMaxLength, "EditMaxLength");
      this.EditMaxLength.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
      this.EditMaxLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.EditMaxLength.Name = "EditMaxLength";
      this.EditMaxLength.ReadOnly = true;
      this.EditMaxLength.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // EditFontSize
      // 
      this.EditFontSize.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditFontSize, "EditFontSize");
      this.EditFontSize.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
      this.EditFontSize.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
      this.EditFontSize.Name = "EditFontSize";
      this.EditFontSize.ReadOnly = true;
      this.EditFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EditFontSize_ValueChanged);
      // 
      // LabelMaxLength
      // 
      resources.ApplyResources(this.LabelMaxLength, "LabelMaxLength");
      this.LabelMaxLength.Name = "LabelMaxLength";
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.ShowInTaskbar = false;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
      this.Load += new System.EventHandler(this.PreferencesForm_Load);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      this.TabControl.ResumeLayout(false);
      this.TabPageApplication.ResumeLayout(false);
      this.TabPageApplication.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditVolume)).EndInit();
      this.TabPageCheckUpdate.ResumeLayout(false);
      this.TabPageCheckUpdate.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditCheckUpdateAtStartupInterval)).EndInit();
      this.TabPageAnalyzer.ResumeLayout(false);
      this.TabPageAnalyzer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMaxLength)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.ResumeLayout(false);

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
    private System.Windows.Forms.CheckBox EditDebuggerEnabled;
    private System.Windows.Forms.NumericUpDown EditMaxLength;
    private System.Windows.Forms.Label LabelMaxLength;
    private System.Windows.Forms.CheckBox EditWebLinksMenuEnabled;
    private System.Windows.Forms.CheckBox EditLogEnabled;
    private System.Windows.Forms.Label LabelCheckUpdateAtStartupInfo;
    private System.Windows.Forms.NumericUpDown EditCheckUpdateAtStartupInterval;
    private System.Windows.Forms.TrackBar EditVolume;
    private System.Windows.Forms.Label LabelVolumeValue;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageApplication;
    private System.Windows.Forms.CheckBox EditUsageStatisticsEnabled;
    private System.Windows.Forms.TabPage TabPageCheckUpdate;
    private System.Windows.Forms.TabPage TabPageAnalyzer;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}