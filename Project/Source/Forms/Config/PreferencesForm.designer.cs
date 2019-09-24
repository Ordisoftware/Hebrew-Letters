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
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.MenuSelectOnlineVerseURL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionSelectLangEN = new System.Windows.Forms.Button();
      this.ActionSelectLangFR = new System.Windows.Forms.Button();
      this.EditCheckUpdateAtStartup = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      // 
      // PanelButtons
      // 
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Controls.Add(this.ActionClose);
      this.PanelButtons.Name = "PanelButtons";
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
      this.ActionSelectLangEN.FlatAppearance.BorderSize = 0;
      this.ActionSelectLangEN.Name = "ActionSelectLangEN";
      this.ActionSelectLangEN.UseVisualStyleBackColor = true;
      this.ActionSelectLangEN.Click += new System.EventHandler(this.ActionSelectLangEN_Click);
      // 
      // ActionSelectLangFR
      // 
      resources.ApplyResources(this.ActionSelectLangFR, "ActionSelectLangFR");
      this.ActionSelectLangFR.AllowDrop = true;
      this.ActionSelectLangFR.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.ActionSelectLangFR.FlatAppearance.BorderSize = 0;
      this.ActionSelectLangFR.Name = "ActionSelectLangFR";
      this.ActionSelectLangFR.UseVisualStyleBackColor = true;
      this.ActionSelectLangFR.Click += new System.EventHandler(this.ActionSelectLangFR_Click);
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
      this.Controls.Add(this.ActionSelectLangFR);
      this.Controls.Add(this.ActionSelectLangEN);
      this.Controls.Add(this.EditCheckUpdateAtStartup);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.ShowInTaskbar = false;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    private System.Windows.Forms.ContextMenuStrip MenuSelectOnlineVerseURL;
    private System.Windows.Forms.CheckBox EditCheckUpdateAtStartup;
    private System.Windows.Forms.Button ActionSelectLangEN;
    private System.Windows.Forms.Button ActionSelectLangFR;
  }
}