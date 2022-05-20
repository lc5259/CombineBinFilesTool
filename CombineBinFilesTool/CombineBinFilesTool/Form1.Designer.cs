namespace CombineBinFilesTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BootFileSize = new System.Windows.Forms.TextBox();
            this.AppFileSize = new System.Windows.Forms.TextBox();
            this.CRCSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBBootFolder = new System.Windows.Forms.TextBox();
            this.btBoot = new System.Windows.Forms.Button();
            this.btApp = new System.Windows.Forms.Button();
            this.tBAppFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btCombineFiles = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.CRC200 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CRC512 = new System.Windows.Forms.RadioButton();
            this.labelhide = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = " boot loader文件夹下bin文件大小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "CRC段配置空间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "app文件夹下bin文件大小";
            // 
            // BootFileSize
            // 
            this.BootFileSize.Location = new System.Drawing.Point(258, 39);
            this.BootFileSize.Name = "BootFileSize";
            this.BootFileSize.Size = new System.Drawing.Size(100, 21);
            this.BootFileSize.TabIndex = 5;
            this.BootFileSize.Enter += new System.EventHandler(this.BootFileSize_Enter);
            this.BootFileSize.Leave += new System.EventHandler(this.BootFileSize_Leave);
            // 
            // AppFileSize
            // 
            this.AppFileSize.Location = new System.Drawing.Point(258, 72);
            this.AppFileSize.Name = "AppFileSize";
            this.AppFileSize.Size = new System.Drawing.Size(100, 21);
            this.AppFileSize.TabIndex = 6;
            this.AppFileSize.Enter += new System.EventHandler(this.AppFileSize_Enter);
            this.AppFileSize.Leave += new System.EventHandler(this.AppFileSize_Leave);
            // 
            // CRCSize
            // 
            this.CRCSize.Location = new System.Drawing.Point(258, 138);
            this.CRCSize.Name = "CRCSize";
            this.CRCSize.Size = new System.Drawing.Size(100, 21);
            this.CRCSize.TabIndex = 7;
            this.CRCSize.Enter += new System.EventHandler(this.CRCSize_Enter);
            this.CRCSize.Leave += new System.EventHandler(this.CRCSize_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = " boot loader文件夹下bin文件：";
            // 
            // tBBootFolder
            // 
            this.tBBootFolder.Location = new System.Drawing.Point(182, 192);
            this.tBBootFolder.Name = "tBBootFolder";
            this.tBBootFolder.Size = new System.Drawing.Size(302, 21);
            this.tBBootFolder.TabIndex = 9;
            // 
            // btBoot
            // 
            this.btBoot.Location = new System.Drawing.Point(490, 192);
            this.btBoot.Name = "btBoot";
            this.btBoot.Size = new System.Drawing.Size(60, 23);
            this.btBoot.TabIndex = 10;
            this.btBoot.Text = "选择";
            this.btBoot.UseVisualStyleBackColor = true;
            this.btBoot.Click += new System.EventHandler(this.btBoot_Click);
            // 
            // btApp
            // 
            this.btApp.Location = new System.Drawing.Point(491, 233);
            this.btApp.Name = "btApp";
            this.btApp.Size = new System.Drawing.Size(60, 23);
            this.btApp.TabIndex = 13;
            this.btApp.Text = "选择";
            this.btApp.UseVisualStyleBackColor = true;
            this.btApp.Click += new System.EventHandler(this.btApp_Click);
            // 
            // tBAppFolder
            // 
            this.tBAppFolder.Location = new System.Drawing.Point(182, 233);
            this.tBAppFolder.Name = "tBAppFolder";
            this.tBAppFolder.Size = new System.Drawing.Size(302, 21);
            this.tBAppFolder.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "app文件夹下bin文件：";
            // 
            // btCombineFiles
            // 
            this.btCombineFiles.Location = new System.Drawing.Point(267, 271);
            this.btCombineFiles.Name = "btCombineFiles";
            this.btCombineFiles.Size = new System.Drawing.Size(84, 32);
            this.btCombineFiles.TabIndex = 14;
            this.btCombineFiles.Text = "文件合并";
            this.btCombineFiles.UseVisualStyleBackColor = true;
            this.btCombineFiles.Click += new System.EventHandler(this.btCombineFiles_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "kb";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "kb";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "kb";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "CRC校验字段大小";
            // 
            // CRC200
            // 
            this.CRC200.AutoSize = true;
            this.CRC200.Checked = true;
            this.CRC200.Location = new System.Drawing.Point(6, 9);
            this.CRC200.Name = "CRC200";
            this.CRC200.Size = new System.Drawing.Size(47, 16);
            this.CRC200.TabIndex = 20;
            this.CRC200.TabStop = true;
            this.CRC200.Text = "200k";
            this.CRC200.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CRC512);
            this.groupBox1.Controls.Add(this.CRC200);
            this.groupBox1.Location = new System.Drawing.Point(258, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 31);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // CRC512
            // 
            this.CRC512.AutoSize = true;
            this.CRC512.Location = new System.Drawing.Point(63, 9);
            this.CRC512.Name = "CRC512";
            this.CRC512.Size = new System.Drawing.Size(47, 16);
            this.CRC512.TabIndex = 21;
            this.CRC512.Text = "512k";
            this.CRC512.UseVisualStyleBackColor = true;
            // 
            // labelhide
            // 
            this.labelhide.AutoSize = true;
            this.labelhide.Location = new System.Drawing.Point(448, 75);
            this.labelhide.Name = "labelhide";
            this.labelhide.Size = new System.Drawing.Size(101, 12);
            this.labelhide.TabIndex = 22;
            this.labelhide.Text = "用于失去焦点功能";
            this.labelhide.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 354);
            this.Controls.Add(this.labelhide);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btCombineFiles);
            this.Controls.Add(this.btApp);
            this.Controls.Add(this.tBAppFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btBoot);
            this.Controls.Add(this.tBBootFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CRCSize);
            this.Controls.Add(this.AppFileSize);
            this.Controls.Add(this.BootFileSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin文件合并";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BootFileSize;
        private System.Windows.Forms.TextBox AppFileSize;
        private System.Windows.Forms.TextBox CRCSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBBootFolder;
        private System.Windows.Forms.Button btBoot;
        private System.Windows.Forms.Button btApp;
        private System.Windows.Forms.TextBox tBAppFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btCombineFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton CRC200;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CRC512;
        private System.Windows.Forms.Label labelhide;
    }
}

