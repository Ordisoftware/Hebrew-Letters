namespace Ordisoftware.Hebrew.Letters
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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionSearch = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ListBoxLetters = new System.Windows.Forms.ListBox();
      this.ListBoxMeanings = new System.Windows.Forms.ListBox();
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
      // ListBoxLetters
      // 
      resources.ApplyResources(this.ListBoxLetters, "ListBoxLetters");
      this.ListBoxLetters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.ListBoxLetters.FormattingEnabled = true;
      this.ListBoxLetters.Name = "ListBoxLetters";
      this.ListBoxLetters.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
      this.ListBoxLetters.SelectedIndexChanged += new System.EventHandler(this.ListBoxLetters_SelectedIndexChanged);
      this.ListBoxLetters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox_KeyDown);
      this.ListBoxLetters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxLetters_MouseDoubleClick);
      // 
      // ListBoxMeanings
      // 
      resources.ApplyResources(this.ListBoxMeanings, "ListBoxMeanings");
      this.ListBoxMeanings.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.ListBoxMeanings.FormattingEnabled = true;
      this.ListBoxMeanings.Name = "ListBoxMeanings";
      this.ListBoxMeanings.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
      this.ListBoxMeanings.SelectedIndexChanged += new System.EventHandler(this.ListBoxMeanings_SelectedIndexChanged);
      this.ListBoxMeanings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox_KeyDown);
      this.ListBoxMeanings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxMeanings_MouseDoubleClick);
      // 
      // SearchTermResultsBox
      // 
      this.AcceptButton = this.ActionSearch;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ListBoxMeanings);
      this.Controls.Add(this.ListBoxLetters);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchTermResultsBox";
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionSearch;
    public System.Windows.Forms.ListBox ListBoxLetters;
    public System.Windows.Forms.ListBox ListBoxMeanings;
  }
}