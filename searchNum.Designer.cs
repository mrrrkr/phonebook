namespace phonebook
{
    partial class searchNum
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
            this.PhoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Телефон = new System.Windows.Forms.Label();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PhoneMaskedTextBox
            // 
            this.PhoneMaskedTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PhoneMaskedTextBox.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.PhoneMaskedTextBox.ForeColor = System.Drawing.Color.Black;
            this.PhoneMaskedTextBox.Location = new System.Drawing.Point(197, 34);
            this.PhoneMaskedTextBox.Mask = "(999) 000-0000";
            this.PhoneMaskedTextBox.Name = "PhoneMaskedTextBox";
            this.PhoneMaskedTextBox.Size = new System.Drawing.Size(202, 35);
            this.PhoneMaskedTextBox.TabIndex = 13;
            // 
            // Телефон
            // 
            this.Телефон.AutoSize = true;
            this.Телефон.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.Телефон.Location = new System.Drawing.Point(47, 39);
            this.Телефон.Name = "Телефон";
            this.Телефон.Size = new System.Drawing.Size(106, 29);
            this.Телефон.TabIndex = 12;
            this.Телефон.Text = "Телефон";
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.ResultsTextBox.Location = new System.Drawing.Point(33, 227);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ReadOnly = true;
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultsTextBox.Size = new System.Drawing.Size(362, 159);
            this.ResultsTextBox.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.label1.Location = new System.Drawing.Point(100, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "Результаты поиска:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.button2.Location = new System.Drawing.Point(228, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 50);
            this.button2.TabIndex = 29;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.searchButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.searchButton.Location = new System.Drawing.Point(37, 110);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(170, 50);
            this.searchButton.TabIndex = 28;
            this.searchButton.Text = "Найти";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 430);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.PhoneMaskedTextBox);
            this.Controls.Add(this.Телефон);
            this.Name = "searchNum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "searchNum";
            this.Load += new System.EventHandler(this.searchNum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox PhoneMaskedTextBox;
        private System.Windows.Forms.Label Телефон;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button searchButton;
    }
}