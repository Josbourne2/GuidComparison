namespace GuidComparison
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cblInsertOptions = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.txtNumberOfRows = new System.Windows.Forms.TextBox();
            this.cbDisplayStatistics = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // cblInsertOptions
            // 
            this.cblInsertOptions.FormattingEnabled = true;
            this.cblInsertOptions.Items.AddRange(new object[] {
            "Random guids",
            "Sequential guids (RT.Comb)",
            "Sequential guids (Leonid)"});
            this.cblInsertOptions.Location = new System.Drawing.Point(16, 70);
            this.cblInsertOptions.Name = "cblInsertOptions";
            this.cblInsertOptions.Size = new System.Drawing.Size(170, 94);
            this.cblInsertOptions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose tests to perform...";
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Location = new System.Drawing.Point(209, 51);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(121, 13);
            this.lblNumberOfRows.TabIndex = 3;
            this.lblNumberOfRows.Text = "Number of rows to insert";
            // 
            // txtNumberOfRows
            // 
            this.txtNumberOfRows.Location = new System.Drawing.Point(212, 70);
            this.txtNumberOfRows.Name = "txtNumberOfRows";
            this.txtNumberOfRows.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfRows.TabIndex = 4;
            // 
            // cbDisplayStatistics
            // 
            this.cbDisplayStatistics.AutoSize = true;
            this.cbDisplayStatistics.Location = new System.Drawing.Point(212, 110);
            this.cbDisplayStatistics.Name = "cbDisplayStatistics";
            this.cbDisplayStatistics.Size = new System.Drawing.Size(109, 17);
            this.cbDisplayStatistics.TabIndex = 6;
            this.cbDisplayStatistics.Text = "Display statistics?";
            this.cbDisplayStatistics.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(212, 182);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cbDisplayStatistics);
            this.Controls.Add(this.txtNumberOfRows);
            this.Controls.Add(this.lblNumberOfRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblInsertOptions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox cblInsertOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.TextBox txtNumberOfRows;
        private System.Windows.Forms.CheckBox cbDisplayStatistics;
        private System.Windows.Forms.Button btnGo;
    }
}

