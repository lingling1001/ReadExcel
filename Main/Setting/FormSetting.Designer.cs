namespace Main
{
    partial class FormSetting
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.texExcel = new System.Windows.Forms.TextBox();
            this.texXml = new System.Windows.Forms.TextBox();
            this.btnSelectExcel = new System.Windows.Forms.Button();
            this.btnSelectXml = new System.Windows.Forms.Button();
            this.btnCS = new System.Windows.Forms.Button();
            this.texCS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(81, 342);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(147, 39);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(166, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excel路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "XML路径";
            // 
            // texExcel
            // 
            this.texExcel.Location = new System.Drawing.Point(123, 47);
            this.texExcel.Name = "texExcel";
            this.texExcel.Size = new System.Drawing.Size(320, 21);
            this.texExcel.TabIndex = 4;
            this.texExcel.TextChanged += new System.EventHandler(this.texExcel_TextChanged);
            // 
            // texXml
            // 
            this.texXml.Location = new System.Drawing.Point(123, 91);
            this.texXml.Name = "texXml";
            this.texXml.Size = new System.Drawing.Size(320, 21);
            this.texXml.TabIndex = 5;
            this.texXml.TextChanged += new System.EventHandler(this.texXml_TextChanged);
            // 
            // btnSelectExcel
            // 
            this.btnSelectExcel.Location = new System.Drawing.Point(471, 44);
            this.btnSelectExcel.Name = "btnSelectExcel";
            this.btnSelectExcel.Size = new System.Drawing.Size(75, 24);
            this.btnSelectExcel.TabIndex = 7;
            this.btnSelectExcel.Text = "选择";
            this.btnSelectExcel.UseVisualStyleBackColor = true;
            this.btnSelectExcel.Click += new System.EventHandler(this.btnSelectExcel_Click);
            // 
            // btnSelectXml
            // 
            this.btnSelectXml.Location = new System.Drawing.Point(471, 88);
            this.btnSelectXml.Name = "btnSelectXml";
            this.btnSelectXml.Size = new System.Drawing.Size(75, 24);
            this.btnSelectXml.TabIndex = 8;
            this.btnSelectXml.Text = "选择";
            this.btnSelectXml.UseVisualStyleBackColor = true;
            this.btnSelectXml.Click += new System.EventHandler(this.btnSelectXml_Click);
            // 
            // btnCS
            // 
            this.btnCS.Location = new System.Drawing.Point(471, 135);
            this.btnCS.Name = "btnCS";
            this.btnCS.Size = new System.Drawing.Size(75, 24);
            this.btnCS.TabIndex = 11;
            this.btnCS.Text = "选择";
            this.btnCS.UseVisualStyleBackColor = true;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // texCS
            // 
            this.texCS.Location = new System.Drawing.Point(123, 138);
            this.texCS.Name = "texCS";
            this.texCS.Size = new System.Drawing.Size(320, 21);
            this.texCS.TabIndex = 10;
            this.texCS.TextChanged += new System.EventHandler(this.texCS_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "CS路径";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.btnCS);
            this.Controls.Add(this.texCS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectXml);
            this.Controls.Add(this.btnSelectExcel);
            this.Controls.Add(this.texXml);
            this.Controls.Add(this.texExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox texExcel;
        private System.Windows.Forms.TextBox texXml;
        private System.Windows.Forms.Button btnSelectExcel;
        private System.Windows.Forms.Button btnSelectXml;
        private System.Windows.Forms.Button btnCS;
        private System.Windows.Forms.TextBox texCS;
        private System.Windows.Forms.Label label3;
    }
}