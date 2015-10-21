namespace MaplePE
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.sendTab = new System.Windows.Forms.TabPage();
            this.recvTab = new System.Windows.Forms.TabPage();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendView = new System.Windows.Forms.TreeView();
            this.recvView = new System.Windows.Forms.TreeView();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.recvButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.sendTab.SuspendLayout();
            this.recvTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.sendTab);
            this.tabControl.Controls.Add(this.recvTab);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(566, 286);
            this.tabControl.TabIndex = 0;
            // 
            // sendTab
            // 
            this.sendTab.Controls.Add(this.sendView);
            this.sendTab.Location = new System.Drawing.Point(4, 22);
            this.sendTab.Name = "sendTab";
            this.sendTab.Padding = new System.Windows.Forms.Padding(3);
            this.sendTab.Size = new System.Drawing.Size(558, 260);
            this.sendTab.TabIndex = 0;
            this.sendTab.Text = "Send";
            this.sendTab.UseVisualStyleBackColor = true;
            // 
            // recvTab
            // 
            this.recvTab.Controls.Add(this.recvView);
            this.recvTab.Location = new System.Drawing.Point(4, 22);
            this.recvTab.Name = "recvTab";
            this.recvTab.Padding = new System.Windows.Forms.Padding(3);
            this.recvTab.Size = new System.Drawing.Size(558, 260);
            this.recvTab.TabIndex = 1;
            this.recvTab.Text = "Recv";
            this.recvTab.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(590, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sendView
            // 
            this.sendView.Location = new System.Drawing.Point(6, 6);
            this.sendView.Name = "sendView";
            this.sendView.Size = new System.Drawing.Size(546, 248);
            this.sendView.TabIndex = 0;
            // 
            // recvView
            // 
            this.recvView.Location = new System.Drawing.Point(6, 6);
            this.recvView.Name = "recvView";
            this.recvView.Size = new System.Drawing.Size(546, 248);
            this.recvView.TabIndex = 0;
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // packetText
            // 
            this.packetText.Location = new System.Drawing.Point(12, 319);
            this.packetText.Name = "packetText";
            this.packetText.Size = new System.Drawing.Size(446, 20);
            this.packetText.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(464, 315);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(54, 27);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // recvButton
            // 
            this.recvButton.Location = new System.Drawing.Point(524, 315);
            this.recvButton.Name = "recvButton";
            this.recvButton.Size = new System.Drawing.Size(54, 27);
            this.recvButton.TabIndex = 4;
            this.recvButton.Text = "Recv";
            this.recvButton.UseVisualStyleBackColor = true;
            this.recvButton.Click += new System.EventHandler(this.recvButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 349);
            this.Controls.Add(this.recvButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.packetText);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MaplePE v166.1";
            this.tabControl.ResumeLayout(false);
            this.sendTab.ResumeLayout(false);
            this.recvTab.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage sendTab;
        private System.Windows.Forms.TabPage recvTab;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TreeView sendView;
        private System.Windows.Forms.TreeView recvView;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.TextBox packetText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button recvButton;
    }
}

