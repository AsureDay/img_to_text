namespace WindowsFormsApp1
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.debugOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(78, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 115);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chose image";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // debugOutput
            // 
            this.debugOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.debugOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debugOutput.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.debugOutput.Location = new System.Drawing.Point(14, 285);
            this.debugOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.debugOutput.Name = "debugOutput";
            this.debugOutput.ReadOnly = true;
            this.debugOutput.Size = new System.Drawing.Size(361, 24);
            this.debugOutput.TabIndex = 3;
            this.debugOutput.Text = "text is";
            this.debugOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.debugOutput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(407, 478);
            this.Controls.Add(this.debugOutput);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "mainForm";
            this.Text = "Fo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox debugOutput;
    }
}

