namespace project
{
    partial class main
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBrokenCount = new System.Windows.Forms.Label();
            this.dgvBroken = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.검색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.필터해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수리완료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFind1 = new System.Windows.Forms.TextBox();
            this.btnSearchCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvActive = new System.Windows.Forms.DataGridView();
            this.cboSearchField = new System.Windows.Forms.ComboBox();
            this.radioEqName = new System.Windows.Forms.RadioButton();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.radioSolName = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabIssueReturn = new System.Windows.Forms.TabControl();
            this.tabIssue = new System.Windows.Forms.TabPage();
            this.btnIssue = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIssueMilConfirm = new System.Windows.Forms.Button();
            this.txtIssueMilNo = new System.Windows.Forms.TextBox();
            this.lblIssueEquipInfo = new System.Windows.Forms.Label();
            this.lblIssueMilNo = new System.Windows.Forms.Label();
            this.btnIssueEquipConfirm = new System.Windows.Forms.Button();
            this.txtIssueEquipCode = new System.Windows.Forms.TextBox();
            this.tabReturn = new System.Windows.Forms.TabPage();
            this.grpReturnType = new System.Windows.Forms.GroupBox();
            this.chkReturnService = new System.Windows.Forms.CheckBox();
            this.rdoReturnBroken = new System.Windows.Forms.RadioButton();
            this.rdoReturnNormal = new System.Windows.Forms.RadioButton();
            this.lblReturnInfo = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblReturnGuide = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecentCount = new System.Windows.Forms.Label();
            this.lvRecent = new System.Windows.Forms.ListView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBroken)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActive)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabIssueReturn.SuspendLayout();
            this.tabIssue.SuspendLayout();
            this.tabReturn.SuspendLayout();
            this.grpReturnType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(658, 2);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(652, 471);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "고장/수리중 장비";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblBrokenCount, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvBroken, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(648, 453);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // lblBrokenCount
            // 
            this.lblBrokenCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrokenCount.AutoSize = true;
            this.lblBrokenCount.Location = new System.Drawing.Point(595, 0);
            this.lblBrokenCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrokenCount.Name = "lblBrokenCount";
            this.lblBrokenCount.Size = new System.Drawing.Size(51, 12);
            this.lblBrokenCount.TabIndex = 17;
            this.lblBrokenCount.Text = "총 000정";
            // 
            // dgvBroken
            // 
            this.dgvBroken.AllowUserToAddRows = false;
            this.dgvBroken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBroken.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvBroken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBroken.Location = new System.Drawing.Point(2, 21);
            this.dgvBroken.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBroken.Name = "dgvBroken";
            this.dgvBroken.RowHeadersWidth = 72;
            this.dgvBroken.RowTemplate.Height = 34;
            this.dgvBroken.Size = new System.Drawing.Size(644, 430);
            this.dgvBroken.TabIndex = 2;
            this.dgvBroken.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBroken_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.검색ToolStripMenuItem,
            this.필터해제ToolStripMenuItem,
            this.수리완료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 검색ToolStripMenuItem
            // 
            this.검색ToolStripMenuItem.Name = "검색ToolStripMenuItem";
            this.검색ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.검색ToolStripMenuItem.Text = "상세 검색";
            this.검색ToolStripMenuItem.Click += new System.EventHandler(this.검색ToolStripMenuItem_Click);
            // 
            // 필터해제ToolStripMenuItem
            // 
            this.필터해제ToolStripMenuItem.Name = "필터해제ToolStripMenuItem";
            this.필터해제ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.필터해제ToolStripMenuItem.Text = "검색 초기화";
            this.필터해제ToolStripMenuItem.Click += new System.EventHandler(this.필터해제ToolStripMenuItem_Click);
            // 
            // 수리완료ToolStripMenuItem
            // 
            this.수리완료ToolStripMenuItem.Name = "수리완료ToolStripMenuItem";
            this.수리완료ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.수리완료ToolStripMenuItem.Text = "수리 완료";
            this.수리완료ToolStripMenuItem.Click += new System.EventHandler(this.수리완료ToolStripMenuItem_Click);
            // 
            // txtFind1
            // 
            this.txtFind1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind1.Location = new System.Drawing.Point(139, 26);
            this.txtFind1.Margin = new System.Windows.Forms.Padding(2);
            this.txtFind1.Name = "txtFind1";
            this.txtFind1.Size = new System.Drawing.Size(435, 21);
            this.txtFind1.TabIndex = 26;
            this.txtFind1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind1_KeyDown);
            // 
            // btnSearchCode
            // 
            this.btnSearchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCode.Location = new System.Drawing.Point(578, 27);
            this.btnSearchCode.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchCode.Name = "btnSearchCode";
            this.btnSearchCode.Size = new System.Drawing.Size(50, 20);
            this.btnSearchCode.TabIndex = 25;
            this.btnSearchCode.Text = "확인";
            this.btnSearchCode.UseVisualStyleBackColor = true;
            this.btnSearchCode.Click += new System.EventHandler(this.btnSearchCode_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "▼검색 기준";
            // 
            // dgvActive
            // 
            this.dgvActive.AllowUserToAddRows = false;
            this.dgvActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActive.Location = new System.Drawing.Point(2, 118);
            this.dgvActive.Margin = new System.Windows.Forms.Padding(2);
            this.dgvActive.Name = "dgvActive";
            this.dgvActive.RowHeadersWidth = 72;
            this.dgvActive.RowTemplate.Height = 34;
            this.dgvActive.Size = new System.Drawing.Size(644, 333);
            this.dgvActive.TabIndex = 0;
            this.dgvActive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActive_CellClick);
            // 
            // cboSearchField
            // 
            this.cboSearchField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchField.FormattingEnabled = true;
            this.cboSearchField.Location = new System.Drawing.Point(13, 27);
            this.cboSearchField.Margin = new System.Windows.Forms.Padding(2);
            this.cboSearchField.Name = "cboSearchField";
            this.cboSearchField.Size = new System.Drawing.Size(101, 20);
            this.cboSearchField.TabIndex = 30;
            // 
            // radioEqName
            // 
            this.radioEqName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioEqName.AutoSize = true;
            this.radioEqName.Checked = true;
            this.radioEqName.Location = new System.Drawing.Point(13, 17);
            this.radioEqName.Margin = new System.Windows.Forms.Padding(2);
            this.radioEqName.Name = "radioEqName";
            this.radioEqName.Size = new System.Drawing.Size(47, 16);
            this.radioEqName.TabIndex = 29;
            this.radioEqName.TabStop = true;
            this.radioEqName.Text = "장비";
            this.radioEqName.UseVisualStyleBackColor = true;
            this.radioEqName.CheckedChanged += new System.EventHandler(this.radioEqName_CheckedChanged);
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.Location = new System.Drawing.Point(577, 12);
            this.lblActiveCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(51, 12);
            this.lblActiveCount.TabIndex = 19;
            this.lblActiveCount.Text = "총 000명";
            // 
            // radioSolName
            // 
            this.radioSolName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioSolName.AutoSize = true;
            this.radioSolName.Location = new System.Drawing.Point(88, 17);
            this.radioSolName.Margin = new System.Windows.Forms.Padding(2);
            this.radioSolName.Name = "radioSolName";
            this.radioSolName.Size = new System.Drawing.Size(47, 16);
            this.radioSolName.TabIndex = 28;
            this.radioSolName.TabStop = true;
            this.radioSolName.Text = "병력";
            this.radioSolName.UseVisualStyleBackColor = true;
            this.radioSolName.CheckedChanged += new System.EventHandler(this.radioSolName_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(652, 471);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "지급중 병력(미회수)";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvActive, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 453);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioSolName);
            this.panel1.Controls.Add(this.lblActiveCount);
            this.panel1.Controls.Add(this.radioEqName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 45);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearchCode);
            this.panel2.Controls.Add(this.txtFind1);
            this.panel2.Controls.Add(this.cboSearchField);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 59);
            this.panel2.TabIndex = 2;
            // 
            // tabIssueReturn
            // 
            this.tabIssueReturn.Controls.Add(this.tabIssue);
            this.tabIssueReturn.Controls.Add(this.tabReturn);
            this.tabIssueReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIssueReturn.Location = new System.Drawing.Point(2, 16);
            this.tabIssueReturn.Margin = new System.Windows.Forms.Padding(2);
            this.tabIssueReturn.Name = "tabIssueReturn";
            this.tabIssueReturn.SelectedIndex = 0;
            this.tabIssueReturn.Size = new System.Drawing.Size(401, 235);
            this.tabIssueReturn.TabIndex = 0;
            // 
            // tabIssue
            // 
            this.tabIssue.Controls.Add(this.btnIssue);
            this.tabIssue.Controls.Add(this.label15);
            this.tabIssue.Controls.Add(this.label8);
            this.tabIssue.Controls.Add(this.btnIssueMilConfirm);
            this.tabIssue.Controls.Add(this.txtIssueMilNo);
            this.tabIssue.Controls.Add(this.lblIssueEquipInfo);
            this.tabIssue.Controls.Add(this.lblIssueMilNo);
            this.tabIssue.Controls.Add(this.btnIssueEquipConfirm);
            this.tabIssue.Controls.Add(this.txtIssueEquipCode);
            this.tabIssue.Location = new System.Drawing.Point(4, 22);
            this.tabIssue.Margin = new System.Windows.Forms.Padding(2);
            this.tabIssue.Name = "tabIssue";
            this.tabIssue.Padding = new System.Windows.Forms.Padding(2);
            this.tabIssue.Size = new System.Drawing.Size(393, 209);
            this.tabIssue.TabIndex = 0;
            this.tabIssue.Text = "지급";
            this.tabIssue.UseVisualStyleBackColor = true;
            this.tabIssue.Click += new System.EventHandler(this.tabIssue_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIssue.Location = new System.Drawing.Point(294, 158);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(57, 23);
            this.btnIssue.TabIndex = 68;
            this.btnIssue.Text = "지급";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(24, 94);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 67;
            this.label15.Text = "지급 장비";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(24, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "지급자 정보";
            // 
            // btnIssueMilConfirm
            // 
            this.btnIssueMilConfirm.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIssueMilConfirm.Location = new System.Drawing.Point(306, 35);
            this.btnIssueMilConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssueMilConfirm.Name = "btnIssueMilConfirm";
            this.btnIssueMilConfirm.Size = new System.Drawing.Size(45, 26);
            this.btnIssueMilConfirm.TabIndex = 62;
            this.btnIssueMilConfirm.Text = "상세";
            this.btnIssueMilConfirm.UseVisualStyleBackColor = true;
            this.btnIssueMilConfirm.Click += new System.EventHandler(this.btnIssueMilConfirm_Click);
            // 
            // txtIssueMilNo
            // 
            this.txtIssueMilNo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIssueMilNo.Location = new System.Drawing.Point(95, 41);
            this.txtIssueMilNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtIssueMilNo.Name = "txtIssueMilNo";
            this.txtIssueMilNo.Size = new System.Drawing.Size(190, 21);
            this.txtIssueMilNo.TabIndex = 61;
            this.txtIssueMilNo.Click += new System.EventHandler(this.btnIssueEquipConfirm_Click);
            this.txtIssueMilNo.TextChanged += new System.EventHandler(this.txtIssueMilNo_TextChanged_1);
            this.txtIssueMilNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtIssueMilNo_MouseDown);
            // 
            // lblIssueEquipInfo
            // 
            this.lblIssueEquipInfo.AutoSize = true;
            this.lblIssueEquipInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIssueEquipInfo.Location = new System.Drawing.Point(24, 118);
            this.lblIssueEquipInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueEquipInfo.Name = "lblIssueEquipInfo";
            this.lblIssueEquipInfo.Size = new System.Drawing.Size(57, 12);
            this.lblIssueEquipInfo.TabIndex = 60;
            this.lblIssueEquipInfo.Text = "장비코드:";
            // 
            // lblIssueMilNo
            // 
            this.lblIssueMilNo.AutoSize = true;
            this.lblIssueMilNo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIssueMilNo.Location = new System.Drawing.Point(24, 42);
            this.lblIssueMilNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueMilNo.Name = "lblIssueMilNo";
            this.lblIssueMilNo.Size = new System.Drawing.Size(33, 12);
            this.lblIssueMilNo.TabIndex = 59;
            this.lblIssueMilNo.Text = "군번:";
            // 
            // btnIssueEquipConfirm
            // 
            this.btnIssueEquipConfirm.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIssueEquipConfirm.Location = new System.Drawing.Point(306, 111);
            this.btnIssueEquipConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssueEquipConfirm.Name = "btnIssueEquipConfirm";
            this.btnIssueEquipConfirm.Size = new System.Drawing.Size(45, 26);
            this.btnIssueEquipConfirm.TabIndex = 58;
            this.btnIssueEquipConfirm.Text = "상세";
            this.btnIssueEquipConfirm.UseVisualStyleBackColor = true;
            this.btnIssueEquipConfirm.Click += new System.EventHandler(this.btnIssueEquipConfirm_Click);
            // 
            // txtIssueEquipCode
            // 
            this.txtIssueEquipCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIssueEquipCode.Location = new System.Drawing.Point(95, 117);
            this.txtIssueEquipCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtIssueEquipCode.Name = "txtIssueEquipCode";
            this.txtIssueEquipCode.Size = new System.Drawing.Size(190, 21);
            this.txtIssueEquipCode.TabIndex = 55;
            this.txtIssueEquipCode.Click += new System.EventHandler(this.txtIssueEquipCode_TextChanged);
            this.txtIssueEquipCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtIssueEquipCode_MouseDown);
            // 
            // tabReturn
            // 
            this.tabReturn.Controls.Add(this.grpReturnType);
            this.tabReturn.Controls.Add(this.lblReturnInfo);
            this.tabReturn.Controls.Add(this.btnReturn);
            this.tabReturn.Controls.Add(this.lblReturnGuide);
            this.tabReturn.Location = new System.Drawing.Point(4, 22);
            this.tabReturn.Margin = new System.Windows.Forms.Padding(2);
            this.tabReturn.Name = "tabReturn";
            this.tabReturn.Padding = new System.Windows.Forms.Padding(2);
            this.tabReturn.Size = new System.Drawing.Size(394, 209);
            this.tabReturn.TabIndex = 1;
            this.tabReturn.Text = "회수";
            this.tabReturn.UseVisualStyleBackColor = true;
            // 
            // grpReturnType
            // 
            this.grpReturnType.Controls.Add(this.chkReturnService);
            this.grpReturnType.Controls.Add(this.rdoReturnBroken);
            this.grpReturnType.Controls.Add(this.rdoReturnNormal);
            this.grpReturnType.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpReturnType.Location = new System.Drawing.Point(7, 108);
            this.grpReturnType.Margin = new System.Windows.Forms.Padding(2);
            this.grpReturnType.Name = "grpReturnType";
            this.grpReturnType.Padding = new System.Windows.Forms.Padding(2);
            this.grpReturnType.Size = new System.Drawing.Size(339, 43);
            this.grpReturnType.TabIndex = 71;
            this.grpReturnType.TabStop = false;
            this.grpReturnType.Text = "회수 결과";
            // 
            // chkReturnService
            // 
            this.chkReturnService.AutoSize = true;
            this.chkReturnService.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkReturnService.Location = new System.Drawing.Point(249, 18);
            this.chkReturnService.Margin = new System.Windows.Forms.Padding(2);
            this.chkReturnService.Name = "chkReturnService";
            this.chkReturnService.Size = new System.Drawing.Size(76, 16);
            this.chkReturnService.TabIndex = 72;
            this.chkReturnService.Text = "수리 요청";
            this.chkReturnService.UseVisualStyleBackColor = true;
            // 
            // rdoReturnBroken
            // 
            this.rdoReturnBroken.AutoSize = true;
            this.rdoReturnBroken.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoReturnBroken.Location = new System.Drawing.Point(127, 17);
            this.rdoReturnBroken.Margin = new System.Windows.Forms.Padding(2);
            this.rdoReturnBroken.Name = "rdoReturnBroken";
            this.rdoReturnBroken.Size = new System.Drawing.Size(75, 16);
            this.rdoReturnBroken.TabIndex = 71;
            this.rdoReturnBroken.TabStop = true;
            this.rdoReturnBroken.Text = "고장 회수";
            this.rdoReturnBroken.UseVisualStyleBackColor = true;
            this.rdoReturnBroken.CheckedChanged += new System.EventHandler(this.rdoReturnBroken_CheckedChanged);
            // 
            // rdoReturnNormal
            // 
            this.rdoReturnNormal.AutoSize = true;
            this.rdoReturnNormal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoReturnNormal.Location = new System.Drawing.Point(10, 18);
            this.rdoReturnNormal.Margin = new System.Windows.Forms.Padding(2);
            this.rdoReturnNormal.Name = "rdoReturnNormal";
            this.rdoReturnNormal.Size = new System.Drawing.Size(75, 16);
            this.rdoReturnNormal.TabIndex = 70;
            this.rdoReturnNormal.TabStop = true;
            this.rdoReturnNormal.Text = "정상 회수";
            this.rdoReturnNormal.UseVisualStyleBackColor = true;
            // 
            // lblReturnInfo
            // 
            this.lblReturnInfo.AutoSize = true;
            this.lblReturnInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReturnInfo.Location = new System.Drawing.Point(4, 53);
            this.lblReturnInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturnInfo.Name = "lblReturnInfo";
            this.lblReturnInfo.Size = new System.Drawing.Size(125, 12);
            this.lblReturnInfo.TabIndex = 70;
            this.lblReturnInfo.Text = "선택된 지급 내역 정보";
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturn.Location = new System.Drawing.Point(293, 160);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(57, 23);
            this.btnReturn.TabIndex = 69;
            this.btnReturn.Text = "회수";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblReturnGuide
            // 
            this.lblReturnGuide.AutoSize = true;
            this.lblReturnGuide.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReturnGuide.Location = new System.Drawing.Point(9, 9);
            this.lblReturnGuide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturnGuide.Name = "lblReturnGuide";
            this.lblReturnGuide.Size = new System.Drawing.Size(209, 24);
            this.lblReturnGuide.TabIndex = 66;
            this.lblReturnGuide.Text = "※ ‘지급중 병력(미회수)’에서 대상을\r\n      선택 후, 회수 방식을 지정하세요.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabIssueReturn);
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(405, 253);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "지급/회수";
            // 
            // groupBox5
            // 
            this.groupBox5.CausesValidation = false;
            this.groupBox5.Controls.Add(this.tableLayoutPanel1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(411, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(899, 253);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "최근 지급·회수 내역";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblRecentCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvRecent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 235);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // lblRecentCount
            // 
            this.lblRecentCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecentCount.AutoSize = true;
            this.lblRecentCount.Location = new System.Drawing.Point(842, 0);
            this.lblRecentCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecentCount.Name = "lblRecentCount";
            this.lblRecentCount.Size = new System.Drawing.Size(51, 12);
            this.lblRecentCount.TabIndex = 18;
            this.lblRecentCount.Text = "총 000건";
            // 
            // lvRecent
            // 
            this.lvRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecent.FullRowSelect = true;
            this.lvRecent.GridLines = true;
            this.lvRecent.HideSelection = false;
            this.lvRecent.Location = new System.Drawing.Point(3, 21);
            this.lvRecent.Name = "lvRecent";
            this.lvRecent.Size = new System.Drawing.Size(889, 224);
            this.lvRecent.TabIndex = 17;
            this.lvRecent.UseCompatibleStateImageBehavior = false;
            this.lvRecent.View = System.Windows.Forms.View.Details;
            this.lvRecent.SelectedIndexChanged += new System.EventHandler(this.lvRecent_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.93552F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1318, 744);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox6, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 266);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1312, 475);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 409F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1312, 257);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1318, 744);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "main";
            this.Text = "main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBroken)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActive)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabIssueReturn.ResumeLayout(false);
            this.tabIssue.ResumeLayout(false);
            this.tabIssue.PerformLayout();
            this.tabReturn.ResumeLayout(false);
            this.tabReturn.PerformLayout();
            this.grpReturnType.ResumeLayout(false);
            this.grpReturnType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvBroken;
        private System.Windows.Forms.Label lblBrokenCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 검색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 필터해제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수리완료ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabIssueReturn;
        private System.Windows.Forms.TabPage tabIssue;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnIssueMilConfirm;
        private System.Windows.Forms.TextBox txtIssueMilNo;
        private System.Windows.Forms.Label lblIssueEquipInfo;
        private System.Windows.Forms.Label lblIssueMilNo;
        private System.Windows.Forms.Button btnIssueEquipConfirm;
        private System.Windows.Forms.TextBox txtIssueEquipCode;
        private System.Windows.Forms.TabPage tabReturn;
        private System.Windows.Forms.GroupBox grpReturnType;
        private System.Windows.Forms.CheckBox chkReturnService;
        private System.Windows.Forms.RadioButton rdoReturnBroken;
        private System.Windows.Forms.RadioButton rdoReturnNormal;
        private System.Windows.Forms.Label lblReturnInfo;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblReturnGuide;
        private System.Windows.Forms.TextBox txtFind1;
        private System.Windows.Forms.Button btnSearchCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvActive;
        private System.Windows.Forms.ComboBox cboSearchField;
        private System.Windows.Forms.RadioButton radioEqName;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.RadioButton radioSolName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lvRecent;
        private System.Windows.Forms.Label lblRecentCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}