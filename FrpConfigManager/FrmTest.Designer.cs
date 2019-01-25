namespace FrpConfigManager
{
    partial class FrmTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbModels = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtxtInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbModels);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "节点";
            // 
            // cbbModels
            // 
            this.cbbModels.FormattingEnabled = true;
            this.cbbModels.Location = new System.Drawing.Point(53, 50);
            this.cbbModels.Name = "cbbModels";
            this.cbbModels.Size = new System.Drawing.Size(121, 20);
            this.cbbModels.TabIndex = 0;
            this.cbbModels.SelectedIndexChanged += new System.EventHandler(this.cbbModels_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtxtInfo);
            this.panel1.Location = new System.Drawing.Point(222, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 317);
            this.panel1.TabIndex = 2;
            // 
            // rtxtInfo
            // 
            this.rtxtInfo.Location = new System.Drawing.Point(3, 3);
            this.rtxtInfo.Name = "rtxtInfo";
            this.rtxtInfo.Size = new System.Drawing.Size(208, 314);
            this.rtxtInfo.TabIndex = 1;
            this.rtxtInfo.Text = "";
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 361);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbModels;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxtInfo;
    }
}