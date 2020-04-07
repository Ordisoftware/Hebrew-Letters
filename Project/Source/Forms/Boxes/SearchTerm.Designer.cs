namespace Ordisoftware.HebrewLetters
{
  partial class SearchMeaning
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchMeaning));
      this.panel1 = new System.Windows.Forms.Panel();
      this.ActionSearch = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.EditTerm = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.ActionSearch);
      this.panel1.Controls.Add(this.ActionCancel);
      resources.ApplyResources(this.panel1, "panel1");
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
      // EditTerm
      // 
      resources.ApplyResources(this.EditTerm, "EditTerm");
      this.EditTerm.Name = "EditTerm";
      this.EditTerm.TextChanged += new System.EventHandler(this.EditTerm_TextChanged);
      // 
      // SearchMeaning
      // 
      this.AcceptButton = this.ActionSearch;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditTerm);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchMeaning";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button ActionSearch;
    private System.Windows.Forms.Button ActionCancel;
    internal System.Windows.Forms.TextBox EditTerm;
  }
}