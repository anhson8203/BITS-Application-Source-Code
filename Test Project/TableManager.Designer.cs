namespace Test_Project
{
    partial class TableManager
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableManager));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmItemsCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTotalCost = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmItemsCount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lsvBill);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            resources.ApplyResources(this.lsvBill, "lsvBill");
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.nmItemsCount);
            this.panel4.Controls.Add(this.btnAddItems);
            this.panel4.Controls.Add(this.cbItems);
            this.panel4.Controls.Add(this.cbCategory);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // nmItemsCount
            // 
            this.nmItemsCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.nmItemsCount, "nmItemsCount");
            this.nmItemsCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmItemsCount.Name = "nmItemsCount";
            this.nmItemsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItems
            // 
            this.btnAddItems.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItems.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnAddItems, "btnAddItems");
            this.btnAddItems.ForeColor = System.Drawing.Color.Black;
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.UseVisualStyleBackColor = false;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // cbItems
            // 
            resources.ApplyResources(this.cbItems, "cbItems");
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Name = "cbItems";
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.cbCategory, "cbCategory");
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            resources.ApplyResources(this.adminToolStripMenuItem, "adminToolStripMenuItem");
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountInfoToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            resources.ApplyResources(this.accountToolStripMenuItem, "accountToolStripMenuItem");
            // 
            // accountInfoToolStripMenuItem
            // 
            this.accountInfoToolStripMenuItem.Name = "accountInfoToolStripMenuItem";
            resources.ApplyResources(this.accountInfoToolStripMenuItem, "accountInfoToolStripMenuItem");
            this.accountInfoToolStripMenuItem.Click += new System.EventHandler(this.accountInfoToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            resources.ApplyResources(this.logoutToolStripMenuItem, "logoutToolStripMenuItem");
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // flpTable
            // 
            resources.ApplyResources(this.flpTable, "flpTable");
            this.flpTable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpTable.Name = "flpTable";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbTotalCost);
            this.panel1.Controls.Add(this.cbSwitchTable);
            this.panel1.Controls.Add(this.btnSwitchTable);
            this.panel1.Controls.Add(this.nmDiscount);
            this.panel1.Controls.Add(this.btnDiscount);
            this.panel1.Controls.Add(this.btnCheckOut);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // txbTotalCost
            // 
            this.txbTotalCost.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txbTotalCost, "txbTotalCost");
            this.txbTotalCost.ForeColor = System.Drawing.Color.Black;
            this.txbTotalCost.Name = "txbTotalCost";
            this.txbTotalCost.ReadOnly = true;
            // 
            // cbSwitchTable
            // 
            resources.ApplyResources(this.cbSwitchTable, "cbSwitchTable");
            this.cbSwitchTable.ForeColor = System.Drawing.Color.Black;
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Name = "cbSwitchTable";
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSwitchTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchTable.FlatAppearance.BorderSize = 0;
            this.btnSwitchTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            resources.ApplyResources(this.btnSwitchTable, "btnSwitchTable");
            this.btnSwitchTable.ForeColor = System.Drawing.Color.Black;
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.UseVisualStyleBackColor = false;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nmDiscount
            // 
            this.nmDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.nmDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.nmDiscount, "nmDiscount");
            this.nmDiscount.Name = "nmDiscount";
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnDiscount, "btnDiscount");
            this.btnDiscount.ForeColor = System.Drawing.Color.Black;
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.UseVisualStyleBackColor = false;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Lime;
            this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCheckOut, "btnCheckOut");
            this.btnCheckOut.ForeColor = System.Drawing.Color.Black;
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Form;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateInactive.Back.Color1 = System.Drawing.Color.Black;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.SystemColors.MenuHighlight;
            // 
            // TableManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TableManager";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.UseDropShadow = true;
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmItemsCount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel2;
        private ListView lsvBill;
        private Panel panel4;
        private ComboBox cbCategory;
        private ComboBox cbItems;
        private Button btnAddItems;
        private NumericUpDown nmItemsCount;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem accountInfoToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private FlowLayoutPanel flpTable;
        private Panel panel1;
        private Button btnCheckOut;
        private Button btnDiscount;
        private NumericUpDown nmDiscount;
        private ComboBox cbSwitchTable;
        private Button btnSwitchTable;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox txbTotalCost;
        private Label label1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}