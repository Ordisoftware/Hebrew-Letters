namespace Ordisoftware.HebrewLetters
{
  partial class SearchTermResultsBox
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTermResultsBox));
      this.panel1 = new System.Windows.Forms.Panel();
      this.ActionSearch = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.Listbox = new System.Windows.Forms.ListBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Controls.Add(this.ActionSearch);
      this.panel1.Controls.Add(this.ActionCancel);
      this.panel1.Name = "panel1";
      // 
      // ActionSearch
      // 
      resources.ApplyResources(this.ActionSearch, "ActionSearch");
      this.ActionSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionSearch.Name = "ActionSearch";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // Listbox
      // 
      resources.ApplyResources(this.Listbox, "Listbox");
      this.Listbox.FormattingEnabled = true;
      this.Listbox.Name = "Listbox";
      this.Listbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Listbox_MouseDoubleClick);
      // 
      // SearchTermResults
      // 
      this.AcceptButton = this.ActionSearch;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.Listbox);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchTermResults";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionSearch;
    internal System.Windows.Forms.ListBox Listbox;
  }
}