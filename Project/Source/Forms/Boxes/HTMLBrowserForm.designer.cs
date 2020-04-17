namespace Ordisoftware.HebrewLetters
{
  partial class HTMLBrowserForm
  {
    /// <summary>
    /// Required designer variable.
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTMLBrowserForm));
      this.WebBrowser = new System.Windows.Forms.WebBrowser();
      this.SuspendLayout();
      // 
      // WebBrowser
      // 
      this.WebBrowser.AllowWebBrowserDrop = false;
      resources.ApplyResources(this.WebBrowser, "WebBrowser");
      this.WebBrowser.IsWebBrowserContextMenuEnabled = false;
      this.WebBrowser.Name = "WebBrowser";
      this.WebBrowser.ScriptErrorsSuppressed = true;
      this.WebBrowser.WebBrowserShortcutsEnabled = false;
      // 
      // HTMLBrowserForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.GrammarGuideFormSize;
      this.Controls.Add(this.WebBrowser);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "GrammarGuideFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Ordisoftware.HebrewLetters.Properties.Settings.Default, "GrammarGuideFormSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.Location = global::Ordisoftware.HebrewLetters.Properties.Settings.Default.GrammarGuideFormLocation;
      this.MaximizeBox = false;
      this.Name = "HTMLBrowserForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GrammarGuideForm_FormClosing);
      this.Load += new System.EventHandler(this.GrammarGuideForm_Load);
      this.Shown += new System.EventHandler(this.GrammarGuideForm_Shown);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser WebBrowser;
  }
}