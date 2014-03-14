namespace sws
{
    partial class WindowsSwitcher
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsSwitcher));
            this.listBox = new System.Windows.Forms.ListBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.deleteButton1 = new System.Windows.Forms.Button();
            this.deleteButton2 = new System.Windows.Forms.Button();
            this.deleteButton3 = new System.Windows.Forms.Button();
            this.deleteButton4 = new System.Windows.Forms.Button();
            this.deleteButton5 = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.altRadioButton = new System.Windows.Forms.RadioButton();
            this.ctrlRadioButton = new System.Windows.Forms.RadioButton();
            this.winRadioButton = new System.Windows.Forms.RadioButton();
            this.shiftRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(228, 46);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(232, 220);
            this.listBox.TabIndex = 0;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(228, 11);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(147, 19);
            this.filterTextBox.TabIndex = 1;
            this.filterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyDown);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(385, 9);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(15, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 39);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(160, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteButton2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(15, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 39);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process2";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(160, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deleteButton3);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(15, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 39);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Process3";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(160, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.deleteButton4);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(15, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 39);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Process4";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(160, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.deleteButton5);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(15, 226);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 39);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Process5";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(160, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "<<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // deleteButton1
            // 
            this.deleteButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton1.ForeColor = System.Drawing.Color.Red;
            this.deleteButton1.Location = new System.Drawing.Point(129, 10);
            this.deleteButton1.Name = "deleteButton1";
            this.deleteButton1.Size = new System.Drawing.Size(25, 23);
            this.deleteButton1.TabIndex = 2;
            this.deleteButton1.Text = "-";
            this.deleteButton1.UseVisualStyleBackColor = true;
            this.deleteButton1.Click += new System.EventHandler(this.deleteButton1_Click);
            // 
            // deleteButton2
            // 
            this.deleteButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton2.ForeColor = System.Drawing.Color.Red;
            this.deleteButton2.Location = new System.Drawing.Point(129, 10);
            this.deleteButton2.Name = "deleteButton2";
            this.deleteButton2.Size = new System.Drawing.Size(25, 23);
            this.deleteButton2.TabIndex = 3;
            this.deleteButton2.Text = "-";
            this.deleteButton2.UseVisualStyleBackColor = true;
            this.deleteButton2.Click += new System.EventHandler(this.deleteButton2_Click);
            // 
            // deleteButton3
            // 
            this.deleteButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton3.ForeColor = System.Drawing.Color.Red;
            this.deleteButton3.Location = new System.Drawing.Point(129, 10);
            this.deleteButton3.Name = "deleteButton3";
            this.deleteButton3.Size = new System.Drawing.Size(25, 23);
            this.deleteButton3.TabIndex = 4;
            this.deleteButton3.Text = "-";
            this.deleteButton3.UseVisualStyleBackColor = true;
            this.deleteButton3.Click += new System.EventHandler(this.deleteButton3_Click);
            // 
            // deleteButton4
            // 
            this.deleteButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton4.ForeColor = System.Drawing.Color.Red;
            this.deleteButton4.Location = new System.Drawing.Point(129, 10);
            this.deleteButton4.Name = "deleteButton4";
            this.deleteButton4.Size = new System.Drawing.Size(25, 23);
            this.deleteButton4.TabIndex = 11;
            this.deleteButton4.Text = "-";
            this.deleteButton4.UseVisualStyleBackColor = true;
            this.deleteButton4.Click += new System.EventHandler(this.deleteButton4_Click);
            // 
            // deleteButton5
            // 
            this.deleteButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton5.ForeColor = System.Drawing.Color.Red;
            this.deleteButton5.Location = new System.Drawing.Point(129, 10);
            this.deleteButton5.Name = "deleteButton5";
            this.deleteButton5.Size = new System.Drawing.Size(25, 23);
            this.deleteButton5.TabIndex = 12;
            this.deleteButton5.Text = "-";
            this.deleteButton5.UseVisualStyleBackColor = true;
            this.deleteButton5.Click += new System.EventHandler(this.deleteButton5_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // altRadioButton
            // 
            this.altRadioButton.AutoSize = true;
            this.altRadioButton.Checked = true;
            this.altRadioButton.Location = new System.Drawing.Point(12, 12);
            this.altRadioButton.Name = "altRadioButton";
            this.altRadioButton.Size = new System.Drawing.Size(44, 16);
            this.altRadioButton.TabIndex = 11;
            this.altRadioButton.Text = "ALT";
            this.altRadioButton.UseVisualStyleBackColor = true;
            this.altRadioButton.CheckedChanged += new System.EventHandler(this.altRadioButton_CheckedChanged);
            // 
            // ctrlRadioButton
            // 
            this.ctrlRadioButton.AutoSize = true;
            this.ctrlRadioButton.Location = new System.Drawing.Point(60, 12);
            this.ctrlRadioButton.Name = "ctrlRadioButton";
            this.ctrlRadioButton.Size = new System.Drawing.Size(52, 16);
            this.ctrlRadioButton.TabIndex = 12;
            this.ctrlRadioButton.Text = "CTRL";
            this.ctrlRadioButton.UseVisualStyleBackColor = true;
            this.ctrlRadioButton.CheckedChanged += new System.EventHandler(this.ctrlRadioButton_CheckedChanged);
            // 
            // winRadioButton
            // 
            this.winRadioButton.AutoSize = true;
            this.winRadioButton.Location = new System.Drawing.Point(118, 12);
            this.winRadioButton.Name = "winRadioButton";
            this.winRadioButton.Size = new System.Drawing.Size(43, 16);
            this.winRadioButton.TabIndex = 13;
            this.winRadioButton.Text = "WIN";
            this.winRadioButton.UseVisualStyleBackColor = true;
            this.winRadioButton.CheckedChanged += new System.EventHandler(this.winRadioButton_CheckedChanged);
            // 
            // shiftRadioButton
            // 
            this.shiftRadioButton.AutoSize = true;
            this.shiftRadioButton.Location = new System.Drawing.Point(167, 12);
            this.shiftRadioButton.Name = "shiftRadioButton";
            this.shiftRadioButton.Size = new System.Drawing.Size(55, 16);
            this.shiftRadioButton.TabIndex = 14;
            this.shiftRadioButton.Text = "SHIFT";
            this.shiftRadioButton.UseVisualStyleBackColor = true;
            this.shiftRadioButton.CheckedChanged += new System.EventHandler(this.shiftRadioButton_CheckedChanged);
            // 
            // WindowsSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(472, 300);
            this.Controls.Add(this.shiftRadioButton);
            this.Controls.Add(this.winRadioButton);
            this.Controls.Add(this.ctrlRadioButton);
            this.Controls.Add(this.altRadioButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WindowsSwitcher";
            this.Text = "YAGNPW - You ain\'t gonna need plural windows. ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowsSwitcher_FormClosing);
            this.Load += new System.EventHandler(this.WindowsSwitcher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowsSwitcher_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button deleteButton1;
        private System.Windows.Forms.Button deleteButton2;
        private System.Windows.Forms.Button deleteButton3;
        private System.Windows.Forms.Button deleteButton4;
        private System.Windows.Forms.Button deleteButton5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RadioButton altRadioButton;
        private System.Windows.Forms.RadioButton ctrlRadioButton;
        private System.Windows.Forms.RadioButton winRadioButton;
        private System.Windows.Forms.RadioButton shiftRadioButton;
    }
}

