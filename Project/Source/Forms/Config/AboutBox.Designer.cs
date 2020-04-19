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
      this.LabelTitle = new System.Windows.Forms.Label();
      this.LabelVersion = new System.Windows.Forms.Label();
      this.LabelCopyright = new System.Windows.Forms.Label();
      this.LabelTrademark = new System.Windows.Forms.LinkLabel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.EditLicense = new System.Windows.Forms.RichTextBox();
      this.LabelDescription = new System.Windows.Forms.Label();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelTitle
      // 
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // LabelVersion
      // 
      resources.ApplyResources(this.LabelVersion, "LabelVersion");
      this.LabelVersion.Name = "LabelVersion";
      // 
      // LabelCopyright
      // 
      resources.ApplyResources(this.LabelCopyright, "LabelCopyright");
      this.LabelCopyright.Name = "LabelCopyright";
      // 
      // LabelTrademark
      // 
      this.LabelTrademark.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.LabelTrademark, "LabelTrademark");
      this.LabelTrademark.LinkColor = System.Drawing.Color.Navy;
      this.LabelTrademark.Name = "LabelTrademark";
      this.LabelTrademark.TabStop = true;
      this.LabelTrademark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelTrademarkName_LinkClicked);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      // 
      // EditLicense
      // 
      resources.ApplyResources(this.EditLicense, "EditLicense");
      this.EditLicense.BackColor = System.Drawing.SystemColors.Window;
      this.EditLicense.Name = "EditLicense";
      this.EditLicense.ReadOnly = true;
      this.EditLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.editLicense_LinkClicked);
      // 
      // LabelDescription
      // 
      resources.ApplyResources(this.LabelDescription, "LabelDescription");
      this.LabelDescription.Name = "LabelDescription";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // AboutBox
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.LabelDescription);
      this.Controls.Add(this.EditLicense);
      this.Controls.Add(this.LabelTrademark);
      this.Controls.Add(this.LabelCopyright);
      this.Controls.Add(this.LabelVersion);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.AboutBox_Load);
      this.Shown += new System.EventHandler(this.AboutBox_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Label LabelVersion;
    private System.Windows.Forms.Label LabelCopyright;
    private System.Windows.Forms.LinkLabel LabelTrademark;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.RichTextBox EditLicense;
    private System.Windows.Forms.Label LabelDescription;
    private System.Windows.Forms.Panel PanelBottom;
  }
}
