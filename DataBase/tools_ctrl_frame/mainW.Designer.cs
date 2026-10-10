namespace tools_ctrl_frame
{
    partial class mainW
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
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("借还工器具");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("申请维修");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("申报报废");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("工器具操作", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("工器具信息查询");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("员工信息查询");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("项目信息查询");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("部门信息查询");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("维修查询");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("报废查询");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("借还情况查询");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("数据查询", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("我的");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("员工管理");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("工器具管理");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("表查询");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("条码生成");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("管理员", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainW));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工器具操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还工器具ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.申请维修ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申报报废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工器具查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.部门信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维修查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报废查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还情况查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我的ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工器具管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还工器具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请试验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请报废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.条码生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 884);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前登录用户：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工器具操作ToolStripMenuItem,
            this.数据查询ToolStripMenuItem,
            this.我的ToolStripMenuItem,
            this.管理员ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 工器具操作ToolStripMenuItem
            // 
            this.工器具操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借还工器具ToolStripMenuItem1,
            this.申请维修ToolStripMenuItem,
            this.申报报废ToolStripMenuItem});
            this.工器具操作ToolStripMenuItem.Name = "工器具操作ToolStripMenuItem";
            this.工器具操作ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.工器具操作ToolStripMenuItem.Text = "工器具操作";
            this.工器具操作ToolStripMenuItem.Click += new System.EventHandler(this.工器具操作ToolStripMenuItem_Click);
            // 
            // 借还工器具ToolStripMenuItem1
            // 
            this.借还工器具ToolStripMenuItem1.Name = "借还工器具ToolStripMenuItem1";
            this.借还工器具ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.借还工器具ToolStripMenuItem1.Text = "借还工器具";
            this.借还工器具ToolStripMenuItem1.Click += new System.EventHandler(this.借还工器具ToolStripMenuItem1_Click);
            // 
            // 申请维修ToolStripMenuItem
            // 
            this.申请维修ToolStripMenuItem.Name = "申请维修ToolStripMenuItem";
            this.申请维修ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.申请维修ToolStripMenuItem.Text = "申请维修";
            this.申请维修ToolStripMenuItem.Click += new System.EventHandler(this.申请维修ToolStripMenuItem_Click);
            // 
            // 申报报废ToolStripMenuItem
            // 
            this.申报报废ToolStripMenuItem.Name = "申报报废ToolStripMenuItem";
            this.申报报废ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.申报报废ToolStripMenuItem.Text = "申报报废";
            this.申报报废ToolStripMenuItem.Click += new System.EventHandler(this.申报报废ToolStripMenuItem_Click);
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工器具查询ToolStripMenuItem,
            this.员工信息查询ToolStripMenuItem,
            this.项目查询ToolStripMenuItem,
            this.部门信息查询ToolStripMenuItem,
            this.维修查询ToolStripMenuItem,
            this.报废查询ToolStripMenuItem,
            this.借还情况查询ToolStripMenuItem});
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            this.数据查询ToolStripMenuItem.Click += new System.EventHandler(this.数据查询ToolStripMenuItem_Click);
            // 
            // 工器具查询ToolStripMenuItem
            // 
            this.工器具查询ToolStripMenuItem.Name = "工器具查询ToolStripMenuItem";
            this.工器具查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.工器具查询ToolStripMenuItem.Text = "工器具信息查询";
            this.工器具查询ToolStripMenuItem.Click += new System.EventHandler(this.工器具查询ToolStripMenuItem_Click);
            // 
            // 员工信息查询ToolStripMenuItem
            // 
            this.员工信息查询ToolStripMenuItem.Name = "员工信息查询ToolStripMenuItem";
            this.员工信息查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.员工信息查询ToolStripMenuItem.Text = "员工信息查询";
            this.员工信息查询ToolStripMenuItem.Click += new System.EventHandler(this.员工信息查询ToolStripMenuItem_Click);
            // 
            // 项目查询ToolStripMenuItem
            // 
            this.项目查询ToolStripMenuItem.Name = "项目查询ToolStripMenuItem";
            this.项目查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.项目查询ToolStripMenuItem.Text = "项目信息查询";
            this.项目查询ToolStripMenuItem.Click += new System.EventHandler(this.项目查询ToolStripMenuItem_Click);
            // 
            // 部门信息查询ToolStripMenuItem
            // 
            this.部门信息查询ToolStripMenuItem.Name = "部门信息查询ToolStripMenuItem";
            this.部门信息查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.部门信息查询ToolStripMenuItem.Text = "部门信息查询";
            this.部门信息查询ToolStripMenuItem.Click += new System.EventHandler(this.部门信息查询ToolStripMenuItem_Click);
            // 
            // 维修查询ToolStripMenuItem
            // 
            this.维修查询ToolStripMenuItem.Name = "维修查询ToolStripMenuItem";
            this.维修查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.维修查询ToolStripMenuItem.Text = "维修查询";
            this.维修查询ToolStripMenuItem.Click += new System.EventHandler(this.维修查询ToolStripMenuItem_Click);
            // 
            // 报废查询ToolStripMenuItem
            // 
            this.报废查询ToolStripMenuItem.Name = "报废查询ToolStripMenuItem";
            this.报废查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.报废查询ToolStripMenuItem.Text = "报废查询";
            this.报废查询ToolStripMenuItem.Click += new System.EventHandler(this.报废查询ToolStripMenuItem_Click);
            // 
            // 借还情况查询ToolStripMenuItem
            // 
            this.借还情况查询ToolStripMenuItem.Name = "借还情况查询ToolStripMenuItem";
            this.借还情况查询ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.借还情况查询ToolStripMenuItem.Text = "借还情况查询";
            this.借还情况查询ToolStripMenuItem.Click += new System.EventHandler(this.借还情况查询ToolStripMenuItem_Click);
            // 
            // 我的ToolStripMenuItem
            // 
            this.我的ToolStripMenuItem.Name = "我的ToolStripMenuItem";
            this.我的ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.我的ToolStripMenuItem.Text = "我的";
            this.我的ToolStripMenuItem.Click += new System.EventHandler(this.我的ToolStripMenuItem_Click);
            // 
            // 管理员ToolStripMenuItem
            // 
            this.管理员ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.员工管理ToolStripMenuItem,
            this.工器具管理ToolStripMenuItem,
            this.表查询ToolStripMenuItem,
            this.条码生成ToolStripMenuItem});
            this.管理员ToolStripMenuItem.Name = "管理员ToolStripMenuItem";
            this.管理员ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.管理员ToolStripMenuItem.Text = "管理员";
            // 
            // 员工管理ToolStripMenuItem
            // 
            this.员工管理ToolStripMenuItem.Name = "员工管理ToolStripMenuItem";
            this.员工管理ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.员工管理ToolStripMenuItem.Text = "员工管理";
            this.员工管理ToolStripMenuItem.Click += new System.EventHandler(this.员工管理ToolStripMenuItem_Click);
            // 
            // 工器具管理ToolStripMenuItem
            // 
            this.工器具管理ToolStripMenuItem.Name = "工器具管理ToolStripMenuItem";
            this.工器具管理ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.工器具管理ToolStripMenuItem.Text = "工器具管理";
            this.工器具管理ToolStripMenuItem.Click += new System.EventHandler(this.工器具管理ToolStripMenuItem_Click);
            // 
            // 表查询ToolStripMenuItem
            // 
            this.表查询ToolStripMenuItem.Name = "表查询ToolStripMenuItem";
            this.表查询ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.表查询ToolStripMenuItem.Text = "表查询";
            this.表查询ToolStripMenuItem.Click += new System.EventHandler(this.表查询ToolStripMenuItem_Click);
            // 
            // 借还工器具ToolStripMenuItem
            // 
            this.借还工器具ToolStripMenuItem.Name = "借还工器具ToolStripMenuItem";
            this.借还工器具ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 申请试验ToolStripMenuItem
            // 
            this.申请试验ToolStripMenuItem.Name = "申请试验ToolStripMenuItem";
            this.申请试验ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.申请试验ToolStripMenuItem.Text = "申请试验";
            // 
            // 申请ToolStripMenuItem
            // 
            this.申请ToolStripMenuItem.Name = "申请ToolStripMenuItem";
            this.申请ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.申请ToolStripMenuItem.Text = "申请维修";
            // 
            // 申请报废ToolStripMenuItem
            // 
            this.申请报废ToolStripMenuItem.Name = "申请报废ToolStripMenuItem";
            this.申请报废ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.申请报废ToolStripMenuItem.Text = "申报报废";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 30;
            this.treeView1.Location = new System.Drawing.Point(0, 31);
            this.treeView1.Name = "treeView1";
            treeNode19.Name = "节点10";
            treeNode19.Text = "借还工器具";
            treeNode20.Name = "节点12";
            treeNode20.Text = "申请维修";
            treeNode21.Name = "节点13";
            treeNode21.Text = "申报报废";
            treeNode22.Name = "节点5";
            treeNode22.Text = "工器具操作";
            treeNode23.Name = "节点15";
            treeNode23.Text = "工器具信息查询";
            treeNode24.Name = "节点16";
            treeNode24.Text = "员工信息查询";
            treeNode25.Name = "节点17";
            treeNode25.Text = "项目信息查询";
            treeNode26.Name = "节点18";
            treeNode26.Text = "部门信息查询";
            treeNode27.Name = "节点20";
            treeNode27.Text = "维修查询";
            treeNode28.Name = "节点21";
            treeNode28.Text = "报废查询";
            treeNode29.Name = "节点0";
            treeNode29.Text = "借还情况查询";
            treeNode30.Name = "节点6";
            treeNode30.Text = "数据查询";
            treeNode31.Name = "节点7";
            treeNode31.Text = "我的";
            treeNode32.Name = "节点27";
            treeNode32.Text = "员工管理";
            treeNode33.Name = "节点28";
            treeNode33.Text = "工器具管理";
            treeNode34.Name = "节点1";
            treeNode34.Text = "表查询";
            treeNode35.Name = "";
            treeNode35.Text = "条码生成";
            treeNode36.Name = "节点9";
            treeNode36.Text = "管理员";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode30,
            treeNode31,
            treeNode36});
            this.treeView1.Size = new System.Drawing.Size(269, 850);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(275, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 850);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 822);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "AI助手";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 条码生成ToolStripMenuItem
            // 
            this.条码生成ToolStripMenuItem.Name = "条码生成ToolStripMenuItem";
            this.条码生成ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.条码生成ToolStripMenuItem.Text = "条码生成";
            this.条码生成ToolStripMenuItem.Click += new System.EventHandler(this.条码生成ToolStripMenuItem_Click);
            // 
            // mainW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1382, 944);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 1000);
            this.MinimizeBox = false;
            this.Name = "mainW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.mainW_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工器具操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还工器具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请试验ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请报废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我的ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工器具查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 员工信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 部门信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维修查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报废查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 员工管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工器具管理ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 借还工器具ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 申请维修ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申报报废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还情况查询ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 条码生成ToolStripMenuItem;
    }
}