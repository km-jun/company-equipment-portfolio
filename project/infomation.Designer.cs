namespace project
{
    partial class infoForm
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
            this.lblEquipStatusTitle = new System.Windows.Forms.Label();
            this.lblEquipMain = new System.Windows.Forms.Label();
            this.lblBrokenStatusTitle = new System.Windows.Forms.Label();
            this.lblBrokenMain = new System.Windows.Forms.Label();
            this.lblIssueMain = new System.Windows.Forms.Label();
            this.lblIssueStatusTitle = new System.Windows.Forms.Label();
            this.panelStatus1 = new System.Windows.Forms.Panel();
            this.lblEquipSub = new System.Windows.Forms.Label();
            this.panelStatus3 = new System.Windows.Forms.Panel();
            this.lblBrokenSub = new System.Windows.Forms.Label();
            this.panelStatus4 = new System.Windows.Forms.Panel();
            this.lblRateSub = new System.Windows.Forms.Label();
            this.lblRateMain = new System.Windows.Forms.Label();
            this.lblRateStatusTitle = new System.Windows.Forms.Label();
            this.panelStatus2 = new System.Windows.Forms.Panel();
            this.lblIssueSub = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvEquipList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.rdoSearchByCode = new System.Windows.Forms.RadioButton();
            this.rdoSearchByName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDateMode = new System.Windows.Forms.ComboBox();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.txtFind1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelStatus1.SuspendLayout();
            this.panelStatus3.SuspendLayout();
            this.panelStatus4.SuspendLayout();
            this.panelStatus2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEquipStatusTitle
            // 
            this.lblEquipStatusTitle.AutoSize = true;
            this.lblEquipStatusTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEquipStatusTitle.Location = new System.Drawing.Point(8, 18);
            this.lblEquipStatusTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquipStatusTitle.Name = "lblEquipStatusTitle";
            this.lblEquipStatusTitle.Size = new System.Drawing.Size(269, 16);
            this.lblEquipStatusTitle.TabIndex = 27;
            this.lblEquipStatusTitle.Text = "장비 현황(총/현재/열외/열외내용)";
            // 
            // lblEquipMain
            // 
            this.lblEquipMain.AutoSize = true;
            this.lblEquipMain.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEquipMain.Location = new System.Drawing.Point(11, 43);
            this.lblEquipMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquipMain.Name = "lblEquipMain";
            this.lblEquipMain.Size = new System.Drawing.Size(53, 14);
            this.lblEquipMain.TabIndex = 30;
            this.lblEquipMain.Text = "label12";
            // 
            // lblBrokenStatusTitle
            // 
            this.lblBrokenStatusTitle.AutoSize = true;
            this.lblBrokenStatusTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBrokenStatusTitle.Location = new System.Drawing.Point(10, 10);
            this.lblBrokenStatusTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrokenStatusTitle.Name = "lblBrokenStatusTitle";
            this.lblBrokenStatusTitle.Size = new System.Drawing.Size(81, 16);
            this.lblBrokenStatusTitle.TabIndex = 20;
            this.lblBrokenStatusTitle.Text = "결함 장비";
            // 
            // lblBrokenMain
            // 
            this.lblBrokenMain.AutoSize = true;
            this.lblBrokenMain.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBrokenMain.Location = new System.Drawing.Point(11, 38);
            this.lblBrokenMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrokenMain.Name = "lblBrokenMain";
            this.lblBrokenMain.Size = new System.Drawing.Size(53, 14);
            this.lblBrokenMain.TabIndex = 24;
            this.lblBrokenMain.Text = "label13";
            // 
            // lblIssueMain
            // 
            this.lblIssueMain.AutoSize = true;
            this.lblIssueMain.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIssueMain.Location = new System.Drawing.Point(11, 69);
            this.lblIssueMain.Name = "lblIssueMain";
            this.lblIssueMain.Size = new System.Drawing.Size(45, 14);
            this.lblIssueMain.TabIndex = 25;
            this.lblIssueMain.Text = "label7";
            // 
            // lblIssueStatusTitle
            // 
            this.lblIssueStatusTitle.AutoSize = true;
            this.lblIssueStatusTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIssueStatusTitle.Location = new System.Drawing.Point(11, 18);
            this.lblIssueStatusTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueStatusTitle.Name = "lblIssueStatusTitle";
            this.lblIssueStatusTitle.Size = new System.Drawing.Size(81, 16);
            this.lblIssueStatusTitle.TabIndex = 21;
            this.lblIssueStatusTitle.Text = "지급 현황";
            // 
            // panelStatus1
            // 
            this.panelStatus1.Controls.Add(this.lblEquipSub);
            this.panelStatus1.Controls.Add(this.lblEquipMain);
            this.panelStatus1.Controls.Add(this.lblEquipStatusTitle);
            this.panelStatus1.Location = new System.Drawing.Point(6, 4);
            this.panelStatus1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelStatus1.Name = "panelStatus1";
            this.panelStatus1.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.panelStatus1.Size = new System.Drawing.Size(343, 93);
            this.panelStatus1.TabIndex = 24;
            // 
            // lblEquipSub
            // 
            this.lblEquipSub.AutoSize = true;
            this.lblEquipSub.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEquipSub.Location = new System.Drawing.Point(11, 69);
            this.lblEquipSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquipSub.Name = "lblEquipSub";
            this.lblEquipSub.Size = new System.Drawing.Size(45, 14);
            this.lblEquipSub.TabIndex = 31;
            this.lblEquipSub.Text = "label4";
            // 
            // panelStatus3
            // 
            this.panelStatus3.Controls.Add(this.lblBrokenSub);
            this.panelStatus3.Controls.Add(this.lblBrokenMain);
            this.panelStatus3.Controls.Add(this.lblBrokenStatusTitle);
            this.panelStatus3.Location = new System.Drawing.Point(6, 105);
            this.panelStatus3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelStatus3.Name = "panelStatus3";
            this.panelStatus3.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.panelStatus3.Size = new System.Drawing.Size(343, 84);
            this.panelStatus3.TabIndex = 25;
            // 
            // lblBrokenSub
            // 
            this.lblBrokenSub.AutoSize = true;
            this.lblBrokenSub.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBrokenSub.Location = new System.Drawing.Point(11, 65);
            this.lblBrokenSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrokenSub.Name = "lblBrokenSub";
            this.lblBrokenSub.Size = new System.Drawing.Size(45, 14);
            this.lblBrokenSub.TabIndex = 25;
            this.lblBrokenSub.Text = "label6";
            // 
            // panelStatus4
            // 
            this.panelStatus4.Controls.Add(this.lblRateSub);
            this.panelStatus4.Controls.Add(this.lblRateMain);
            this.panelStatus4.Controls.Add(this.lblRateStatusTitle);
            this.panelStatus4.Location = new System.Drawing.Point(356, 105);
            this.panelStatus4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelStatus4.Name = "panelStatus4";
            this.panelStatus4.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.panelStatus4.Size = new System.Drawing.Size(181, 84);
            this.panelStatus4.TabIndex = 31;
            // 
            // lblRateSub
            // 
            this.lblRateSub.AutoSize = true;
            this.lblRateSub.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRateSub.Location = new System.Drawing.Point(18, 65);
            this.lblRateSub.Name = "lblRateSub";
            this.lblRateSub.Size = new System.Drawing.Size(45, 14);
            this.lblRateSub.TabIndex = 34;
            this.lblRateSub.Text = "label4";
            // 
            // lblRateMain
            // 
            this.lblRateMain.AutoSize = true;
            this.lblRateMain.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRateMain.Location = new System.Drawing.Point(12, 38);
            this.lblRateMain.Name = "lblRateMain";
            this.lblRateMain.Size = new System.Drawing.Size(53, 14);
            this.lblRateMain.TabIndex = 33;
            this.lblRateMain.Text = "label13";
            // 
            // lblRateStatusTitle
            // 
            this.lblRateStatusTitle.AutoSize = true;
            this.lblRateStatusTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRateStatusTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRateStatusTitle.Name = "lblRateStatusTitle";
            this.lblRateStatusTitle.Size = new System.Drawing.Size(98, 16);
            this.lblRateStatusTitle.TabIndex = 32;
            this.lblRateStatusTitle.Text = "전체 가용률";
            // 
            // panelStatus2
            // 
            this.panelStatus2.Controls.Add(this.lblIssueSub);
            this.panelStatus2.Controls.Add(this.lblIssueStatusTitle);
            this.panelStatus2.Controls.Add(this.lblIssueMain);
            this.panelStatus2.Location = new System.Drawing.Point(355, 4);
            this.panelStatus2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelStatus2.Name = "panelStatus2";
            this.panelStatus2.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.panelStatus2.Size = new System.Drawing.Size(181, 93);
            this.panelStatus2.TabIndex = 34;
            // 
            // lblIssueSub
            // 
            this.lblIssueSub.AutoSize = true;
            this.lblIssueSub.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIssueSub.Location = new System.Drawing.Point(11, 43);
            this.lblIssueSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueSub.Name = "lblIssueSub";
            this.lblIssueSub.Size = new System.Drawing.Size(45, 14);
            this.lblIssueSub.TabIndex = 26;
            this.lblIssueSub.Text = "label4";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(3, 204);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(1448, 541);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "장비 현황";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvEquipList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.73619F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1442, 514);
            this.tableLayoutPanel1.TabIndex = 94;
            // 
            // dgvEquipList
            // 
            this.dgvEquipList.AllowUserToAddRows = false;
            this.dgvEquipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipList.Location = new System.Drawing.Point(3, 132);
            this.dgvEquipList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEquipList.Name = "dgvEquipList";
            this.dgvEquipList.RowHeadersWidth = 72;
            this.dgvEquipList.RowTemplate.Height = 34;
            this.dgvEquipList.Size = new System.Drawing.Size(1436, 378);
            this.dgvEquipList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtFind1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboDivision);
            this.panel1.Controls.Add(this.rdoSearchByCode);
            this.panel1.Controls.Add(this.rdoSearchByName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboDateMode);
            this.panel1.Controls.Add(this.dtpDateStart);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1436, 122);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(139, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 11);
            this.label2.TabIndex = 92;
            this.label2.Text = "▼날짜 조건";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(234, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 11);
            this.label4.TabIndex = 93;
            this.label4.Text = "종료일:";
            // 
            // cboDivision
            // 
            this.cboDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboDivision.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Items.AddRange(new object[] {
            "전체",
            "지급중 병력(미회수)",
            "최근 지급/회수 내역",
            "고장/수리중"});
            this.cboDivision.Location = new System.Drawing.Point(5, 77);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(113, 31);
            this.cboDivision.TabIndex = 30;
            this.cboDivision.SelectedIndexChanged += new System.EventHandler(this.cboDivision_SelectedIndexChanged);
            // 
            // rdoSearchByCode
            // 
            this.rdoSearchByCode.AutoSize = true;
            this.rdoSearchByCode.Checked = true;
            this.rdoSearchByCode.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoSearchByCode.Location = new System.Drawing.Point(32, 20);
            this.rdoSearchByCode.Margin = new System.Windows.Forms.Padding(5);
            this.rdoSearchByCode.Name = "rdoSearchByCode";
            this.rdoSearchByCode.Size = new System.Drawing.Size(86, 18);
            this.rdoSearchByCode.TabIndex = 36;
            this.rdoSearchByCode.TabStop = true;
            this.rdoSearchByCode.Text = "장비 코드";
            this.rdoSearchByCode.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByName
            // 
            this.rdoSearchByName.AutoSize = true;
            this.rdoSearchByName.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoSearchByName.Location = new System.Drawing.Point(131, 20);
            this.rdoSearchByName.Margin = new System.Windows.Forms.Padding(5);
            this.rdoSearchByName.Name = "rdoSearchByName";
            this.rdoSearchByName.Size = new System.Drawing.Size(67, 18);
            this.rdoSearchByName.TabIndex = 36;
            this.rdoSearchByName.Text = "장비명";
            this.rdoSearchByName.UseVisualStyleBackColor = true;
            this.rdoSearchByName.CheckedChanged += new System.EventHandler(this.radioEqName_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(234, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 11);
            this.label1.TabIndex = 27;
            this.label1.Text = "시작일:";
            // 
            // cboDateMode
            // 
            this.cboDateMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateMode.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboDateMode.FormattingEnabled = true;
            this.cboDateMode.Items.AddRange(new object[] {
            "전체(날짜 무관)",
            "지급일 기준",
            "회수일 기준",
            "지급/회수 전체"});
            this.cboDateMode.Location = new System.Drawing.Point(127, 77);
            this.cboDateMode.Name = "cboDateMode";
            this.cboDateMode.Size = new System.Drawing.Size(102, 19);
            this.cboDateMode.TabIndex = 90;
            this.cboDateMode.SelectedIndexChanged += new System.EventHandler(this.cboDateMode_SelectedIndexChanged);
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDateStart.CalendarFont = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateStart.CustomFormat = "";
            this.dtpDateStart.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateStart.Location = new System.Drawing.Point(282, 75);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(110, 20);
            this.dtpDateStart.TabIndex = 74;
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label.Location = new System.Drawing.Point(37, 60);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(37, 11);
            this.label.TabIndex = 32;
            this.label.Text = "▼구분";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDateEnd.CalendarFont = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateEnd.CustomFormat = "";
            this.dtpDateEnd.Font = new System.Drawing.Font("굴림", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(282, 96);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(110, 20);
            this.dtpDateEnd.TabIndex = 73;
            // 
            // txtFind1
            // 
            this.txtFind1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind1.Location = new System.Drawing.Point(409, 90);
            this.txtFind1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFind1.Name = "txtFind1";
            this.txtFind1.Size = new System.Drawing.Size(929, 26);
            this.txtFind1.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(1363, 90);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(752, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 91;
            this.label3.Text = "~";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.51852F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1454, 749);
            this.tableLayoutPanel2.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelStatus1);
            this.panel2.Controls.Add(this.panelStatus2);
            this.panel2.Controls.Add(this.panelStatus3);
            this.panel2.Controls.Add(this.panelStatus4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1448, 194);
            this.panel2.TabIndex = 36;
            // 
            // infoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 749);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "infoForm";
            this.Text = "imformation";
            this.Load += new System.EventHandler(this.infoForm_Load);
            this.panelStatus1.ResumeLayout(false);
            this.panelStatus1.PerformLayout();
            this.panelStatus3.ResumeLayout(false);
            this.panelStatus3.PerformLayout();
            this.panelStatus4.ResumeLayout(false);
            this.panelStatus4.PerformLayout();
            this.panelStatus2.ResumeLayout(false);
            this.panelStatus2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEquipStatusTitle;
        private System.Windows.Forms.Label lblEquipMain;
        private System.Windows.Forms.Label lblBrokenStatusTitle;
        private System.Windows.Forms.Label lblBrokenMain;
        private System.Windows.Forms.Label lblIssueMain;
        private System.Windows.Forms.Label lblIssueStatusTitle;
        private System.Windows.Forms.Panel panelStatus1;
        private System.Windows.Forms.Panel panelStatus3;
        private System.Windows.Forms.Panel panelStatus4;
        private System.Windows.Forms.Label lblRateMain;
        private System.Windows.Forms.Label lblRateStatusTitle;
        private System.Windows.Forms.Panel panelStatus2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvEquipList;
        private System.Windows.Forms.Label lblEquipSub;
        private System.Windows.Forms.Label lblIssueSub;
        private System.Windows.Forms.Label lblBrokenSub;
        private System.Windows.Forms.Label lblRateSub;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoSearchByCode;
        private System.Windows.Forms.RadioButton rdoSearchByName;
        private System.Windows.Forms.ComboBox cboDivision;
        private System.Windows.Forms.TextBox txtFind1;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.ComboBox cboDateMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
    }
}