namespace Ordisoftware.HebrewLetters
{
  partial class AboutBox
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.labelTrademark = new System.Windows.Forms.LinkLabel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.editLicense = new System.Windows.Forms.RichTextBox();
      this.labelDescription = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelTitle
      // 
      resources.ApplyResources(this.labelTitle, "labelTitle");
      this.labelTitle.Name = "labelTitle";
      // 
      // labelVersion
      // 
      resources.ApplyResources(this.labelVersion, "labelVersion");
      this.labelVersion.Name = "labelVersion";
      // 
      // labelCopyright
      // 
      resources.ApplyResources(this.labelCopyright, "labelCopyright");
      this.labelCopyright.Name = "labelCopyright";
      // 
      // labelTrademark
      // 
      resources.ApplyResources(this.labelTrademark, "labelTrademark");
      this.labelTrademark.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      this.labelTrademark.LinkColor = System.Drawing.Color.Navy;
      this.labelTrademark.Name = "labelTrademark";
      this.labelTrademark.TabStop = true;
      this.labelTrademark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelTrademarkName_LinkClicked);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      // 
      // editLicense
      // 
      resources.ApplyResources(this.editLicense, "editLicense");
      this.editLicense.BackColor = System.Drawing.SystemColors.Window;
      this.editLicense.Name = "editLicense";
      this.editLicense.ReadOnly = true;
      this.editLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.editLicense_LinkClicked);
      // 
      // labelDescription
      // 
      resources.ApplyResources(this.labelDescription, "labelDescription");
      this.labelDescription.Name = "labelDescription";
      // 
      // panel1
      // 
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Controls.Add(this.ActionClose);
      this.panel1.Name = "panel1";
      // 
      // AboutBox
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.labelDescription);
      this.Controls.Add(this.editLicense);
      this.Controls.Add(this.labelTrademark);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.labelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.AboutBox_Load);
      this.Shown += new System.EventHandler(this.AboutBox_Shown);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.LinkLabel labelTrademark;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.RichTextBox editLicense;
    private System.Windows.Forms.Label labelDescription;
    private System.Windows.Forms.Panel panel1;
  }
}
