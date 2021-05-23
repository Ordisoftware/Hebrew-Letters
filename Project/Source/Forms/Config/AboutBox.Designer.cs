namespace Ordisoftware.Hebrew.Letters
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
      if ( disposing && ( components != null ) )
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
      this.label10 = new System.Windows.Forms.Label();
      this.linkLabel10 = new System.Windows.Forms.LinkLabel();
      this.LabelDescription = new System.Windows.Forms.Label();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCheckUpdate = new System.Windows.Forms.Button();
      this.ActionViewStats = new System.Windows.Forms.Button();
      this.ActionPrivacyNotice = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.linkLabel3 = new System.Windows.Forms.LinkLabel();
      this.label8 = new System.Windows.Forms.Label();
      this.linkLabel6 = new System.Windows.Forms.LinkLabel();
      this.linkLabel9 = new System.Windows.Forms.LinkLabel();
      this.label12 = new System.Windows.Forms.Label();
      this.linkLabel13 = new System.Windows.Forms.LinkLabel();
      this.label13 = new System.Windows.Forms.Label();
      this.linkLabel14 = new System.Windows.Forms.LinkLabel();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.linkLabel15 = new System.Windows.Forms.LinkLabel();
      this.linkLabel16 = new System.Windows.Forms.LinkLabel();
      this.label16 = new System.Windows.Forms.Label();
      this.linkLabel17 = new System.Windows.Forms.LinkLabel();
      this.label17 = new System.Windows.Forms.Label();
      this.linkLabel18 = new System.Windows.Forms.LinkLabel();
      this.label18 = new System.Windows.Forms.Label();
      this.linkLabel19 = new System.Windows.Forms.LinkLabel();
      this.label19 = new System.Windows.Forms.Label();
      this.linkLabel21 = new System.Windows.Forms.LinkLabel();
      this.label21 = new System.Windows.Forms.Label();
      this.linkLabel22 = new System.Windows.Forms.LinkLabel();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.linkLabel23 = new System.Windows.Forms.LinkLabel();
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
      this.LabelTrademark.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.LabelTrademark.LinkColor = System.Drawing.Color.Navy;
      this.LabelTrademark.Name = "LabelTrademark";
      this.LabelTrademark.TabStop = true;
      this.LabelTrademark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelTrademarkName_LinkClicked);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      // 
      // EditLicense
      // 
      resources.ApplyResources(this.EditLicense, "EditLicense");
      this.EditLicense.BackColor = System.Drawing.SystemColors.Window;
      this.EditLicense.Name = "EditLicense";
      this.EditLicense.ReadOnly = true;
      this.EditLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.EditLicense_LinkClicked);
      // 
      // label10
      // 
      resources.ApplyResources(this.label10, "label10");
      this.label10.Name = "label10";
      // 
      // linkLabel10
      // 
      this.linkLabel10.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel10, "linkLabel10");
      this.linkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel10.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel10.Name = "linkLabel10";
      this.linkLabel10.TabStop = true;
      this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // LabelDescription
      // 
      resources.ApplyResources(this.LabelDescription, "LabelDescription");
      this.LabelDescription.Name = "LabelDescription";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCheckUpdate);
      this.PanelBottom.Controls.Add(this.ActionViewStats);
      this.PanelBottom.Controls.Add(this.ActionPrivacyNotice);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCheckUpdate
      // 
      this.ActionCheckUpdate.AllowDrop = true;
      this.ActionCheckUpdate.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionCheckUpdate, "ActionCheckUpdate");
      this.ActionCheckUpdate.Name = "ActionCheckUpdate";
      this.ActionCheckUpdate.UseVisualStyleBackColor = true;
      this.ActionCheckUpdate.Click += new System.EventHandler(this.ActionCheckUpdate_Click);
      // 
      // ActionViewStats
      // 
      this.ActionViewStats.AllowDrop = true;
      this.ActionViewStats.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionViewStats, "ActionViewStats");
      this.ActionViewStats.Name = "ActionViewStats";
      this.ActionViewStats.UseVisualStyleBackColor = true;
      this.ActionViewStats.Click += new System.EventHandler(this.ActionViewStats_Click);
      // 
      // ActionPrivacyNotice
      // 
      this.ActionPrivacyNotice.AllowDrop = true;
      this.ActionPrivacyNotice.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionPrivacyNotice, "ActionPrivacyNotice");
      this.ActionPrivacyNotice.Name = "ActionPrivacyNotice";
      this.ActionPrivacyNotice.UseVisualStyleBackColor = true;
      this.ActionPrivacyNotice.Click += new System.EventHandler(this.ActionPrivacyNotice_Click);
      // 
      // label5
      // 
      resources.ApplyResources(this.label5, "label5");
      this.label5.Name = "label5";
      // 
      // linkLabel3
      // 
      this.linkLabel3.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel3, "linkLabel3");
      this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel3.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel3.Name = "linkLabel3";
      this.linkLabel3.TabStop = true;
      this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label8
      // 
      resources.ApplyResources(this.label8, "label8");
      this.label8.Name = "label8";
      // 
      // linkLabel6
      // 
      this.linkLabel6.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel6, "linkLabel6");
      this.linkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel6.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel6.Name = "linkLabel6";
      this.linkLabel6.TabStop = true;
      this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // linkLabel9
      // 
      this.linkLabel9.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel9, "linkLabel9");
      this.linkLabel9.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel9.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel9.Name = "linkLabel9";
      this.linkLabel9.TabStop = true;
      this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label12
      // 
      resources.ApplyResources(this.label12, "label12");
      this.label12.Name = "label12";
      // 
      // linkLabel13
      // 
      this.linkLabel13.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel13, "linkLabel13");
      this.linkLabel13.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel13.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel13.Name = "linkLabel13";
      this.linkLabel13.TabStop = true;
      this.linkLabel13.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label13
      // 
      resources.ApplyResources(this.label13, "label13");
      this.label13.Name = "label13";
      // 
      // linkLabel14
      // 
      this.linkLabel14.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel14, "linkLabel14");
      this.linkLabel14.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel14.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel14.Name = "linkLabel14";
      this.linkLabel14.TabStop = true;
      this.linkLabel14.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label14
      // 
      resources.ApplyResources(this.label14, "label14");
      this.label14.Name = "label14";
      // 
      // label15
      // 
      resources.ApplyResources(this.label15, "label15");
      this.label15.Name = "label15";
      // 
      // linkLabel15
      // 
      this.linkLabel15.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel15, "linkLabel15");
      this.linkLabel15.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel15.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel15.Name = "linkLabel15";
      this.linkLabel15.TabStop = true;
      // 
      // linkLabel16
      // 
      this.linkLabel16.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel16, "linkLabel16");
      this.linkLabel16.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel16.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel16.Name = "linkLabel16";
      this.linkLabel16.TabStop = true;
      this.linkLabel16.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label16
      // 
      resources.ApplyResources(this.label16, "label16");
      this.label16.Name = "label16";
      // 
      // linkLabel17
      // 
      this.linkLabel17.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel17, "linkLabel17");
      this.linkLabel17.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel17.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel17.Name = "linkLabel17";
      this.linkLabel17.TabStop = true;
      this.linkLabel17.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label17
      // 
      resources.ApplyResources(this.label17, "label17");
      this.label17.Name = "label17";
      // 
      // linkLabel18
      // 
      this.linkLabel18.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel18, "linkLabel18");
      this.linkLabel18.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel18.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel18.Name = "linkLabel18";
      this.linkLabel18.TabStop = true;
      this.linkLabel18.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label18
      // 
      resources.ApplyResources(this.label18, "label18");
      this.label18.Name = "label18";
      // 
      // linkLabel19
      // 
      this.linkLabel19.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel19, "linkLabel19");
      this.linkLabel19.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel19.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel19.Name = "linkLabel19";
      this.linkLabel19.TabStop = true;
      this.linkLabel19.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label19
      // 
      resources.ApplyResources(this.label19, "label19");
      this.label19.Name = "label19";
      // 
      // linkLabel21
      // 
      this.linkLabel21.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel21, "linkLabel21");
      this.linkLabel21.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel21.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel21.Name = "linkLabel21";
      this.linkLabel21.TabStop = true;
      this.linkLabel21.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label21
      // 
      resources.ApplyResources(this.label21, "label21");
      this.label21.Name = "label21";
      // 
      // linkLabel22
      // 
      this.linkLabel22.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel22, "linkLabel22");
      this.linkLabel22.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel22.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel22.Name = "linkLabel22";
      this.linkLabel22.TabStop = true;
      this.linkLabel22.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelProvider_LinkClicked);
      // 
      // label22
      // 
      resources.ApplyResources(this.label22, "label22");
      this.label22.Name = "label22";
      // 
      // label23
      // 
      resources.ApplyResources(this.label23, "label23");
      this.label23.Name = "label23";
      // 
      // linkLabel23
      // 
      this.linkLabel23.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.linkLabel23, "linkLabel23");
      this.linkLabel23.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.linkLabel23.LinkColor = System.Drawing.Color.Navy;
      this.linkLabel23.Name = "linkLabel23";
      this.linkLabel23.TabStop = true;
      // 
      // AboutBox
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.label23);
      this.Controls.Add(this.linkLabel23);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.linkLabel15);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label21);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.linkLabel21);
      this.Controls.Add(this.linkLabel22);
      this.Controls.Add(this.linkLabel9);
      this.Controls.Add(this.linkLabel14);
      this.Controls.Add(this.linkLabel13);
      this.Controls.Add(this.linkLabel17);
      this.Controls.Add(this.linkLabel16);
      this.Controls.Add(this.linkLabel19);
      this.Controls.Add(this.linkLabel18);
      this.Controls.Add(this.linkLabel6);
      this.Controls.Add(this.linkLabel3);
      this.Controls.Add(this.linkLabel10);
      this.Controls.Add(this.EditLicense);
      this.Controls.Add(this.LabelDescription);
      this.Controls.Add(this.LabelTrademark);
      this.Controls.Add(this.LabelCopyright);
      this.Controls.Add(this.LabelVersion);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
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
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.LinkLabel linkLabel10;
    private System.Windows.Forms.Label LabelDescription;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.LinkLabel linkLabel3;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.LinkLabel linkLabel6;
    private System.Windows.Forms.Button ActionPrivacyNotice;
    private System.Windows.Forms.LinkLabel linkLabel9;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.LinkLabel linkLabel13;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.LinkLabel linkLabel14;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.LinkLabel linkLabel15;
    private System.Windows.Forms.LinkLabel linkLabel16;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.LinkLabel linkLabel17;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.LinkLabel linkLabel18;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.LinkLabel linkLabel19;
    private System.Windows.Forms.Label label19;
    public System.Windows.Forms.Button ActionViewStats;
    public System.Windows.Forms.Button ActionCheckUpdate;
    private System.Windows.Forms.LinkLabel linkLabel21;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.LinkLabel linkLabel22;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.LinkLabel linkLabel23;
  }
}
