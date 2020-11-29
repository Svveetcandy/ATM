namespace ATM
{
    partial class WithdrawMoneyForm
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
            this.SumOfMoneyTextBox = new System.Windows.Forms.TextBox();
            this.WidthrawButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SumOfMoneyTextBox
            // 
            this.SumOfMoneyTextBox.Location = new System.Drawing.Point(157, 200);
            this.SumOfMoneyTextBox.MaxLength = 9;
            this.SumOfMoneyTextBox.Name = "SumOfMoneyTextBox";
            this.SumOfMoneyTextBox.Size = new System.Drawing.Size(100, 20);
            this.SumOfMoneyTextBox.TabIndex = 0;
            this.SumOfMoneyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SumOfMoneyTextBox_KeyPress);
            // 
            // WidthrawButton
            // 
            this.WidthrawButton.Location = new System.Drawing.Point(298, 193);
            this.WidthrawButton.Name = "WidthrawButton";
            this.WidthrawButton.Size = new System.Drawing.Size(100, 27);
            this.WidthrawButton.TabIndex = 1;
            this.WidthrawButton.Text = "Снять";
            this.WidthrawButton.UseVisualStyleBackColor = true;
            this.WidthrawButton.Click += new System.EventHandler(this.WidthrawButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(298, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 50);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(157, 121);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 50);
            this.button5.TabIndex = 6;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(298, 121);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 50);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BanknoteButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(22, 193);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 27);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // WithdrawMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 256);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WidthrawButton);
            this.Controls.Add(this.SumOfMoneyTextBox);
            this.Name = "WithdrawMoneyForm";
            this.Text = "Снятие средств";
            this.Load += new System.EventHandler(this.WithdrawMoneyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SumOfMoneyTextBox;
        private System.Windows.Forms.Button WidthrawButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button ExitButton;
    }
}