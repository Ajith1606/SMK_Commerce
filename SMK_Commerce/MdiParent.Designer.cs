namespace SMK_Commerce
{
    partial class MdiParent
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
            this.voterCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adharCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smartCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voterCardToolStripMenuItem,
            this.adharCardToolStripMenuItem,
            this.smartCardToolStripMenuItem,
            this.panCardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 46);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // voterCardToolStripMenuItem
            // 
            this.voterCardToolStripMenuItem.Name = "voterCardToolStripMenuItem";
            this.voterCardToolStripMenuItem.Size = new System.Drawing.Size(170, 42);
            this.voterCardToolStripMenuItem.Text = "Voter Card";
            this.voterCardToolStripMenuItem.Click += new System.EventHandler(this.voterCardToolStripMenuItem_Click);
            // 
            // adharCardToolStripMenuItem
            // 
            this.adharCardToolStripMenuItem.Name = "adharCardToolStripMenuItem";
            this.adharCardToolStripMenuItem.Size = new System.Drawing.Size(179, 42);
            this.adharCardToolStripMenuItem.Text = "Adhar Card";
            this.adharCardToolStripMenuItem.Click += new System.EventHandler(this.adharCardToolStripMenuItem_Click);
            // 
            // smartCardToolStripMenuItem
            // 
            this.smartCardToolStripMenuItem.Name = "smartCardToolStripMenuItem";
            this.smartCardToolStripMenuItem.Size = new System.Drawing.Size(179, 42);
            this.smartCardToolStripMenuItem.Text = "Smart Card";
            this.smartCardToolStripMenuItem.Click += new System.EventHandler(this.smartCardToolStripMenuItem_Click);
            // 
            // panCardToolStripMenuItem
            // 
            this.panCardToolStripMenuItem.Name = "panCardToolStripMenuItem";
            this.panCardToolStripMenuItem.Size = new System.Drawing.Size(147, 42);
            this.panCardToolStripMenuItem.Text = "Pan Card";
            this.panCardToolStripMenuItem.Click += new System.EventHandler(this.panCardToolStripMenuItem_Click);
            // 
            // MdiParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MdiParent";
            this.Text = "SMK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem voterCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adharCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smartCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panCardToolStripMenuItem;
    }
}