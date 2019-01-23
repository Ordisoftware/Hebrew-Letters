namespace Ordisoftware.HebrewLettriq
{
  partial class MainForm
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label codeLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.Label nameLabel;
      System.Windows.Forms.Label structureLabel;
      System.Windows.Forms.Label functionLabel;
      System.Windows.Forms.Label valueSimpleLabel;
      System.Windows.Forms.Label valueFullLabel;
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelMainOuter = new System.Windows.Forms.Panel();
      this.PanelMainInner = new System.Windows.Forms.Panel();
      this.PanelMainCenter = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageText = new System.Windows.Forms.TabPage();
      this.PanelViewSearch = new System.Windows.Forms.Panel();
      this.textboxLettrique = new System.Windows.Forms.RichTextBox();
      this.buttonLettrique = new System.Windows.Forms.Button();
      this.buttonClear = new System.Windows.Forms.Button();
      this.TabPageMonth = new System.Windows.Forms.TabPage();
      this.PanelViewSettings = new System.Windows.Forms.Panel();
      this.lettersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.lettersBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
      this.codeTextBox = new System.Windows.Forms.TextBox();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.structureTextBox = new System.Windows.Forms.TextBox();
      this.functionTextBox = new System.Windows.Forms.TextBox();
      this.valueSimpleTextBox = new System.Windows.Forms.TextBox();
      this.valueFullTextBox = new System.Windows.Forms.TextBox();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.moonPhaseImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.Sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionContact = new System.Windows.Forms.ToolStripButton();
      this.ActionWebsite = new System.Windows.Forms.ToolStripButton();
      this.Sep5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHelp = new System.Windows.Forms.ToolStripButton();
      this.ActionAbout = new System.Windows.Forms.ToolStripButton();
      this.Sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.MenuitemScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewSearch = new System.Windows.Forms.ToolStripButton();
      this.ActionViewSettings = new System.Windows.Forms.ToolStripButton();
      this.PanelLetters = new Ordisoftware.HebrewLettriq.LettersControl();
      this.dataSet = new Ordisoftware.HebrewLettriq.Data.DataSet();
      this.lettersBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.lettersTableAdapter = new Ordisoftware.HebrewLettriq.Data.DataSetTableAdapters.LettersTableAdapter();
      this.tableAdapterManager = new Ordisoftware.HebrewLettriq.Data.DataSetTableAdapters.TableAdapterManager();
      this.meaningsTableAdapter = new Ordisoftware.HebrewLettriq.Data.DataSetTableAdapters.MeaningsTableAdapter();
      this.meaningsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.meaningsDataGridView = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      codeLabel = new System.Windows.Forms.Label();
      nameLabel = new System.Windows.Forms.Label();
      structureLabel = new System.Windows.Forms.Label();
      functionLabel = new System.Windows.Forms.Label();
      valueSimpleLabel = new System.Windows.Forms.Label();
      valueFullLabel = new System.Windows.Forms.Label();
      this.PanelMain.SuspendLayout();
      this.PanelMainOuter.SuspendLayout();
      this.PanelMainInner.SuspendLayout();
      this.PanelMainCenter.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageText.SuspendLayout();
      this.PanelViewSearch.SuspendLayout();
      this.TabPageMonth.SuspendLayout();
      this.PanelViewSettings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lettersBindingNavigator)).BeginInit();
      this.lettersBindingNavigator.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).BeginInit();
      this.ToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lettersBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.meaningsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.meaningsDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // codeLabel
      // 
      resources.ApplyResources(codeLabel, "codeLabel");
      codeLabel.Name = "codeLabel";
      // 
      // nameLabel
      // 
      resources.ApplyResources(nameLabel, "nameLabel");
      nameLabel.Name = "nameLabel";
      // 
      // structureLabel
      // 
      resources.ApplyResources(structureLabel, "structureLabel");
      structureLabel.Name = "structureLabel";
      // 
      // functionLabel
      // 
      resources.ApplyResources(functionLabel, "functionLabel");
      functionLabel.Name = "functionLabel";
      // 
      // valueSimpleLabel
      // 
      resources.ApplyResources(valueSimpleLabel, "valueSimpleLabel");
      valueSimpleLabel.Name = "valueSimpleLabel";
      // 
      // valueFullLabel
      // 
      resources.ApplyResources(valueFullLabel, "valueFullLabel");
      valueFullLabel.Name = "valueFullLabel";
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.PanelMainOuter);
      this.PanelMain.Controls.Add(this.PanelSepTop);
      this.PanelMain.Controls.Add(this.PanelTitle);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // PanelMainOuter
      // 
      this.PanelMainOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelMainOuter.Controls.Add(this.PanelMainInner);
      resources.ApplyResources(this.PanelMainOuter, "PanelMainOuter");
      this.PanelMainOuter.Name = "PanelMainOuter";
      // 
      // PanelMainInner
      // 
      this.PanelMainInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelMainInner.Controls.Add(this.PanelMainCenter);
      resources.ApplyResources(this.PanelMainInner, "PanelMainInner");
      this.PanelMainInner.Name = "PanelMainInner";
      // 
      // PanelMainCenter
      // 
      this.PanelMainCenter.Controls.Add(this.TabControl);
      resources.ApplyResources(this.PanelMainCenter, "PanelMainCenter");
      this.PanelMainCenter.Name = "PanelMainCenter";
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageText);
      this.TabControl.Controls.Add(this.TabPageMonth);
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // TabPageText
      // 
      this.TabPageText.Controls.Add(this.PanelViewSearch);
      resources.ApplyResources(this.TabPageText, "TabPageText");
      this.TabPageText.Name = "TabPageText";
      this.TabPageText.UseVisualStyleBackColor = true;
      // 
      // PanelViewSearch
      // 
      this.PanelViewSearch.Controls.Add(this.PanelLetters);
      this.PanelViewSearch.Controls.Add(this.textboxLettrique);
      this.PanelViewSearch.Controls.Add(this.buttonLettrique);
      this.PanelViewSearch.Controls.Add(this.buttonClear);
      resources.ApplyResources(this.PanelViewSearch, "PanelViewSearch");
      this.PanelViewSearch.Name = "PanelViewSearch";
      // 
      // textboxLettrique
      // 
      resources.ApplyResources(this.textboxLettrique, "textboxLettrique");
      this.textboxLettrique.Name = "textboxLettrique";
      // 
      // buttonLettrique
      // 
      resources.ApplyResources(this.buttonLettrique, "buttonLettrique");
      this.buttonLettrique.Name = "buttonLettrique";
      this.buttonLettrique.UseVisualStyleBackColor = true;
      this.buttonLettrique.Click += new System.EventHandler(this.buttonLettrique_Click);
      // 
      // buttonClear
      // 
      resources.ApplyResources(this.buttonClear, "buttonClear");
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.UseVisualStyleBackColor = true;
      this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
      // 
      // TabPageMonth
      // 
      this.TabPageMonth.Controls.Add(this.PanelViewSettings);
      resources.ApplyResources(this.TabPageMonth, "TabPageMonth");
      this.TabPageMonth.Name = "TabPageMonth";
      this.TabPageMonth.UseVisualStyleBackColor = true;
      // 
      // PanelViewSettings
      // 
      resources.ApplyResources(this.PanelViewSettings, "PanelViewSettings");
      this.PanelViewSettings.Controls.Add(this.meaningsDataGridView);
      this.PanelViewSettings.Controls.Add(this.lettersBindingNavigator);
      this.PanelViewSettings.Controls.Add(codeLabel);
      this.PanelViewSettings.Controls.Add(this.codeTextBox);
      this.PanelViewSettings.Controls.Add(nameLabel);
      this.PanelViewSettings.Controls.Add(this.nameTextBox);
      this.PanelViewSettings.Controls.Add(structureLabel);
      this.PanelViewSettings.Controls.Add(this.structureTextBox);
      this.PanelViewSettings.Controls.Add(functionLabel);
      this.PanelViewSettings.Controls.Add(this.functionTextBox);
      this.PanelViewSettings.Controls.Add(valueSimpleLabel);
      this.PanelViewSettings.Controls.Add(this.valueSimpleTextBox);
      this.PanelViewSettings.Controls.Add(valueFullLabel);
      this.PanelViewSettings.Controls.Add(this.valueFullTextBox);
      this.PanelViewSettings.Name = "PanelViewSettings";
      // 
      // lettersBindingNavigator
      // 
      this.lettersBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
      this.lettersBindingNavigator.BindingSource = this.lettersBindingSource;
      this.lettersBindingNavigator.CountItem = this.bindingNavigatorCountItem;
      this.lettersBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
      this.lettersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.lettersBindingNavigatorSaveItem});
      resources.ApplyResources(this.lettersBindingNavigator, "lettersBindingNavigator");
      this.lettersBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.lettersBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.lettersBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.lettersBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.lettersBindingNavigator.Name = "lettersBindingNavigator";
      this.lettersBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
      // 
      // bindingNavigatorAddNewItem
      // 
      this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorAddNewItem, "bindingNavigatorAddNewItem");
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
      // 
      // bindingNavigatorDeleteItem
      // 
      this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorDeleteItem, "bindingNavigatorDeleteItem");
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      // 
      // bindingNavigatorSeparator
      // 
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
      // 
      // bindingNavigatorPositionItem
      // 
      resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      // 
      // bindingNavigatorSeparator2
      // 
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
      // 
      // lettersBindingNavigatorSaveItem
      // 
      this.lettersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.lettersBindingNavigatorSaveItem, "lettersBindingNavigatorSaveItem");
      this.lettersBindingNavigatorSaveItem.Name = "lettersBindingNavigatorSaveItem";
      this.lettersBindingNavigatorSaveItem.Click += new System.EventHandler(this.lettersBindingNavigatorSaveItem_Click_1);
      // 
      // codeTextBox
      // 
      this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "Code", true));
      resources.ApplyResources(this.codeTextBox, "codeTextBox");
      this.codeTextBox.Name = "codeTextBox";
      // 
      // nameTextBox
      // 
      this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "Name", true));
      resources.ApplyResources(this.nameTextBox, "nameTextBox");
      this.nameTextBox.Name = "nameTextBox";
      // 
      // structureTextBox
      // 
      this.structureTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "Structure", true));
      resources.ApplyResources(this.structureTextBox, "structureTextBox");
      this.structureTextBox.Name = "structureTextBox";
      // 
      // functionTextBox
      // 
      this.functionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "Function", true));
      resources.ApplyResources(this.functionTextBox, "functionTextBox");
      this.functionTextBox.Name = "functionTextBox";
      // 
      // valueSimpleTextBox
      // 
      this.valueSimpleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "ValueSimple", true));
      resources.ApplyResources(this.valueSimpleTextBox, "valueSimpleTextBox");
      this.valueSimpleTextBox.Name = "valueSimpleTextBox";
      // 
      // valueFullTextBox
      // 
      this.valueFullTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lettersBindingSource, "ValueFull", true));
      resources.ApplyResources(this.valueFullTextBox, "valueFullTextBox");
      this.valueFullTextBox.Name = "valueFullTextBox";
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.LabelTitle);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // LabelTitle
      // 
      this.LabelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // moonPhaseImagePictureBox
      // 
      this.moonPhaseImagePictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
      resources.ApplyResources(this.moonPhaseImagePictureBox, "moonPhaseImagePictureBox");
      this.moonPhaseImagePictureBox.Name = "moonPhaseImagePictureBox";
      this.moonPhaseImagePictureBox.TabStop = false;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // TimerTooltip
      // 
      this.TimerTooltip.Interval = 500;
      this.TimerTooltip.Tick += new System.EventHandler(this.TimerTooltip_Tick);
      // 
      // ToolStrip
      // 
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionExit,
            this.Sep4,
            this.ActionContact,
            this.ActionWebsite,
            this.Sep5,
            this.ActionHelp,
            this.ActionAbout,
            this.Sep6,
            this.MenuSettings,
            this.ActionViewSearch,
            this.ActionViewSettings});
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // ActionExit
      // 
      this.ActionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionExit, "ActionExit");
      this.ActionExit.Name = "ActionExit";
      this.ActionExit.Padding = new System.Windows.Forms.Padding(5);
      this.ActionExit.Click += new System.EventHandler(this.ActionExit_Click);
      this.ActionExit.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionExit.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep4
      // 
      this.Sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep4.Name = "Sep4";
      resources.ApplyResources(this.Sep4, "Sep4");
      // 
      // ActionContact
      // 
      this.ActionContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionContact, "ActionContact");
      this.ActionContact.Name = "ActionContact";
      this.ActionContact.Padding = new System.Windows.Forms.Padding(5);
      this.ActionContact.Click += new System.EventHandler(this.ActionContact_Click);
      this.ActionContact.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionContact.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionWebsite
      // 
      this.ActionWebsite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionWebsite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionWebsite, "ActionWebsite");
      this.ActionWebsite.Name = "ActionWebsite";
      this.ActionWebsite.Padding = new System.Windows.Forms.Padding(5);
      this.ActionWebsite.Click += new System.EventHandler(this.ActionApplicationHome_Click);
      this.ActionWebsite.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionWebsite.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep5
      // 
      this.Sep5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep5.Name = "Sep5";
      resources.ApplyResources(this.Sep5, "Sep5");
      // 
      // ActionHelp
      // 
      this.ActionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.Padding = new System.Windows.Forms.Padding(5);
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      this.ActionHelp.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionHelp.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionAbout
      // 
      this.ActionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionAbout, "ActionAbout");
      this.ActionAbout.Name = "ActionAbout";
      this.ActionAbout.Padding = new System.Windows.Forms.Padding(5);
      this.ActionAbout.Click += new System.EventHandler(this.ActionAbout_Click);
      this.ActionAbout.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionAbout.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep6
      // 
      this.Sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep6.Name = "Sep6";
      resources.ApplyResources(this.Sep6, "Sep6");
      // 
      // MenuSettings
      // 
      this.MenuSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.MenuSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuitemScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.EditShowTips,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      resources.ApplyResources(this.MenuSettings, "MenuSettings");
      this.MenuSettings.Name = "MenuSettings";
      // 
      // MenuitemScreenPosition
      // 
      this.MenuitemScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      resources.ApplyResources(this.MenuitemScreenPosition, "MenuitemScreenPosition");
      this.MenuitemScreenPosition.Name = "MenuitemScreenPosition";
      // 
      // EditScreenNone
      // 
      this.EditScreenNone.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenNone, "EditScreenNone");
      this.EditScreenNone.Name = "EditScreenNone";
      this.EditScreenNone.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopLeft
      // 
      this.EditScreenTopLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopLeft, "EditScreenTopLeft");
      this.EditScreenTopLeft.Name = "EditScreenTopLeft";
      this.EditScreenTopLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopRight
      // 
      this.EditScreenTopRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopRight, "EditScreenTopRight");
      this.EditScreenTopRight.Name = "EditScreenTopRight";
      this.EditScreenTopRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomLeft
      // 
      this.EditScreenBottomLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomLeft, "EditScreenBottomLeft");
      this.EditScreenBottomLeft.Name = "EditScreenBottomLeft";
      this.EditScreenBottomLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomRight
      // 
      this.EditScreenBottomRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomRight, "EditScreenBottomRight");
      this.EditScreenBottomRight.Name = "EditScreenBottomRight";
      this.EditScreenBottomRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenCenter
      // 
      this.EditScreenCenter.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenCenter, "EditScreenCenter");
      this.EditScreenCenter.Name = "EditScreenCenter";
      this.EditScreenCenter.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // ActionResetWinSettings
      // 
      resources.ApplyResources(this.ActionResetWinSettings, "ActionResetWinSettings");
      this.ActionResetWinSettings.Name = "ActionResetWinSettings";
      this.ActionResetWinSettings.Click += new System.EventHandler(this.ActionResetWinSettings_Click);
      // 
      // Sep7
      // 
      this.Sep7.Name = "Sep7";
      resources.ApplyResources(this.Sep7, "Sep7");
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowTips, "EditShowTips");
      this.EditShowTips.Name = "EditShowTips";
      // 
      // EditESCtoExit
      // 
      this.EditESCtoExit.Checked = true;
      this.EditESCtoExit.CheckOnClick = true;
      this.EditESCtoExit.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditESCtoExit, "EditESCtoExit");
      this.EditESCtoExit.Name = "EditESCtoExit";
      // 
      // EditConfirmClosing
      // 
      resources.ApplyResources(this.EditConfirmClosing, "EditConfirmClosing");
      this.EditConfirmClosing.Checked = true;
      this.EditConfirmClosing.CheckOnClick = true;
      this.EditConfirmClosing.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditConfirmClosing.Name = "EditConfirmClosing";
      // 
      // ActionViewSearch
      // 
      this.ActionViewSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewSearch, "ActionViewSearch");
      this.ActionViewSearch.Name = "ActionViewSearch";
      this.ActionViewSearch.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewSearch.Click += new System.EventHandler(this.ActionViewSearch_Click);
      this.ActionViewSearch.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionViewSearch.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionViewSettings
      // 
      this.ActionViewSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewSettings, "ActionViewSettings");
      this.ActionViewSettings.Name = "ActionViewSettings";
      this.ActionViewSettings.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewSettings.Click += new System.EventHandler(this.ActionViewSettings_Click);
      this.ActionViewSettings.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionViewSettings.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // PanelLetters
      // 
      this.PanelLetters.BackColor = System.Drawing.Color.Transparent;
      this.PanelLetters.InputBackground = System.Drawing.SystemColors.Window;
      this.PanelLetters.LettersBackground = System.Drawing.Color.LightYellow;
      resources.ApplyResources(this.PanelLetters, "PanelLetters");
      this.PanelLetters.Name = "PanelLetters";
      this.PanelLetters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PanelLetters_KeyPress);
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "DataSet";
      this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // lettersBindingSource
      // 
      this.lettersBindingSource.DataMember = "Letters";
      this.lettersBindingSource.DataSource = this.dataSet;
      // 
      // lettersTableAdapter
      // 
      this.lettersTableAdapter.ClearBeforeFill = true;
      // 
      // tableAdapterManager
      // 
      this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
      this.tableAdapterManager.LettersTableAdapter = this.lettersTableAdapter;
      this.tableAdapterManager.MeaningsTableAdapter = this.meaningsTableAdapter;
      this.tableAdapterManager.UpdateOrder = Ordisoftware.HebrewLettriq.Data.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // meaningsTableAdapter
      // 
      this.meaningsTableAdapter.ClearBeforeFill = true;
      // 
      // meaningsBindingSource
      // 
      this.meaningsBindingSource.DataMember = "Letters_Meanings";
      this.meaningsBindingSource.DataSource = this.lettersBindingSource;
      // 
      // meaningsDataGridView
      // 
      this.meaningsDataGridView.AutoGenerateColumns = false;
      this.meaningsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.meaningsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
      this.meaningsDataGridView.DataSource = this.meaningsBindingSource;
      resources.ApplyResources(this.meaningsDataGridView, "meaningsDataGridView");
      this.meaningsDataGridView.Name = "meaningsDataGridView";
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "LetterCode";
      resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "Meaning";
      resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.ToolStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.PanelMain.ResumeLayout(false);
      this.PanelMainOuter.ResumeLayout(false);
      this.PanelMainInner.ResumeLayout(false);
      this.PanelMainCenter.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.TabPageText.ResumeLayout(false);
      this.PanelViewSearch.ResumeLayout(false);
      this.TabPageMonth.ResumeLayout(false);
      this.PanelViewSettings.ResumeLayout(false);
      this.PanelViewSettings.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lettersBindingNavigator)).EndInit();
      this.lettersBindingNavigator.ResumeLayout(false);
      this.lettersBindingNavigator.PerformLayout();
      this.PanelTitle.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).EndInit();
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lettersBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.meaningsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.meaningsDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton ActionWebsite;
    private System.Windows.Forms.ToolStripButton ActionContact;
    private System.Windows.Forms.ToolStripButton ActionExit;
    private System.Windows.Forms.ToolStripButton ActionAbout;
    private System.Windows.Forms.ToolStripSeparator Sep4;
    private System.Windows.Forms.ToolStripSeparator Sep5;
    private System.Windows.Forms.ToolStripDropDownButton MenuSettings;
    private System.Windows.Forms.ToolStripMenuItem MenuitemScreenPosition;
    private System.Windows.Forms.ToolStripButton ActionHelp;
    private System.Windows.Forms.ToolStripSeparator Sep7;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenNone;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenCenter;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopRight;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomRight;
    internal System.Windows.Forms.ToolStripMenuItem EditConfirmClosing;
    internal System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    private System.Windows.Forms.ToolStripMenuItem ActionResetWinSettings;
    internal System.Windows.Forms.ToolStripMenuItem EditShowTips;
    private System.Windows.Forms.ToolStripSeparator Sep6;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Panel PanelMainOuter;
    private System.Windows.Forms.Panel PanelMainInner;
    private System.Windows.Forms.PictureBox moonPhaseImagePictureBox;
    private System.Windows.Forms.Label label1;
    internal System.Windows.Forms.Panel PanelMainCenter;
    private System.Windows.Forms.Timer TimerTooltip;
    private System.Windows.Forms.Button buttonClear;
    private System.Windows.Forms.Button buttonLettrique;
    private LettersControl PanelLetters;
    private System.Windows.Forms.RichTextBox textboxLettrique;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageText;
    private System.Windows.Forms.Panel PanelViewSearch;
    private System.Windows.Forms.TabPage TabPageMonth;
    private System.Windows.Forms.Panel PanelViewSettings;
    private System.Windows.Forms.ToolStripButton ActionViewSearch;
    private System.Windows.Forms.ToolStripButton ActionViewSettings;
    private Data.DataSet dataSet;
    private System.Windows.Forms.BindingSource lettersBindingSource;
    private Data.DataSetTableAdapters.LettersTableAdapter lettersTableAdapter;
    private Data.DataSetTableAdapters.TableAdapterManager tableAdapterManager;
    private System.Windows.Forms.BindingNavigator lettersBindingNavigator;
    private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    private System.Windows.Forms.ToolStripButton lettersBindingNavigatorSaveItem;
    private System.Windows.Forms.TextBox codeTextBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.TextBox structureTextBox;
    private System.Windows.Forms.TextBox functionTextBox;
    private System.Windows.Forms.TextBox valueSimpleTextBox;
    private System.Windows.Forms.TextBox valueFullTextBox;
    private Data.DataSetTableAdapters.MeaningsTableAdapter meaningsTableAdapter;
    private System.Windows.Forms.DataGridView meaningsDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.BindingSource meaningsBindingSource;
  }
}

