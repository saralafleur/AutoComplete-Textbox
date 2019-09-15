namespace AutoCompleteTextBox
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.autoCompleteTextBox1 = new NCR.LogReader.WinForm.Controls.AutoCompleteTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(188, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 311);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.autoCompleteTextBox1);
            this.panel2.Location = new System.Drawing.Point(88, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 222);
            this.panel2.TabIndex = 2;
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.AcceptsTab = true;
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(80, 59);
            this.autoCompleteTextBox1.Multiline = true;
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(149, 104);
            this.autoCompleteTextBox1.TabAs2Spaces = true;
            this.autoCompleteTextBox1.TabIndex = 1;
            this.autoCompleteTextBox1.Values = new string[] {
        "Required",
        "Optional",
        "Required in Order",
        "Repeating",
        "TELLER",
        "ITM",
        "Start",
        "Stop",
        "Body",
        "Reset",
        "Search",
        "WHERE",
        "GET",
        "EOF",
        "Pattern"};
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 429);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private NCR.LogReader.WinForm.Controls.AutoCompleteTextBox autoCompleteTextBox1;
    }
}