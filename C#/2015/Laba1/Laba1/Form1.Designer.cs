namespace Laba1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.button_show1 = new System.Windows.Forms.Button();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.button_show2 = new System.Windows.Forms.Button();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.button_show3 = new System.Windows.Forms.Button();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.button_show4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttClear = new System.Windows.Forms.Button();
            this.buttAdd = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tab4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Location = new System.Drawing.Point(311, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 175);
            this.tabControl1.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.Silver;
            this.tab1.Controls.Add(this.button_show1);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(225, 149);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "QueueLst";
            // 
            // button_show1
            // 
            this.button_show1.Location = new System.Drawing.Point(148, 120);
            this.button_show1.Name = "button_show1";
            this.button_show1.Size = new System.Drawing.Size(75, 23);
            this.button_show1.TabIndex = 0;
            this.button_show1.Text = "show";
            this.button_show1.UseVisualStyleBackColor = true;
            this.button_show1.Click += new System.EventHandler(this.button_show1_Click);
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.Silver;
            this.tab2.Controls.Add(this.button_show2);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(225, 149);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "QueueArr";
            // 
            // button_show2
            // 
            this.button_show2.Location = new System.Drawing.Point(148, 120);
            this.button_show2.Name = "button_show2";
            this.button_show2.Size = new System.Drawing.Size(75, 23);
            this.button_show2.TabIndex = 0;
            this.button_show2.Text = "show";
            this.button_show2.UseVisualStyleBackColor = true;
            this.button_show2.Click += new System.EventHandler(this.button_show2_Click);
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.Silver;
            this.tab3.Controls.Add(this.button_show3);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Padding = new System.Windows.Forms.Padding(3);
            this.tab3.Size = new System.Drawing.Size(225, 149);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "StackLst";
            // 
            // button_show3
            // 
            this.button_show3.Location = new System.Drawing.Point(148, 120);
            this.button_show3.Name = "button_show3";
            this.button_show3.Size = new System.Drawing.Size(75, 23);
            this.button_show3.TabIndex = 0;
            this.button_show3.Text = "show";
            this.button_show3.UseVisualStyleBackColor = true;
            this.button_show3.Click += new System.EventHandler(this.button_show3_Click);
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.Color.Silver;
            this.tab4.Controls.Add(this.button_show4);
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Padding = new System.Windows.Forms.Padding(3);
            this.tab4.Size = new System.Drawing.Size(225, 149);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "StackArr";
            // 
            // button_show4
            // 
            this.button_show4.Location = new System.Drawing.Point(72, 47);
            this.button_show4.Name = "button_show4";
            this.button_show4.Size = new System.Drawing.Size(75, 23);
            this.button_show4.TabIndex = 0;
            this.button_show4.Text = "show";
            this.button_show4.UseVisualStyleBackColor = true;
            this.button_show4.Click += new System.EventHandler(this.button_show4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 175);
            this.textBox1.TabIndex = 1;
            // 
            // buttClear
            // 
            this.buttClear.Location = new System.Drawing.Point(40, 228);
            this.buttClear.Name = "buttClear";
            this.buttClear.Size = new System.Drawing.Size(75, 23);
            this.buttClear.TabIndex = 2;
            this.buttClear.Text = "Clear";
            this.buttClear.UseVisualStyleBackColor = true;
            this.buttClear.Click += new System.EventHandler(this.buttClear_Click);
            // 
            // buttAdd
            // 
            this.buttAdd.Location = new System.Drawing.Point(366, 228);
            this.buttAdd.Name = "buttAdd";
            this.buttAdd.Size = new System.Drawing.Size(75, 23);
            this.buttAdd.TabIndex = 2;
            this.buttAdd.Text = "Add";
            this.buttAdd.UseVisualStyleBackColor = true;
            this.buttAdd.Click += new System.EventHandler(this.buttAdd_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(459, 228);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 3;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(308, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "#Req";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 296);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.buttAdd);
            this.Controls.Add(this.buttClear);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab3.ResumeLayout(false);
            this.tab4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.Button button_show1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttClear;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.Button button_show2;
        private System.Windows.Forms.Button button_show3;
        private System.Windows.Forms.Button button_show4;
        private System.Windows.Forms.Button buttAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label2;
    }
}

