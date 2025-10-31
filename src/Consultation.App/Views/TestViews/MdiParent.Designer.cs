namespace Consultation.App.Views.TestViews
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
            menuStrip1 = new MenuStrip();
            werToolStripMenuItem = new ToolStripMenuItem();
            rtyToolStripMenuItem = new ToolStripMenuItem();
            asdToolStripMenuItem = new ToolStripMenuItem();
            fghToolStripMenuItem = new ToolStripMenuItem();
            jklToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { werToolStripMenuItem, rtyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // werToolStripMenuItem
            // 
            werToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asdToolStripMenuItem, fghToolStripMenuItem, jklToolStripMenuItem });
            werToolStripMenuItem.Name = "werToolStripMenuItem";
            werToolStripMenuItem.Size = new Size(38, 20);
            werToolStripMenuItem.Text = "wer";
            // 
            // rtyToolStripMenuItem
            // 
            rtyToolStripMenuItem.Name = "rtyToolStripMenuItem";
            rtyToolStripMenuItem.Size = new Size(33, 20);
            rtyToolStripMenuItem.Text = "rty";
            // 
            // asdToolStripMenuItem
            // 
            asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            asdToolStripMenuItem.Size = new Size(180, 22);
            asdToolStripMenuItem.Text = "asd";
            // 
            // fghToolStripMenuItem
            // 
            fghToolStripMenuItem.Name = "fghToolStripMenuItem";
            fghToolStripMenuItem.Size = new Size(180, 22);
            fghToolStripMenuItem.Text = "fgh";
            // 
            // jklToolStripMenuItem
            // 
            jklToolStripMenuItem.Name = "jklToolStripMenuItem";
            jklToolStripMenuItem.Size = new Size(180, 22);
            jklToolStripMenuItem.Text = "jkl";
            // 
            // MdiParent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MdiParent";
            Text = "MdiParent";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem werToolStripMenuItem;
        private ToolStripMenuItem asdToolStripMenuItem;
        private ToolStripMenuItem fghToolStripMenuItem;
        private ToolStripMenuItem jklToolStripMenuItem;
        private ToolStripMenuItem rtyToolStripMenuItem;
    }
}