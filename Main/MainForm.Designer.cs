namespace Main
{
    partial class MainForm
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
            this.clbList = new System.Windows.Forms.CheckedListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSetting = new System.Windows.Forms.MenuStrip();
            this.toolSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemXML2CS = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.listBoxLogInfo = new System.Windows.Forms.ListBox();
            this.menuSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbList
            // 
            this.clbList.CheckOnClick = true;
            this.clbList.FormattingEnabled = true;
            this.clbList.Location = new System.Drawing.Point(12, 73);
            this.clbList.Name = "clbList";
            this.clbList.Size = new System.Drawing.Size(335, 340);
            this.clbList.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(659, 121);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 32);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出单个文件";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(659, 237);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(129, 32);
            this.btnExportAll.TabIndex = 2;
            this.btnExportAll.Text = "导出所有文件";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "文件列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(377, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "日志信息";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Checked = true;
            this.checkBoxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAll.Location = new System.Drawing.Point(16, 41);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAll.TabIndex = 8;
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 419);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(335, 22);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuSetting
            // 
            this.menuSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSetting,
            this.工具ToolStripMenuItem});
            this.menuSetting.Location = new System.Drawing.Point(0, 0);
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Size = new System.Drawing.Size(800, 25);
            this.menuSetting.TabIndex = 15;
            this.menuSetting.Text = "menuSetting";
            // 
            // toolSetting
            // 
            this.toolSetting.Name = "toolSetting";
            this.toolSetting.Size = new System.Drawing.Size(44, 21);
            this.toolSetting.Text = "设置";
            this.toolSetting.Click += new System.EventHandler(this.toolSetting_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItemXML2CS});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // StripMenuItemXML2CS
            // 
            this.StripMenuItemXML2CS.Name = "StripMenuItemXML2CS";
            this.StripMenuItemXML2CS.Size = new System.Drawing.Size(124, 22);
            this.StripMenuItemXML2CS.Text = "XML2CS";
            this.StripMenuItemXML2CS.Click += new System.EventHandler(this.StripMenuItemXML2CS_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(273, 22);
            this.button2.TabIndex = 16;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBoxLogInfo
            // 
            this.listBoxLogInfo.FormattingEnabled = true;
            this.listBoxLogInfo.ItemHeight = 12;
            this.listBoxLogInfo.Location = new System.Drawing.Point(380, 73);
            this.listBoxLogInfo.Name = "listBoxLogInfo";
            this.listBoxLogInfo.Size = new System.Drawing.Size(273, 340);
            this.listBoxLogInfo.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxLogInfo);
            this.Controls.Add(this.menuSetting);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.clbList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuSetting;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "导出工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuSetting.ResumeLayout(false);
            this.menuSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbList;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolSetting;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemXML2CS;
        private System.Windows.Forms.ListBox listBoxLogInfo;
    }
}

