namespace Ordisoftware.Hebrew.Letters
{
  partial class SearchTermBox
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTermBox));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionSearch = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.EditTerm = new Ordisoftware.Core.UndoRedoTextBox();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionSearch);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
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
      this.EditTerm.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditTerm.Name = "EditTerm";
      this.EditTerm.TextChanged += new System.EventHandler(this.EditTerm_TextChanged);
      // 
      // SearchTermBox
      // 
      this.AcceptButton = this.ActionSearch;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditTerm);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchTermBox";
      this.ShowInTaskbar = false;
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionSearch;
    private System.Windows.Forms.Button ActionCancel;
    internal Ordisoftware.Core.UndoRedoTextBox EditTerm;
  }
}
