namespace ATM
{
    partial class MainMenuForm
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
            this.WidthrawButton = new System.Windows.Forms.Button();
            this.BalanceButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WidthrawButton
            // 
            this.WidthrawButton.Location = new System.Drawing.Point(44, 42);
            this.WidthrawButton.Name = "WidthrawButton";
            this.WidthrawButton.Size = new System.Drawing.Size(133, 83);
            this.WidthrawButton.TabIndex = 0;
            this.WidthrawButton.Text = "Снять средства";
            this.WidthrawButton.UseVisualStyleBackColor = true;
            this.WidthrawButton.Click += new System.EventHandler(this.WidthrawButton_Click);
            // 
            // BalanceButton
            // 
            this.BalanceButton.Location = new System.Drawing.Point(247, 42);
            this.BalanceButton.Name = "BalanceButton";
            this.BalanceButton.Size = new System.Drawing.Size(132, 83);
            this.BalanceButton.TabIndex = 1;
            this.BalanceButton.Text = "Баланс";
            this.BalanceButton.UseVisualStyleBackColor = true;
            this.BalanceButton.Click += new System.EventHandler(this.BalanceButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(44, 156);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(335, 88);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 256);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BalanceButton);
            this.Controls.Add(this.WidthrawButton);
            this.Name = "MainMenuForm";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WidthrawButton;
        private System.Windows.Forms.Button BalanceButton;
        private System.Windows.Forms.Button ExitButton;
    }
}